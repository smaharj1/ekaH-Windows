namespace ekaH_Windows.Profiles.UserControllers.Student
{
    partial class StudentAssignmentUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.deadlineBox = new MetroFramework.Controls.MetroDateTime();
            this.assignmentRTB = new System.Windows.Forms.RichTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.projectName = new MetroFramework.Controls.MetroLabel();
            this.weightTextBox = new MetroFramework.Controls.MetroLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel4.Location = new System.Drawing.Point(3, 449);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(116, 25);
            this.metroLabel4.TabIndex = 24;
            this.metroLabel4.Text = "Submissions";
            // 
            // deadlineBox
            // 
            this.deadlineBox.Enabled = false;
            this.deadlineBox.Location = new System.Drawing.Point(632, 11);
            this.deadlineBox.MinimumSize = new System.Drawing.Size(0, 29);
            this.deadlineBox.Name = "deadlineBox";
            this.deadlineBox.Size = new System.Drawing.Size(232, 29);
            this.deadlineBox.TabIndex = 22;
            // 
            // assignmentRTB
            // 
            this.assignmentRTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(234)))), ((int)(((byte)(200)))));
            this.assignmentRTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.assignmentRTB.Enabled = false;
            this.assignmentRTB.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.assignmentRTB.Location = new System.Drawing.Point(0, 57);
            this.assignmentRTB.Name = "assignmentRTB";
            this.assignmentRTB.Size = new System.Drawing.Size(864, 374);
            this.assignmentRTB.TabIndex = 15;
            this.assignmentRTB.Text = "";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel3.Location = new System.Drawing.Point(539, 15);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(87, 25);
            this.metroLabel3.TabIndex = 12;
            this.metroLabel3.Text = "Deadline";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel2.Location = new System.Drawing.Point(358, 15);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(74, 25);
            this.metroLabel2.TabIndex = 13;
            this.metroLabel2.Text = "Weight";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(3, 15);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(72, 25);
            this.metroLabel1.TabIndex = 14;
            this.metroLabel1.Text = "Project";
            // 
            // projectName
            // 
            this.projectName.AutoSize = true;
            this.projectName.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.projectName.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.projectName.Location = new System.Drawing.Point(0, 0);
            this.projectName.Name = "projectName";
            this.projectName.Size = new System.Drawing.Size(59, 25);
            this.projectName.TabIndex = 25;
            this.projectName.Text = "Name";
            // 
            // weightTextBox
            // 
            this.weightTextBox.AutoSize = true;
            this.weightTextBox.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.weightTextBox.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.weightTextBox.Location = new System.Drawing.Point(438, 15);
            this.weightTextBox.Name = "weightTextBox";
            this.weightTextBox.Size = new System.Drawing.Size(59, 25);
            this.weightTextBox.TabIndex = 25;
            this.weightTextBox.Text = "Name";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.projectName);
            this.panel1.Location = new System.Drawing.Point(81, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(262, 25);
            this.panel1.TabIndex = 26;
            // 
            // StudentAssignmentUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.weightTextBox);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.deadlineBox);
            this.Controls.Add(this.assignmentRTB);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Name = "StudentAssignmentUC";
            this.Size = new System.Drawing.Size(867, 750);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroDateTime deadlineBox;
        private System.Windows.Forms.RichTextBox assignmentRTB;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel projectName;
        private MetroFramework.Controls.MetroLabel weightTextBox;
        private System.Windows.Forms.Panel panel1;
    }
}
