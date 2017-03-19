namespace CourseRegistration
{
    partial class Dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lbWelcome = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.pAdmin = new System.Windows.Forms.Panel();
            this.pNonAdmin = new System.Windows.Forms.Panel();
            this.button9 = new System.Windows.Forms.Button();
            this.pAdmin.SuspendLayout();
            this.pNonAdmin.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(308, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "My information";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Dashboard_MyInfo);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(0, 29);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "My courses";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Dashboard_MyCourse);
            // 
            // lbWelcome
            // 
            this.lbWelcome.AutoSize = true;
            this.lbWelcome.Location = new System.Drawing.Point(12, 17);
            this.lbWelcome.Name = "lbWelcome";
            this.lbWelcome.Size = new System.Drawing.Size(92, 13);
            this.lbWelcome.TabIndex = 2;
            this.lbWelcome.Text = "Welcome, {name}";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(130, 58);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(120, 23);
            this.button5.TabIndex = 5;
            this.button5.Text = "Register users";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Dashboard_RegisterUser);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(130, 29);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(120, 23);
            this.button6.TabIndex = 6;
            this.button6.Text = "Manage users";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.Dashboard_ManageUser);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(0, 58);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(120, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "Manage courses";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Dashboard_Course);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(0, 29);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(120, 23);
            this.button7.TabIndex = 8;
            this.button7.Text = "Manage schedules";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.Dashboard_Schedule);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(0, 0);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(120, 23);
            this.button8.TabIndex = 9;
            this.button8.Text = "Manage faculty";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.Dashboard_Faculty);
            // 
            // pAdmin
            // 
            this.pAdmin.Controls.Add(this.button4);
            this.pAdmin.Controls.Add(this.button8);
            this.pAdmin.Controls.Add(this.button5);
            this.pAdmin.Controls.Add(this.button7);
            this.pAdmin.Controls.Add(this.button6);
            this.pAdmin.Location = new System.Drawing.Point(178, 77);
            this.pAdmin.Name = "pAdmin";
            this.pAdmin.Size = new System.Drawing.Size(250, 81);
            this.pAdmin.TabIndex = 10;
            // 
            // pNonAdmin
            // 
            this.pNonAdmin.Controls.Add(this.button2);
            this.pNonAdmin.Location = new System.Drawing.Point(12, 106);
            this.pNonAdmin.Name = "pNonAdmin";
            this.pNonAdmin.Size = new System.Drawing.Size(120, 52);
            this.pNonAdmin.TabIndex = 11;
            // 
            // button9
            // 
            this.button9.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button9.Location = new System.Drawing.Point(308, 41);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(120, 23);
            this.button9.TabIndex = 12;
            this.button9.Text = "Log out";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.Dashboard_Logout);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button9;
            this.ClientSize = new System.Drawing.Size(440, 170);
            this.ControlBox = false;
            this.Controls.Add(this.button9);
            this.Controls.Add(this.pNonAdmin);
            this.Controls.Add(this.pAdmin);
            this.Controls.Add(this.lbWelcome);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.pAdmin.ResumeLayout(false);
            this.pNonAdmin.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lbWelcome;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Panel pAdmin;
        private System.Windows.Forms.Panel pNonAdmin;
        private System.Windows.Forms.Button button9;
    }
}