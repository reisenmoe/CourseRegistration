using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Renko;

namespace CourseRegistration
{
    public partial class MS_Edit : Form
    {
        public static Course_Schedule cSelectedSchedule;

        private List<User> lcStudents;
        private List<Course> lcCourses;
        private List<User> lcTutors;


        public MS_Edit()
        {
            InitializeComponent();

            //Set columns
            dgvStudents.Columns.Add("id", "id");
            dgvStudents.Columns.Add("Full Name", "Full Name");
            dgvStudents.Columns.Add("Is Enrolled", "Is Enrolled");
            dgvStudents.ToggleColumnSort(false);

            //Fill combo boxes
            FillCourses();
            FillTutors();

            //Set current date times
            dtpStart.Value = cSelectedSchedule.DT_From;
            dtpEnd.Value = cSelectedSchedule.DT_To;
        }

        #region Button events
        public void Edit_Search(object sender, EventArgs args)
        {
            FillStudents(tbSearch.Text);
        }
        public void Edit_Toggle(object sender, EventArgs args)
        {
            //Return if nothing selected
            if(!SelectedRow())
            {
                MessageBox.Show("Select a student first.");
                return;
            }

            //Selected row index
            int index = SelectedRowIndex();

            //Get selected student user info
            User student = lcStudents[index];

            //If toggled on
            if ((bool)dgvStudents.Rows[index].Cells[2].Value)
            {
                //Delete existing schedule
                Student_Course studentCourse = student.GetStudentCourse(cSelectedSchedule);
                if (studentCourse != null)
                {
                    studentCourse.IsActive = false;
                    SharedManager.Update(studentCourse, sc => sc.IsActive);
                }

                //Toggle off
                dgvStudents.Rows[SelectedRowIndex()].Cells[2].Value = false;
            }
            else
            {
                //Create new schedule
                Student_Course studentCourse = new Student_Course();
                studentCourse.CreatedBy = GlobalApplication.cMyUser.User_ID;
                studentCourse.ModifiedBy = GlobalApplication.cMyUser.User_ID;
                studentCourse.User_ID = student.User_ID;

                StudentCourseManager.Create(studentCourse);

                //Toggle on
                dgvStudents.Rows[SelectedRowIndex()].Cells[2].Value = true;
            }

            //Set modified date for selected schedule
            cSelectedSchedule.ModifiedDateTime = DateTime.Now;
            SharedManager.Update(cSelectedSchedule, s => s.ModifiedDateTime);

            //Refresh data grid view
            dgvStudents.Refresh();
        }
        public void Edit_Edit(object sender, EventArgs args)
        {
            //Update schedule
            cSelectedSchedule.Course_ID = lcCourses[cbCourse.SelectedIndex].Course_ID;
            cSelectedSchedule.Teacher_ID = lcTutors[cbTutor.SelectedIndex].User_ID;
            cSelectedSchedule.DT_From = dtpStart.Value;
            cSelectedSchedule.DT_To = dtpEnd.Value;
            cSelectedSchedule.ModifiedDateTime = DateTime.Now;
            SharedManager.Update(cSelectedSchedule, s => s.Course_ID, s => s.Teacher_ID, s => s.DT_From, s => s.DT_To, s => s.ModifiedDateTime);

            MessageBox.Show("Edited course schedule.");

            this.Close();
        }
        public void Edit_Close(object sender, EventArgs args)
        {
            this.Close();
        }
        #endregion

        #region Helpers
        public void FillCourses()
        {
            //Clear courses
            lcCourses = null;
            cbCourse.Items.Clear();

            //Get all courses
            lcCourses = CourseManager.GetAllCourses();

            //Current course's id
            decimal curCourseID = cSelectedSchedule.GetCourse().Course_ID;
            //Fill the course combo box
            for (int i = 0; i < lcCourses.Count; i++)
            {
                cbCourse.Items.Add(lcCourses[i]);

                //Set selection
                if (lcCourses[i].Course_ID.Equals(curCourseID))
                {
                    cbCourse.SelectedIndex = i;
                }
            }

            //Set selection
            cbCourse.SelectedIndex = 0;

            //Refresh course
            cbCourse.Refresh();
        }
        public void FillTutors()
        {
            //Clear tutors
            lcTutors = null;
            cbTutor.Items.Clear();

            //Get all tutors
            lcTutors = UserManager.GetAllUsers(RoleTypes.Tutor);

            //Current tutor's id
            decimal curTutorID = cSelectedSchedule.GetTutor().User_ID;
            //Fill the tutor combo box
            for (int i = 0; i < lcTutors.Count; i++)
            {
                cbTutor.Items.Add(lcTutors[i]);

                //Set selection
                if(lcTutors[i].User_ID.Equals(curTutorID))
                {
                    cbTutor.SelectedIndex = i;
                }
            }

            //Refresh tutor
            cbTutor.Refresh();
        }
        public void FillStudents(string filter)
        {
            //Clear student list
            lcStudents = null;
            dgvStudents.Rows.Clear();

            //Get all students within filter
            lcStudents = UserManager.GetAllUsers(RoleTypes.Student).Where(u => u.FullName.ToLower().Contains(filter.ToLower())).ToList();

            //Fill rows
            for (int i = 0; i < lcStudents.Count; i++)
            {
                User curUser = lcStudents[i];
                dgvStudents.Rows.Add(curUser.User_ID, curUser.FullName, curUser.IsEnrolled(cSelectedSchedule));
            }
            
            //Refresh students
            dgvStudents.Refresh();
        }

        public bool SelectedRow()
        {
            return dgvStudents.SelectedRows.Count > 0;
        }
        public int SelectedRowIndex()
        {
            return dgvStudents.CurrentCell.RowIndex;
        }
        #endregion
    }
}
