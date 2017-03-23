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
    public partial class ManageSchedule : Form
    {
        private List<Course_Schedule> lcSchedules;


        public ManageSchedule()
        {
            InitializeComponent();

            //Set columns
            dgvSchedules.Columns.Add("Id", "Id");
            dgvSchedules.Columns.Add("Course Name", "Course Name");
            dgvSchedules.Columns.Add("Tutor Name", "Tutor Name");
            dgvSchedules.Columns.Add("Start Date", "Start Date");
            dgvSchedules.Columns.Add("End Date", "End Date");
            dgvSchedules.ToggleColumnSort(false);

            FillGridView();


        }

        #region Button events
        public void ManageSchedule_Close(object sender, EventArgs args)
        {
            this.Close();
        }
        public void ManageSchedule_Add(object sender, EventArgs args)
        {
            //If there are no courses, return
            if (CourseManager.GetCourseCount() == 0)
            {
                MessageBox.Show("There are no courses.");
                return;
            }

            this.OverlayForm<MS_Add>(false, (context) =>
            {
                context.Show();
                RefreshGridView();
            });
        }
        public void ManageSchedule_Edit(object sender, EventArgs args)
        {
            //Return if no cell is selected
            if (!SelectedRow())
            {
                MessageBox.Show("Select a schedule first.");
                return;
            }

            //Set selected schedule
            MS_Edit.cSelectedSchedule = lcSchedules[SelectedRowIndex()];

            this.OverlayForm<MS_Edit>(false, (context) =>
            {
                context.Show();
                RefreshGridView();
            });
        }
        public void ManageSchedule_Delete(object sender, EventArgs args)
        {
            //Return if no cell is selected
            if (!SelectedRow())
            {
                MessageBox.Show("Select a schedule first.");
                return;
            }

            //Confirm if user wants to delete this record
            if (MessageBox.Show("Are you sure you want to delete this schedule?", "Deleting Schedule", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //Get the selected schedule info
                Course_Schedule selection = lcSchedules[SelectedRowIndex()];

                //Delete this selection
                selection.IsActive = false;
                SharedManager.Update(selection, s => s.IsActive);

                //Refresh
                RefreshGridView();

                MessageBox.Show("Deleted schedule.");
            }
        }
        #endregion

        #region Helpers
        public void RefreshGridView()
        {
            ClearGridView();
            FillGridView();
        }
        public void ClearGridView()
        {
            //Clear list
            lcSchedules = null;

            //Clear data grid view
            dgvSchedules.Rows.Clear();
            dgvSchedules.Refresh();
        }
        public void FillGridView()
        {
            //Get all schedules
            lcSchedules = ScheduleManager.GetAllSchedules();

            //For each entry, add to data grid view
            for (int i = 0; i < lcSchedules.Count; i++)
            {
                Course_Schedule curSchedule = lcSchedules[i];
                Course curCourse = curSchedule.GetCourse();
                User curTutor = curSchedule.GetTutor();
                dgvSchedules.Rows.Add(curSchedule.CourseSchedule_ID, curCourse.Course_Name, curTutor.FullName, curSchedule.DT_From, curSchedule.DT_To);
            }

            dgvSchedules.Refresh();
        }

        public bool SelectedRow()
        {
            return dgvSchedules.SelectedRows.Count > 0;
        }
        public int SelectedRowIndex()
        {
            return dgvSchedules.CurrentCell.RowIndex;
        }
        #endregion
    }
}
