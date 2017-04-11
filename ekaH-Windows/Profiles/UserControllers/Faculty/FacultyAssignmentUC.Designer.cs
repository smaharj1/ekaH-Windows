namespace ekaH_Windows.Profiles.UserControllers.Faculty
{
    partial class FacultyAssignmentUC
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
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.projectName = new MetroFramework.Controls.MetroLabel();
            this.assignmentRTB = new System.Windows.Forms.RichTextBox();
            this.fontPanel = new System.Windows.Forms.Panel();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.fontBox = new System.Windows.Forms.PictureBox();
            this.saveBox = new System.Windows.Forms.PictureBox();
            this.editBox = new System.Windows.Forms.PictureBox();
            this.boldButton = new System.Windows.Forms.Button();
            this.italicButton = new System.Windows.Forms.Button();
            this.underlineButton = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.colorButton = new System.Windows.Forms.Button();
            this.fontPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fontBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saveBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editBox)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(3, 13);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(72, 25);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Project";
            // 
            // projectName
            // 
            this.projectName.AutoSize = true;
            this.projectName.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.projectName.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.projectName.Location = new System.Drawing.Point(81, 13);
            this.projectName.Name = "projectName";
            this.projectName.Size = new System.Drawing.Size(0, 0);
            this.projectName.TabIndex = 1;
            // 
            // assignmentRTB
            // 
            this.assignmentRTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(234)))), ((int)(((byte)(200)))));
            this.assignmentRTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.assignmentRTB.Enabled = false;
            this.assignmentRTB.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.assignmentRTB.Location = new System.Drawing.Point(0, 55);
            this.assignmentRTB.Name = "assignmentRTB";
            this.assignmentRTB.Size = new System.Drawing.Size(808, 374);
            this.assignmentRTB.TabIndex = 2;
            this.assignmentRTB.Text = "";
            // 
            // fontPanel
            // 
            this.fontPanel.BackColor = System.Drawing.Color.Transparent;
            this.fontPanel.Controls.Add(this.colorButton);
            this.fontPanel.Controls.Add(this.underlineButton);
            this.fontPanel.Controls.Add(this.italicButton);
            this.fontPanel.Controls.Add(this.boldButton);
            this.fontPanel.Location = new System.Drawing.Point(358, 435);
            this.fontPanel.Name = "fontPanel";
            this.fontPanel.Size = new System.Drawing.Size(202, 46);
            this.fontPanel.TabIndex = 5;
            this.fontPanel.Visible = false;
            // 
            // fontBox
            // 
            this.fontBox.BackColor = System.Drawing.Color.Transparent;
            this.fontBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.fontBox.Image = global::ekaH_Windows.Properties.Resources.fontIcon;
            this.fontBox.Location = new System.Drawing.Point(814, 109);
            this.fontBox.Name = "fontBox";
            this.fontBox.Size = new System.Drawing.Size(48, 48);
            this.fontBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.fontBox.TabIndex = 6;
            this.fontBox.TabStop = false;
            this.fontBox.Visible = false;
            this.fontBox.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // saveBox
            // 
            this.saveBox.BackColor = System.Drawing.Color.Transparent;
            this.saveBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveBox.Image = global::ekaH_Windows.Properties.Resources.saveIcon;
            this.saveBox.Location = new System.Drawing.Point(814, 163);
            this.saveBox.Name = "saveBox";
            this.saveBox.Size = new System.Drawing.Size(48, 48);
            this.saveBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.saveBox.TabIndex = 4;
            this.saveBox.TabStop = false;
            this.saveBox.Visible = false;
            this.saveBox.Click += new System.EventHandler(this.saveBox_Click);
            // 
            // editBox
            // 
            this.editBox.BackColor = System.Drawing.Color.Transparent;
            this.editBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.editBox.Image = global::ekaH_Windows.Properties.Resources.editIcon;
            this.editBox.Location = new System.Drawing.Point(814, 55);
            this.editBox.Name = "editBox";
            this.editBox.Size = new System.Drawing.Size(48, 48);
            this.editBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.editBox.TabIndex = 3;
            this.editBox.TabStop = false;
            this.editBox.Click += new System.EventHandler(this.editBox_Click);
            // 
            // boldButton
            // 
            this.boldButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boldButton.Location = new System.Drawing.Point(4, 4);
            this.boldButton.Name = "boldButton";
            this.boldButton.Size = new System.Drawing.Size(40, 40);
            this.boldButton.TabIndex = 0;
            this.boldButton.Text = "B";
            this.boldButton.UseVisualStyleBackColor = true;
            // 
            // italicButton
            // 
            this.italicButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.italicButton.Location = new System.Drawing.Point(50, 4);
            this.italicButton.Name = "italicButton";
            this.italicButton.Size = new System.Drawing.Size(40, 40);
            this.italicButton.TabIndex = 0;
            this.italicButton.Text = "I";
            this.italicButton.UseVisualStyleBackColor = true;
            // 
            // underlineButton
            // 
            this.underlineButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.underlineButton.Location = new System.Drawing.Point(97, 4);
            this.underlineButton.Name = "underlineButton";
            this.underlineButton.Size = new System.Drawing.Size(40, 40);
            this.underlineButton.TabIndex = 0;
            this.underlineButton.Text = "U";
            this.underlineButton.UseVisualStyleBackColor = true;
            // 
            // colorButton
            // 
            this.colorButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(51)))), ((int)(((byte)(64)))));
            this.colorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colorButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorButton.Location = new System.Drawing.Point(146, 4);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(40, 39);
            this.colorButton.TabIndex = 0;
            this.colorButton.UseVisualStyleBackColor = false;
            this.colorButton.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // FacultyAssignmentUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(234)))), ((int)(((byte)(200)))));
            this.Controls.Add(this.fontBox);
            this.Controls.Add(this.fontPanel);
            this.Controls.Add(this.saveBox);
            this.Controls.Add(this.editBox);
            this.Controls.Add(this.assignmentRTB);
            this.Controls.Add(this.projectName);
            this.Controls.Add(this.metroLabel1);
            this.Name = "FacultyAssignmentUC";
            this.Size = new System.Drawing.Size(867, 712);
            this.fontPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fontBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saveBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel projectName;
        private System.Windows.Forms.RichTextBox assignmentRTB;
        private System.Windows.Forms.PictureBox editBox;
        private System.Windows.Forms.PictureBox saveBox;
        private System.Windows.Forms.Panel fontPanel;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.PictureBox fontBox;
        private System.Windows.Forms.Button colorButton;
        private System.Windows.Forms.Button underlineButton;
        private System.Windows.Forms.Button italicButton;
        private System.Windows.Forms.Button boldButton;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}
