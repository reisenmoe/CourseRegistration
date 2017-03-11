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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            
        }

        public void Login_Login(object sender, EventArgs args)
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;
            
            //Try logging in
            User user = UserManager.Login(username, password);
            //If failed logging in
            if(user == null)
            {
                MessageBox.Show("Failed to login. Check your username or password");
                return;
            }

            //Store current user
            GlobalApplication.cMyUser = user;
            //Store current role
            GlobalApplication.emMyRole = UserManager.GetRoleOf(user);

            //Hide this form and open main menu form
            this.SwitchFormTo<Dashboard>((form) =>
            {
                form.Show();
            });
        }
    }
}
