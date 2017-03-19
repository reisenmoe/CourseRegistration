using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CourseRegistration;
using Renko;

namespace CourseRegistration
{
    public partial class ViewStudents : Form
    {
        private List<Course_Schedule> lcSchedules;
        private List<User> lcStudents;


        public ViewStudents()
        {
            InitializeComponent();

            //Get course schedule list
            lcSchedules = ScheduleManager.GetSchedulesOf(GlobalApplication.cMyUser);

            //If there are schedules
            if (lcSchedules.Count > 0)
            {
                //Set each schedules to combo box
                for (int i = 0; i < lcSchedules.Count; i++)
                {
                    cbCourses.Items.Add(lcSchedules[i].GetCourse().Course_Name);
                }

                //Set first selection
                cbCourses.SelectedValue = cbCourses.Items[0];

                cbCourses.Refresh();
            }
        }

        #region Button events
        public void ViewStudents_OnChangeCourse(object sender, EventArgs args)
        {
            //Clear grid view
            ViewStudents_ClearGridView();

            //Populate the grid view with index
            ViewStudents_PopulateGridView(cbCourses.SelectedIndex);
        }
        public void ViewStudents_Apply(object sender, EventArgs args)
        {
            //If row not selected, return
            if(!dgvStudentView.SelectedRow())
            {
                MessageBox.Show("Select a row first.");
                return;
            }

            //Get the student course of selected student
            Course_Schedule schedule = lcSchedules[cbCourses.SelectedIndex];
            User student = lcStudents[dgvStudentView.SelectedRowIndex()];
            Student_Course sCourse = student.GetStudentCourse(schedule);

            //Update
            sCourse.Grade = cbGrade.Text;
            sCourse.ModifiedDateTime = DateTime.Now;
            SharedManager.Update(sCourse, s => s.Grade, s => s.ModifiedDateTime);

            //Show message
            MessageBox.Show("Updated grade.");

            //Refresh grid view
            dgvStudentView.Refresh();
        }
        public void ViewStudents_Close(object sender, EventArgs args)
        {
            this.Close();
        }
        #endregion

        #region Helper
        public void ViewStudents_ClearGridView()
        {
            dgvStudentView.DataSource = null;
            dgvStudentView.Rows.Clear();
            dgvStudentView.Refresh();
        }
        public void ViewStudents_PopulateGridView(int index)
        {
            //Get students list
            lcStudents = lcSchedules[index].GetStudents();

            //Create new data table
            DataTable dt = new DataTable();

            //Set columns
            dt.Columns.Add("First Name");
            dt.Columns.Add("Last Name");
            dt.Columns.Add("Student ID");
            dt.Columns.Add("Grade");
            dt.Columns.Add("Email");
            dt.Columns.Add("Contact");

            //Set rows
            for(int i=0; i< lcStudents.Count;i++)
            {
                Student_Course sc = lcStudents[i].GetStudentCourse(lcSchedules[cbCourses.SelectedIndex]);
                dt.Rows.Add(lcStudents[i].FirstName, lcStudents[i].LastName, lcStudents[i].Student_ID, sc.Grade, lcStudents[i].Email, lcStudents[i].ContactNumber);
            }

            //Set data source
            dgvStudentView.DataSource = dt;
            dgvStudentView.ToggleColumnSort(false);

            //Refresh view
            dgvStudentView.Refresh();
        }
        #endregion
    }
}
