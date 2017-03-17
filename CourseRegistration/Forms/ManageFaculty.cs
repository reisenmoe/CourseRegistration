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
    public partial class ManageFaculty : Form
    {
        private List<Faculty> lcFaculties;


        public ManageFaculty()
        {
            InitializeComponent();
            
            //Populate the grid view
            PopulateGridView();
        }

        #region Button events
        public void ManageFaculty_Create(object sender, EventArgs args)
        {
            //Return if invalid input
            if(string.IsNullOrEmpty(tbNewFaculty.Text))
            {
                MessageBox.Show("Please check your new faculty name.");
                return;
            }

            //Create new faculty
            Faculty faculty = new Faculty();
            faculty.CreatedBy = GlobalApplication.cMyUser.User_ID;
            faculty.ModifiedBy = faculty.CreatedBy;
            faculty.Faculty_Name = tbNewFaculty.Text;
            //Apply to db
            faculty = FacultyManager.Create(faculty);
            //If failed
            if(faculty == null)
            {
                MessageBox.Show("Failed to create new faculty.");
                return;
            }

            //Reset new faculty name input
            tbNewFaculty.Text = null;

            //Reload data grid view
            ReloadGridView();

            //Show message
            MessageBox.Show("Successfully created new faculty: " + faculty.Faculty_Name);
        }

        public void ManageFaculty_OnSelectRow(object sender, EventArgs args)
        {
            //Get index of selected row
            int selectedInx = SelectedRowIndex();

            //Set current faculty's name to the text box
            tbSelected.Text = lcFaculties[selectedInx].Faculty_Name;
        }
        public void ManageFaculty_ChangeName(object sender, EventArgs args)
        {
            //Return if invalid input
            if(string.IsNullOrEmpty(tbSelected.Text))
            {
                MessageBox.Show("Pleach check your faculty name.");
                return;
            }

            //Change the name of the selected row
            Faculty targetFaculty = lcFaculties[SelectedRowIndex()];
            targetFaculty.Faculty_Name = tbSelected.Text;
            SharedManager.Update(targetFaculty, f => f.Faculty_Name);

            //Show message
            MessageBox.Show("Successfully updated faculty name: " + targetFaculty.Faculty_Name);

            //Reload grid view
            ReloadGridView();
        }
        public void ManageFaculty_Delete(object sender, EventArgs args)
        {
            //Return if only one count
            if(lcFaculties.Count == 1)
            {
                MessageBox.Show("There must be at least one faculty.");
                return;
            }

            //Delete the selected row
            Faculty targetFaculty = lcFaculties[SelectedRowIndex()];
            targetFaculty.IsActive = false;
            SharedManager.Update(targetFaculty, f => f.IsActive);

            //Show message
            MessageBox.Show("Successfully deleted faculty: " + targetFaculty.Faculty_Name);

            //Reload grid view
            ReloadGridView();
        }

        public void ManageFaculty_Close(object sender, EventArgs args)
        {
            this.Close();
        }
        #endregion

        #region Helpers
        public int SelectedRowIndex()
        {
            return dgvFaculties.CurrentCell.RowIndex;
        }

        public void ReloadGridView()
        {
            ClearGridView();
            PopulateGridView();
        }
        public void ClearGridView()
        {
            dgvFaculties.Columns.Clear();
            dgvFaculties.Rows.Clear();
            dgvFaculties.Refresh();
        }
        public void PopulateGridView()
        {
            //Get all faculties
            lcFaculties = FacultyManager.GetAll();

            //Add column
            dgvFaculties.Columns.Add("FacultyID", "Faculty ID");
            dgvFaculties.Columns.Add("FacultyName", "Faculty name");
            dgvFaculties.ToggleColumnSort(false);

            //Add rows
            for(int i=0; i<lcFaculties.Count; i++)
            {
                dgvFaculties.Rows.Add(lcFaculties[i].Faculty_ID, lcFaculties[i].Faculty_Name);
            }

            //Refresh grid view
            dgvFaculties.Refresh();
        }
        #endregion
    }
}
