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
    public partial class MC_Add : Form
    {
        private List<Faculty> lcFaculties;


        public MC_Add()
        {
            InitializeComponent();

            //Fill faculty
            FillFaculty();
        }

        #region Button events
        public void Add(object sender, EventArgs args)
        {
            #region Validate inputs
            if(string.IsNullOrEmpty(tbName.Text))
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

            //Create new course
            Course course = new Course();
            course.Course_Code = tbCode.Text;
            course.Course_Description = tbDescription.Text;
            course.Course_Name = tbName.Text;
            course.CreatedBy = GlobalApplication.cMyUser.User_ID;
            course.Faculty_ID = lcFaculties[cbFaculty.SelectedIndex].Faculty_ID;
            course.ModifiedBy = GlobalApplication.cMyUser.User_ID;

            //Add to DB
            CourseManager.Create(course);

            MessageBox.Show("Added new course.");

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
            }

            //Select the first item
            cbFaculty.SelectedIndex = 0;

            cbFaculty.Refresh();
        }
        #endregion
    }
}
