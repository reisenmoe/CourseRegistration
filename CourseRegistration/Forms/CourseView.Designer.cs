namespace CourseRegistration
{
    partial class CourseView
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbCourses = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbCourseName = new System.Windows.Forms.Label();
            this.lbCourseCode = new System.Windows.Forms.Label();
            this.lbTutorName = new System.Windows.Forms.Label();
            this.lbStartDate = new System.Windows.Forms.Label();
            this.lbFinishDate = new System.Windows.Forms.Label();
            this.lbDescription = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lbTutorEmail = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "My courses";
            // 
            // cbCourses
            // 
            this.cbCourses.FormattingEnabled = true;
            this.cbCourses.Location = new System.Drawing.Point(80, 10);
            this.cbCourses.Name = "cbCourses";
            this.cbCourses.Size = new System.Drawing.Size(250, 21);
            this.cbCourses.TabIndex = 1;
            this.cbCourses.SelectedIndexChanged += new System.EventHandler(this.CourseView_OnSelectCourse);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Course name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Course code:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Course description:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Tutor name:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Start date:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 176);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Finish date:";
            // 
            // lbCourseName
            // 
            this.lbCourseName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCourseName.Location = new System.Drawing.Point(94, 61);
            this.lbCourseName.Name = "lbCourseName";
            this.lbCourseName.Size = new System.Drawing.Size(236, 13);
            this.lbCourseName.TabIndex = 8;
            this.lbCourseName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbCourseCode
            // 
            this.lbCourseCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCourseCode.Location = new System.Drawing.Point(92, 84);
            this.lbCourseCode.Name = "lbCourseCode";
            this.lbCourseCode.Size = new System.Drawing.Size(238, 13);
            this.lbCourseCode.TabIndex = 9;
            this.lbCourseCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbTutorName
            // 
            this.lbTutorName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTutorName.Location = new System.Drawing.Point(86, 107);
            this.lbTutorName.Name = "lbTutorName";
            this.lbTutorName.Size = new System.Drawing.Size(244, 13);
            this.lbTutorName.TabIndex = 10;
            this.lbTutorName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbStartDate
            // 
            this.lbStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbStartDate.Location = new System.Drawing.Point(78, 153);
            this.lbStartDate.Name = "lbStartDate";
            this.lbStartDate.Size = new System.Drawing.Size(252, 13);
            this.lbStartDate.TabIndex = 11;
            this.lbStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbFinishDate
            // 
            this.lbFinishDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbFinishDate.Location = new System.Drawing.Point(83, 176);
            this.lbFinishDate.Name = "lbFinishDate";
            this.lbFinishDate.Size = new System.Drawing.Size(247, 13);
            this.lbFinishDate.TabIndex = 12;
            this.lbFinishDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbDescription
            // 
            this.lbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDescription.Location = new System.Drawing.Point(119, 199);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(211, 51);
            this.lbDescription.TabIndex = 13;
            this.lbDescription.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(255, 263);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.CourseView_Close);
            // 
            // lbTutorEmail
            // 
            this.lbTutorEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTutorEmail.Location = new System.Drawing.Point(84, 130);
            this.lbTutorEmail.Name = "lbTutorEmail";
            this.lbTutorEmail.Size = new System.Drawing.Size(246, 13);
            this.lbTutorEmail.TabIndex = 15;
            this.lbTutorEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 130);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Tutor email:";
            // 
            // CourseView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 298);
            this.Controls.Add(this.lbTutorEmail);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbDescription);
            this.Controls.Add(this.lbFinishDate);
            this.Controls.Add(this.lbStartDate);
            this.Controls.Add(this.lbTutorName);
            this.Controls.Add(this.lbCourseCode);
            this.Controls.Add(this.lbCourseName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbCourses);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "CourseView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "My courses";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbCourses;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbCourseName;
        private System.Windows.Forms.Label lbCourseCode;
        private System.Windows.Forms.Label lbTutorName;
        private System.Windows.Forms.Label lbStartDate;
        private System.Windows.Forms.Label lbFinishDate;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbTutorEmail;
        private System.Windows.Forms.Label label9;
    }
}