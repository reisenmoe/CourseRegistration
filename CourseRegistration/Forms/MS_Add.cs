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
    public partial class MS_Add : Form
    {
        private List<Course> lcCourses;
        private List<User> lcTutors;


        public MS_Add()
        {
            InitializeComponent();

            //Add items to course combo box
            FillCourses();
            //Fill tutors
            FillTutors();
        }

        #region Button events
        public void Add(object sender, EventArgs args)
        {
            #region Validate inputs
            if (cbCourse.SelectedItem == null)
            {
                MessageBox.Show("Selected course is empty.");
                return;
            }
            if (cbTutor.SelectedItem == null)
            {
                MessageBox.Show("Selected tutor is empty.");
                return;
            }
            #endregion

            //Create new schedule object
            Course_Schedule schedule = new Course_Schedule();
            schedule.Course_ID = lcCourses[cbCourse.SelectedIndex].Course_ID;
            schedule.Course_ID = GlobalApplication.cMyUser.User_ID;
            schedule.DT_From = dtpStart.Value;
            schedule.DT_To = dtpEnd.Value;
            schedule.ModifiedBy = GlobalApplication.cMyUser.User_ID;
            schedule.Teacher_ID = lcTutors[cbTutor.SelectedIndex].User_ID;

            ScheduleManager.Create(schedule);

            MessageBox.Show("Schedule has been successfully added.");

            //Close
            this.Close();
        }
        public void Close(object sender, EventArgs args)
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

            //Get list of courses
            lcCourses = CourseManager.GetAllCourses();
            Debug.Log("LcCourses count: " + lcCourses.Count);

            //Fill courses combo box
            for (int i = 0; i < lcCourses.Count; i++)
                cbCourse.Items.Add(lcCourses[i].Course_Name);

            //Select the first course
            cbCourse.SelectedIndex = 0;

            cbCourse.Refresh();
        }
        public void FillTutors()
        {
            //Clear tutors
            lcTutors = null;
            cbTutor.Items.Clear();

            //Get list of tutors
            lcTutors = UserManager.GetAllUsers(RoleTypes.Tutor);

            //Only if there are any tutors
            if (lcTutors.Count > 0)
            {
                //Fill the combo box
                for (int i = 0; i < lcTutors.Count; i++)
                    cbTutor.Items.Add(lcTutors[i].FullName);

                //Select the first tutor
                cbTutor.SelectedIndex = 0;
            }

            cbTutor.Refresh();
        }
        #endregion
    }
}
