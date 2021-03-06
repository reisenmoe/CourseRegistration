﻿using System;
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
    public partial class Registration : Form
    {
        private List<Role> lcRoles;


        public Registration()
        {
            InitializeComponent();

            //Get all roles
            lcRoles = RoleManager.GetAllRoles();
            //Populate combo box items
            for (int i = 0; i < lcRoles.Count; i++)
            {
                cbRole.Items.Add(lcRoles[i].Role_Name);
            }
            //Set first selection
            cbRole.SelectedIndex = 0;
        }

        #region Button events
        public void Registration_Save(object sender, EventArgs args)
        {
            //Action for invalid inputs
            Action<string> showMessage = (message) =>
            {
                MessageBox.Show(message);
            };

        
            #region Checker
            if (UserManager.Exists(tbStudentID.Text) != null)
            {
                showMessage("This student ID already exists.");
                return;
            }
            if (string.IsNullOrEmpty(tbStudentID.Text))
            {
                showMessage("Username is a required field.");
                return;
            }
            if (string.IsNullOrEmpty(tbPassword.Text))
            {
                showMessage("Password is a required field..");
                return;
            }
            if (string.IsNullOrEmpty(tbFirstName.Text))
            {
                showMessage("First name is a required field..");
                return;
            }
            if (string.IsNullOrEmpty(tbLastName.Text))
            {
                showMessage("Last name is a required field.");
                return;
            }
            if (string.IsNullOrEmpty(tbContact.Text))
            {
                showMessage("Contact number is a required field.");
                return;
            }
            if (string.IsNullOrEmpty(tbAddress.Text))
            {
                showMessage("Address is a required field.");
                return;
            }
            if (string.IsNullOrEmpty(tbEmail.Text))
            {
                showMessage("Email is a required field.");
                return;
            }
            if (string.IsNullOrEmpty(dtpDateOfBirth.Text))
            {
                showMessage("Date of birth is a required field.");
                return;
            }
            #endregion

            //Create new user
            User user = new User();
            user.Address = tbAddress.Text;
            user.ContactNumber = tbContact.Text;
            user.CreatedBy = GlobalApplication.cMyUser.User_ID;
            user.DateOfBirth = dtpDateOfBirth.Value;
            user.Email = tbEmail.Text;
            user.FirstName = tbFirstName.Text;
            user.LastName = tbLastName.Text;
            user.FullName = user.FirstName + ' ' + user.LastName;
            user.ModifiedBy = user.CreatedBy;
            user.Password = Renko.MD5Encryption.Encrypt(tbPassword.Text);
            user.Student_ID = tbStudentID.Text;
            //Get created user
            user = UserManager.Create(user);
            //If failed, show message
            if (user == null)
            {
                showMessage("Failed to create a new user.");
                return;
            }

            //Create new user_role
            User_Role ur = new User_Role();
            ur.CreatedBy = GlobalApplication.cMyUser.User_ID;
            ur.ModifiedBy = ur.CreatedBy;
            ur.Role_ID = lcRoles[cbRole.SelectedIndex].Role_ID; ;
            ur.User_ID = user.User_ID;
            //Get created user_role
            ur = UserRoleManager.Create(ur);
            //If failed, show message and delete user
            if (ur == null)
            {
                UserManager.Delete(user);
                showMessage("Failed to create a user_role");
                return;
            }

            //Show message
            MessageBox.Show("Successfully registered a new user: " + user.Student_ID);

            //Clear inputs
            ClearInputs();
        }
        public void Registration_Close(object sender, EventArgs args)
        {
            this.Close();
        }
        #endregion

        #region Helper
        public void ClearInputs()
        {
            tbStudentID.Text = null;
            tbPassword.Text = null;
            tbFirstName.Text = null;
            tbLastName.Text = null;
            tbContact.Text = null;
            tbAddress.Text = null;
            tbEmail.Text = null;
            dtpDateOfBirth.Value = DateTime.Now;
            cbRole.SelectedIndex = 0;
        }
        #endregion
    }
}
