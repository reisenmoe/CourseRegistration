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
                this.Text = "My information";
            }
            else
            {
                this.Text = cUser.FirstName + "'s information";
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
            MessageBox.Show("Profile updated.");
        }
        public void MyInfo_Close(object sender, EventArgs args)
        {
            //Just close the form
            this.Close();
        }
        #endregion
    }
}
