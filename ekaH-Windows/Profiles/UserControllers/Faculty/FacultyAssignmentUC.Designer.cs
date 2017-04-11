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
            this.assignmentRTB = new System.Windows.Forms.RichTextBox();
            this.fontPanel = new System.Windows.Forms.Panel();
            this.colorButton = new System.Windows.Forms.Button();
            this.underlineButton = new System.Windows.Forms.Button();
            this.italicButton = new System.Windows.Forms.Button();
            this.boldButton = new System.Windows.Forms.Button();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.fontBox = new System.Windows.Forms.PictureBox();
            this.saveBox = new System.Windows.Forms.PictureBox();
            this.editBox = new System.Windows.Forms.PictureBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.projectName = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.weightTextBox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.deadlineBox = new MetroFramework.Controls.MetroDateTime();
            this.cancelBox = new System.Windows.Forms.PictureBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.fontPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fontBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saveBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cancelBox)).BeginInit();
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
            // underlineButton
            // 
            this.underlineButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.underlineButton.Location = new System.Drawing.Point(97, 4);
            this.underlineButton.Name = "underlineButton";
            this.underlineButton.Size = new System.Drawing.Size(40, 40);
            this.underlineButton.TabIndex = 0;
            this.underlineButton.Text = "U";
            this.underlineButton.UseVisualStyleBackColor = true;
            this.underlineButton.Click += new System.EventHandler(this.underlineButton_Click);
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
            this.italicButton.Click += new System.EventHandler(this.italicButton_Click);
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
            this.boldButton.Click += new System.EventHandler(this.boldButton_Click);
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
            // projectName
            // 
            this.projectName.BackColor = System.Drawing.Color.White;
            this.projectName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.projectName.Depth = 0;
            this.projectName.Enabled = false;
            this.projectName.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectName.Hint = "Project Name";
            this.projectName.Location = new System.Drawing.Point(81, 15);
            this.projectName.MouseState = MaterialSkin.MouseState.HOVER;
            this.projectName.Name = "projectName";
            this.projectName.PasswordChar = '\0';
            this.projectName.SelectedText = "";
            this.projectName.SelectionLength = 0;
            this.projectName.SelectionStart = 0;
            this.projectName.Size = new System.Drawing.Size(258, 23);
            this.projectName.TabIndex = 7;
            this.projectName.UseSystemPasswordChar = false;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel2.Location = new System.Drawing.Point(358, 13);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(74, 25);
            this.metroLabel2.TabIndex = 0;
            this.metroLabel2.Text = "Weight";
            // 
            // weightTextBox
            // 
            this.weightTextBox.BackColor = System.Drawing.Color.White;
            this.weightTextBox.Depth = 0;
            this.weightTextBox.Enabled = false;
            this.weightTextBox.Hint = "0-100";
            this.weightTextBox.Location = new System.Drawing.Point(438, 15);
            this.weightTextBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.weightTextBox.Name = "weightTextBox";
            this.weightTextBox.PasswordChar = '\0';
            this.weightTextBox.SelectedText = "";
            this.weightTextBox.SelectionLength = 0;
            this.weightTextBox.SelectionStart = 0;
            this.weightTextBox.Size = new System.Drawing.Size(70, 23);
            this.weightTextBox.TabIndex = 8;
            this.weightTextBox.UseSystemPasswordChar = false;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel3.Location = new System.Drawing.Point(539, 13);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(87, 25);
            this.metroLabel3.TabIndex = 0;
            this.metroLabel3.Text = "Deadline";
            // 
            // deadlineBox
            // 
            this.deadlineBox.Enabled = false;
            this.deadlineBox.Location = new System.Drawing.Point(632, 9);
            this.deadlineBox.MinimumSize = new System.Drawing.Size(0, 29);
            this.deadlineBox.Name = "deadlineBox";
            this.deadlineBox.Size = new System.Drawing.Size(176, 29);
            this.deadlineBox.TabIndex = 9;
            // 
            // cancelBox
            // 
            this.cancelBox.BackColor = System.Drawing.Color.Transparent;
            this.cancelBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancelBox.Image = global::ekaH_Windows.Properties.Resources.cancelIcon;
            this.cancelBox.Location = new System.Drawing.Point(814, 217);
            this.cancelBox.Name = "cancelBox";
            this.cancelBox.Size = new System.Drawing.Size(48, 48);
            this.cancelBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.cancelBox.TabIndex = 10;
            this.cancelBox.TabStop = false;
            this.cancelBox.Click += new System.EventHandler(this.cancelBox_Click);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel4.Location = new System.Drawing.Point(3, 456);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(116, 25);
            this.metroLabel4.TabIndex = 11;
            this.metroLabel4.Text = "Submissions";
            // 
            // FacultyAssignmentUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(234)))), ((int)(((byte)(200)))));
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.cancelBox);
            this.Controls.Add(this.deadlineBox);
            this.Controls.Add(this.weightTextBox);
            this.Controls.Add(this.projectName);
            this.Controls.Add(this.fontBox);
            this.Controls.Add(this.fontPanel);
            this.Controls.Add(this.saveBox);
            this.Controls.Add(this.editBox);
            this.Controls.Add(this.assignmentRTB);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Name = "FacultyAssignmentUC";
            this.Size = new System.Drawing.Size(867, 750);
            this.fontPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fontBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saveBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cancelBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
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
        private MaterialSkin.Controls.MaterialSingleLineTextField projectName;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MaterialSkin.Controls.MaterialSingleLineTextField weightTextBox;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroDateTime deadlineBox;
        private System.Windows.Forms.PictureBox cancelBox;
        private MetroFramework.Controls.MetroLabel metroLabel4;
    }
}
