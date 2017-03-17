using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseRegistration
{
    public partial class MC_Edit : Form
    {
        public static Course cSelectedCourse;

        private List<Faculty> lcFaculties;


        public MC_Edit()
        {
            InitializeComponent();

            //Fill faculties
            FillFaculty();

            //Set initial values
            tbName.Text = cSelectedCourse.Course_Name;
            tbCode.Text = cSelectedCourse.Course_Code;
            tbDescription.Text = cSelectedCourse.Course_Description;
        }

        #region Button events
        public void Edit(object sender, EventArgs args)
        {
            #region Validate inputs
            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("Type in the course name.");
                return;
            }
            if (string.IsNullOrEmpty(tbCode.Text))
            {
                MessageBox.Show("Type in the course code.");
                return;
            }
            if (string.IsNullOrEmpty(tbDescription.Text))
            {
                MessageBox.Show("Type in the couse description");
                return;
            }
            #endregion

            //Update course
            cSelectedCourse.Course_Code = tbCode.Text;
            cSelectedCourse.Course_Description = tbDescription.Text;
            cSelectedCourse.Course_Name = tbName.Text;
            cSelectedCourse.Faculty_ID = lcFaculties[cbFaculty.SelectedIndex].Faculty_ID;
            cSelectedCourse.ModifiedDateTime = DateTime.Now;
            SharedManager.Update(cSelectedCourse, c => c.Course_Code, c => c.Course_Description, c => c.Course_Name, c => c.Faculty_ID, c => c.ModifiedDateTime);
            
            MessageBox.Show("Updated course.");

            this.Close();
        }
        public void Close(object sender, EventArgs args)
        {
            this.Close();
        }
        #endregion

        #region Helpers
        public void FillFaculty()
        {
            //Clear all items
            lcFaculties = null;
            cbFaculty.Items.Clear();

            //Get list of all faculties
            lcFaculties = FacultyManager.GetAll();

            //Fill items
            for (int i = 0; i < lcFaculties.Count; i++)
            {
                cbFaculty.Items.Add(lcFaculties[i].Faculty_Name);

                //Select initial item
                if(lcFaculties[i].Faculty_ID.Equals(cSelectedCourse.Faculty_ID))
                {
                    cbFaculty.SelectedIndex = i;
                }
            }

            cbFaculty.Refresh();
        }
        #endregion
    }
}
