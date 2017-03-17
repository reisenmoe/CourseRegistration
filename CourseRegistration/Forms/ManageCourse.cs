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
    public partial class ManageCourse : Form
    {
        private List<Course> lcCourses;


        public ManageCourse()
        {
            InitializeComponent();

            //Set columns
            dgvCourses.Columns.Add("id", "id");
            dgvCourses.Columns.Add("Course Name", "Course Name");
            dgvCourses.Columns.Add("Faculty Name", "Faculty Name");
            dgvCourses.Columns.Add("Course Code", "Course Code");
            dgvCourses.Columns.Add("Course Description", "Course Description");
            dgvCourses.ToggleColumnSort(false);

            RefreshCourse();
        }

        #region Button events
        public void ManageCourse_Add(object sender, EventArgs args)
        {
            //Show MC_Add screen
            this.SwitchFormTo<MC_Add>((context) =>
            {
                context.Show();
                RefreshCourse();
            });
        }
        public void ManageCourse_Edit(object sender, EventArgs args)
        {
            //Return if no selection
            if (!dgvCourses.SelectedRow())
            {
                MessageBox.Show("Select a course first.");
                return;
            }

            //Set selected course
            MC_Edit.cSelectedCourse = lcCourses[dgvCourses.SelectedRowIndex()];

            //Show MC_Edit screen
            this.SwitchFormTo<MC_Edit>((context) =>
            {
                context.Show();
                RefreshCourse();
            });
        }
        public void ManageCourse_Delete(object sender, EventArgs args)
        {
            //Return if no selection
            if (!dgvCourses.SelectedRow())
            {
                MessageBox.Show("Select a course first.");
                return;
            }

            //Confirm first
            if(MessageBox.Show("Are you sure you want to delete this course?", "Delete course", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //Select the target course
                Course course = lcCourses[dgvCourses.SelectedRowIndex()];
                //Disable it
                course.IsActive = false;
                SharedManager.Update(course, c => c.IsActive);

                //Disable all schedules associated with this course
                List<Course_Schedule> schedules = course.GetSchedules();
                for (int i = 0; i < schedules.Count; i++)
                {
                    Course_Schedule cs = schedules[i];
                    cs.IsActive = false;
                    SharedManager.Update(cs, x => x.IsActive);

                    //Disable all student courses associated with this schedule
                    List<Student_Course> studentCourses = cs.GetStudentCourses();
                    for (int j = 0; j < studentCourses.Count; j++)
                    {
                        Student_Course sc = studentCourses[j];
                        sc.IsActive = false;
                        SharedManager.Update(sc, x => x.IsActive);
                    }
                }

                MessageBox.Show("Deleted course.");
            }
        }
        public void ManageCourse_Close(object sender, EventArgs args)
        {
            this.Close();
        }
        #endregion

        #region Helpers
        public void RefreshCourse()
        {
            //Clear courses
            lcCourses = null;
            dgvCourses.Rows.Clear();

            //Fill courses list
            lcCourses = CourseManager.GetAllCourses();

            //Display each courses
            for(int i=0; i<lcCourses.Count; i++)
            {
                Course curCourse = lcCourses[i];
                dgvCourses.Rows.Add(curCourse.Course_ID, curCourse.Course_Name, curCourse.GetFaculty().Faculty_Name, curCourse.Course_Code, curCourse.Course_Description);
            }

            //Refresh courses view
            dgvCourses.Refresh();
        }
        #endregion
    }
}
