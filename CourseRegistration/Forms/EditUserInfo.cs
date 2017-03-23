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
    public partial class EditUserInfo : Form
    {
        public static User cUser;


        public EditUserInfo()
        {
            InitializeComponent();

            //If editing my info
            if (cUser == GlobalApplication.cMyUser)
            {
                this.Text = "My Profile";
            }
            else
            {
                this.Text = cUser.FirstName + "'s Profile";
            }

            //Set initial values
            tbFirstName.Text = cUser.FirstName;
            tbLastName.Text = cUser.LastName;
            tbContact.Text = cUser.ContactNumber;
            tbAddress.Text = cUser.Address;
            tbEmail.Text = cUser.Email;
            dtpDateOfBirth.Value = cUser.DateOfBirth.Value;
        }

        #region Button events
        public void MyInfo_Save(object sender, EventArgs args)
        {
            //Define action for invalid results
            Action<string> onInvalidInput = (message) =>
            {
                MessageBox.Show(message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            #region Checkers
            //Check if any invalid inputs
            if(string.IsNullOrEmpty(tbFirstName.Text))
            {
                onInvalidInput("First name is a required field.");
                return;
            }
            if (string.IsNullOrEmpty(tbLastName.Text))
            {
                onInvalidInput("Last name is a required field.");
                return;
            }
            if (string.IsNullOrEmpty(tbContact.Text))
            {
                onInvalidInput("Contact number is a required field.");
                return;
            }
            if (string.IsNullOrEmpty(tbAddress.Text))
            {
                onInvalidInput("Address is a required field.");
                return;
            }
            if (string.IsNullOrEmpty(tbEmail.Text))
            {
                //add validation on email
                onInvalidInput("Email is a required field.");
                return;
            }
            if (string.IsNullOrEmpty(dtpDateOfBirth.Text))
            {
                onInvalidInput("Date of birth is a required field.");
                return;
            }
            #endregion

            //Set input values to myUser
            cUser.FirstName = tbFirstName.Text;
            cUser.LastName = tbLastName.Text;
            cUser.FullName = tbFirstName.Text + ' ' + tbLastName.Text;
            cUser.ContactNumber = tbContact.Text;
            cUser.Address = tbAddress.Text;
            cUser.DateOfBirth = dtpDateOfBirth.Value;

            //Modified
            cUser.ModifiedBy = GlobalApplication.cMyUser.User_ID;
            cUser.ModifiedDateTime = DateTime.Now;

            //Update
            SharedManager.Update(cUser,
                                u => u.FirstName, u => u.LastName, u => u.FullName,
                                u => u.ContactNumber, u => u.Address, u => u.DateOfBirth);

            //Show message
            MessageBox.Show("Profile updated successfully.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void MyInfo_Close(object sender, EventArgs args)
        {
            //Just close the form
            this.Close();
        }
        #endregion
    }
}
