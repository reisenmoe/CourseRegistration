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

namespace CourseRegistration
{
    public partial class ViewStudents : Form
    {
        private List<Course_Schedule> lcSchedules;


        public ViewStudents()
        {
            InitializeComponent();

            //Get course schedule list
            lcSchedules = ScheduleManager.GetSchedulesOf(GlobalApplication.cMyUser);
            //Set each schedules to combo box
            for (int i = 0; i < lcSchedules.Count; i++)
            {
                cbCourses.Items.Add(lcSchedules[i].GetCourse().Course_Name);
            }

            //Set first selection
            cbCourses.SelectedValue = cbCourses.Items[0];
        }

        #region Button events
        public void ViewStudents_OnChangeCourse(object sender, EventArgs args)
        {
            //Clear grid view
            ViewStudents_ClearGridView();

            //Populate the grid view with index
            ViewStudents_PopulateGridView(cbCourses.SelectedIndex);
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
            List<User> students = lcSchedules[index].GetStudents();

            //Create new data table
            DataTable dt = new DataTable();

            //Set columns
            dt.Columns.Add("First Name");
            dt.Columns.Add("Last Name");
            dt.Columns.Add("Student ID");
            dt.Columns.Add("Email");
            dt.Columns.Add("Contact");

            //Set rows
            for(int i=0; i<students.Count;i++)
            {
                dt.Rows.Add(students[i].FirstName, students[i].LastName, students[i].Student_ID, students[i].Email, students[i].ContactNumber);
            }

            //Set data source
            dgvStudentView.DataSource = dt;

            //Refresh view
            dgvStudentView.Refresh();
        }
        #endregion
    }
}
