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
    public partial class ManageUser : Form
    {
        private List<User> lcUsers;
        private List<Role> lcRoles;


        public ManageUser()
        {
            InitializeComponent();

            //Set columns
            dgvUsers.Columns.Add("Id", "Id");
            dgvUsers.Columns.Add("Full Name", "Full Name");
            dgvUsers.Columns.Add("Role", "Role");
            dgvUsers.Columns.Add("Email", "Email");
            dgvUsers.Columns.Add("Contact", "Contact");
            dgvUsers.ToggleColumnSort(false);

            //Fill roles
            FillRoles();
            //Fill users
            FillUsers();
        }

        #region Button events
        public void ManageUser_Search(object sender, EventArgs args)
        {
            //Fill users
            FillUsers();
        }
        public void ManageUser_Edit(object sender, EventArgs args)
        {
            //Return if no user was selected
            if (!dgvUsers.SelectedRow())
            {
                MessageBox.Show("Select a user.");
                return;
            }

            //Set target user object to edit
            EditUserInfo.cUser = lcUsers[dgvUsers.SelectedRowIndex()];

            this.SwitchFormTo<EditUserInfo>((context) =>
            {
                context.Show();
                //Refresh users
                FillUsers();
            });
        }

        public void ManageUser_Delete(object sender, EventArgs args)
        {
            if (MessageBox.Show("Are you sure you want to delete this user?", "Delete user", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //Soft delete this user
                User user = lcUsers[dgvUsers.SelectedRowIndex()];
                user.IsActive = false;
                SharedManager.Update(user, u => u.IsActive);

                MessageBox.Show("Deleted user.");

                FillUsers();
            }
        }
        public void ManageUser_Close(object sender, EventArgs args)
        {
            this.Close();
        }
        #endregion

        #region Helpers
        public void FillRoles()
        {
            //Clear roles
            lcRoles = null;
            cbRole.Items.Clear();

            //Get all roles
            lcRoles = RoleManager.GetAllRoles();

            //Only if there are any roles
            if (lcRoles.Count > 0)
            {
                //Fill combo box
                for (int i = 0; i < lcRoles.Count; i++)
                {
                    cbRole.Items.Add(lcRoles[i].Role_Name);
                }

                //Set first selection
                cbRole.SelectedIndex = 0;
            }

            //Refresh
            cbRole.Refresh();
        }
        public void FillUsers()
        {
            //Clear users
            lcUsers = null;
            dgvUsers.Rows.Clear();

            //Filters
            string filter = tbSearch.Text;
            Role role = lcRoles[cbRole.SelectedIndex];
            //Find users
            if (string.IsNullOrEmpty(filter))
                lcUsers = UserManager.GetAllUsers(role.GetRoleType());
            else
                lcUsers = UserManager.GetAllUsers(role.GetRoleType(), filter);

            //Fill data grid view
            for (int i = 0; i < lcUsers.Count; i++)
            {
                User curUser = lcUsers[i];
                Role curRole = curUser.GetRole();
                dgvUsers.Rows.Add(curUser.User_ID, curUser.FullName, curRole.Role_Name, curUser.Email, curUser.ContactNumber);
            }

            //Set result count
            lbResults.Text = "Results: " + lcUsers.Count;

            //Refresh users
            dgvUsers.Refresh();
        }
        #endregion
    }
}
