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
    public partial class CourseView : Form
    {
        private List<Course_Schedule> lcSchedules;
        private List<Course> lcCourses;


        public CourseView()
        {
            InitializeComponent();

            //Get list of course schedules and courses this user is enrolled on.
            lcSchedules = ScheduleManager.GetSchedulesOf(GlobalApplication.cMyUser);

            //If there are schedules
            if(lcSchedules.Count > 0)
            {
                lcCourses = lcSchedules.ToCourses();

                //Populate the combo box
                for (int i = 0; i < lcCourses.Count; i++)
                {
                    cbCourses.Items.Add(lcCourses[i].Course_Name);
                }

                //Set first selection
                cbCourses.SelectedIndex = 0;

                cbCourses.Refresh();
            }
        }

        #region Button events
        public void CourseView_OnSelectCourse(object sender, EventArgs args)
        {
            //Fill labels
            FillLabels(cbCourses.SelectedIndex);
        }
        public void CourseView_Close(object sender, EventArgs args)
        {
            this.Close();
        }
        #endregion

        #region Helper
        public void FillLabels(int index)
        {
            //Selection
            Course curCourse = lcCourses[index];
            Course_Schedule curSchedule = lcSchedules[index];

            //Set label text
            lbCourseName.Text = curCourse.Course_Name;
            lbCourseCode.Text = curCourse.Course_Code;
            lbTutorName.Text = curSchedule.GetTutor().FullName;
            lbTutorEmail.Text = curSchedule.GetTutor().Email;
            lbStartDate.Text = curSchedule.DT_From.ToString();
            lbFinishDate.Text = curSchedule.DT_To.ToString();
            lbDescription.Text = curCourse.Course_Description;
        }
        #endregion
    }
}
