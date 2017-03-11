using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess;

namespace CourseRegistration
{
    public partial class MyInfo : Form
    {
        public MyInfo()
        {
            InitializeComponent();

            //Set initial values
            tbFirstName.Text = GlobalApplication.cMyUser.FirstName;
            tbLastName.Text = GlobalApplication.cMyUser.LastName;
            tbContact.Text = GlobalApplication.cMyUser.ContactNumber;
            tbAddress.Text = GlobalApplication.cMyUser.Address;
            dtpDateOfBirth.Value = GlobalApplication.cMyUser.DateOfBirth.Value;
        }

        #region Button events
        public void MyInfo_Save(object sender, EventArgs args)
        {
            //Define action for invalid results
            Action<string> onInvalidInput = (message) =>
            {
                MessageBox.Show(message);
            };

            #region Checkers
            //Check if any invalid inputs
            if(string.IsNullOrEmpty(tbFirstName.Text))
            {
                onInvalidInput("Please check your first name.");
                return;
            }
            if (string.IsNullOrEmpty(tbLastName.Text))
            {
                onInvalidInput("Please check your last name.");
                return;
            }
            if (string.IsNullOrEmpty(tbContact.Text))
            {
                onInvalidInput("Please check your contact number.");
                return;
            }
            if (string.IsNullOrEmpty(tbAddress.Text))
            {
                onInvalidInput("Please check your address.");
                return;
            }
            if (string.IsNullOrEmpty(tbEmail.Text))
            {
                onInvalidInput("Please check your email.");
                return;
            }
            if (string.IsNullOrEmpty(dtpDateOfBirth.Text))
            {
                onInvalidInput("Please check your date of birth.");
                return;
            }
            #endregion

            //Set input values to myUser
            GlobalApplication.cMyUser.FirstName = tbFirstName.Text;
            GlobalApplication.cMyUser.LastName = tbLastName.Text;
            GlobalApplication.cMyUser.FullName = tbFirstName.Text + ' ' + tbLastName.Text;
            GlobalApplication.cMyUser.ContactNumber = tbContact.Text;
            GlobalApplication.cMyUser.Address = tbAddress.Text;
            GlobalApplication.cMyUser.DateOfBirth = dtpDateOfBirth.Value;

            //Modified
            GlobalApplication.cMyUser.ModifiedBy = GlobalApplication.cMyUser.User_ID;
            GlobalApplication.cMyUser.ModifiedDateTime = DateTime.Now;

            //Update
            SharedManager.Update(GlobalApplication.cMyUser,
                                u => u.FirstName, u => u.LastName, u => u.FullName,
                                u => u.ContactNumber, u => u.Address, u => u.DateOfBirth);
        }
        public void MyInfo_Close(object sender, EventArgs args)
        {
            //Just close the form
            this.Close();
        }
        #endregion
    }
}
