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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();

            RefreshDashboard();
        }

        #region Button events
        #region Shared
        public void Dashboard_MyInfo(object sender, EventArgs args)
        {
            //Set target user object to modify
            EditUserInfo.cUser = GlobalApplication.cMyUser;

            this.SwitchFormTo<EditUserInfo>((context) =>
            {
                context.Show();
                RefreshDashboard();
            });
        }
        public void Dashboard_Logout(object sender, EventArgs args)
        {
            if (MessageBox.Show("Are you sure you want to log out?", "Dashboard", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        #endregion

        #region Students and Tutors
        public void Dashboard_MyCourse(object sender, EventArgs args)
        {
            if (GlobalApplication.emMyRole == CourseRegistration.RoleTypes.Tutor)
            {
                this.SwitchFormTo<ViewStudents>((context) =>
                {
                    context.Show();
                    RefreshDashboard();
                });
            }
            else
            {
                this.SwitchFormTo<CourseView>((context) =>
                {
                    context.Show();
                    RefreshDashboard();
                });
            }
        }
        #endregion

        #region Admins
        public void Dashboard_Faculty(object sender, EventArgs args)
        {
            this.SwitchFormTo<ManageFaculty>((context) =>
            {
                context.Show();
                RefreshDashboard();
            });
        }
        public void Dashboard_Schedule(object sender, EventArgs args)
        {
            this.SwitchFormTo<ManageSchedule>((context) =>
            {
                context.Show();
                RefreshDashboard();
            });
        }
        public void Dashboard_Course(object sender, EventArgs args)
        {
            this.SwitchFormTo<ManageCourse>((context) =>
            {
                context.Show();
                RefreshDashboard();
            });
        }
        public void Dashboard_ManageUser(object sender, EventArgs args)
        {
            this.SwitchFormTo<ManageUser>((context) =>
            {
                context.Show();
                RefreshDashboard();
            });
        }
        public void Dashboard_RegisterUser(object sender, EventArgs args)
        {
            this.SwitchFormTo<Registration>((context) =>
            {
                context.Show();
                RefreshDashboard();
            });
        }
        #endregion
        #endregion

        #region Helpers
        public void RefreshDashboard()
        {
            //Change view based on role type
            pAdmin.Visible = GlobalApplication.emMyRole == CourseRegistration.RoleTypes.Admin;
            pNonAdmin.Visible = GlobalApplication.emMyRole != CourseRegistration.RoleTypes.Admin;

            //Set welcome message
            lbWelcome.Text = "Welcome, " + GlobalApplication.cMyUser.FirstName;
        }
        #endregion

    }
}
