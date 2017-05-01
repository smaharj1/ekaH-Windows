namespace ekaH_Windows
{
    partial class Signup
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.faculty = new System.Windows.Forms.Label();
            this.student = new System.Windows.Forms.Label();
            this.signinLabel = new System.Windows.Forms.Label();
            this.emailText = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.password1 = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.password2 = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.firstNameText = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lastNameText = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.extraInfoText = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.registerTile = new MetroFramework.Controls.MetroTile();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.faculty);
            this.panel1.Controls.Add(this.student);
            this.panel1.Location = new System.Drawing.Point(90, 266);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(301, 27);
            this.panel1.TabIndex = 8;
            // 
            // faculty
            // 
            this.faculty.Cursor = System.Windows.Forms.Cursors.Hand;
            this.faculty.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.faculty.ForeColor = System.Drawing.Color.Gray;
            this.faculty.Location = new System.Drawing.Point(154, -1);
            this.faculty.Name = "faculty";
            this.faculty.Size = new System.Drawing.Size(144, 26);
            this.faculty.TabIndex = 3;
            this.faculty.Text = "Faculty";
            this.faculty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.faculty.Click += new System.EventHandler(this.Faculty_Click);
            // 
            // student
            // 
            this.student.BackColor = System.Drawing.Color.SkyBlue;
            this.student.Cursor = System.Windows.Forms.Cursors.Hand;
            this.student.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.student.ForeColor = System.Drawing.Color.Gray;
            this.student.Location = new System.Drawing.Point(1, 0);
            this.student.Name = "student";
            this.student.Size = new System.Drawing.Size(153, 26);
            this.student.TabIndex = 2;
            this.student.Text = "Student";
            this.student.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.student.Click += new System.EventHandler(this.Student_Click);
            // 
            // signinLabel
            // 
            this.signinLabel.AutoSize = true;
            this.signinLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.signinLabel.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signinLabel.ForeColor = System.Drawing.Color.Gray;
            this.signinLabel.Location = new System.Drawing.Point(112, 542);
            this.signinLabel.Name = "signinLabel";
            this.signinLabel.Size = new System.Drawing.Size(246, 17);
            this.signinLabel.TabIndex = 13;
            this.signinLabel.Text = "Already have an account? Sign in.";
            this.signinLabel.Click += new System.EventHandler(this.SigninLabel_Click);
            // 
            // emailText
            // 
            this.emailText.Depth = 0;
            this.emailText.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailText.Hint = "Enter your email";
            this.emailText.Location = new System.Drawing.Point(90, 123);
            this.emailText.MouseState = MaterialSkin.MouseState.HOVER;
            this.emailText.Name = "emailText";
            this.emailText.PasswordChar = '\0';
            this.emailText.SelectedText = "";
            this.emailText.SelectionLength = 0;
            this.emailText.SelectionStart = 0;
            this.emailText.Size = new System.Drawing.Size(301, 23);
            this.emailText.TabIndex = 1;
            this.emailText.UseSystemPasswordChar = false;
            // 
            // password1
            // 
            this.password1.Depth = 0;
            this.password1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password1.Hint = "Enter your password";
            this.password1.Location = new System.Drawing.Point(90, 170);
            this.password1.MouseState = MaterialSkin.MouseState.HOVER;
            this.password1.Name = "password1";
            this.password1.PasswordChar = '\0';
            this.password1.SelectedText = "";
            this.password1.SelectionLength = 0;
            this.password1.SelectionStart = 0;
            this.password1.Size = new System.Drawing.Size(301, 23);
            this.password1.TabIndex = 2;
            this.password1.UseSystemPasswordChar = false;
            // 
            // password2
            // 
            this.password2.Depth = 0;
            this.password2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password2.Hint = "Confirm password";
            this.password2.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.password2.Location = new System.Drawing.Point(90, 217);
            this.password2.MouseState = MaterialSkin.MouseState.HOVER;
            this.password2.Name = "password2";
            this.password2.PasswordChar = '\0';
            this.password2.SelectedText = "";
            this.password2.SelectionLength = 0;
            this.password2.SelectionStart = 0;
            this.password2.Size = new System.Drawing.Size(301, 23);
            this.password2.TabIndex = 3;
            this.password2.UseSystemPasswordChar = false;
            // 
            // firstNameText
            // 
            this.firstNameText.Depth = 0;
            this.firstNameText.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstNameText.Hint = "First Name";
            this.firstNameText.Location = new System.Drawing.Point(90, 326);
            this.firstNameText.MouseState = MaterialSkin.MouseState.HOVER;
            this.firstNameText.Name = "firstNameText";
            this.firstNameText.PasswordChar = '\0';
            this.firstNameText.SelectedText = "";
            this.firstNameText.SelectionLength = 0;
            this.firstNameText.SelectionStart = 0;
            this.firstNameText.Size = new System.Drawing.Size(301, 23);
            this.firstNameText.TabIndex = 4;
            this.firstNameText.UseSystemPasswordChar = false;
            // 
            // lastNameText
            // 
            this.lastNameText.Depth = 0;
            this.lastNameText.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastNameText.Hint = "Last Name";
            this.lastNameText.Location = new System.Drawing.Point(90, 369);
            this.lastNameText.MouseState = MaterialSkin.MouseState.HOVER;
            this.lastNameText.Name = "lastNameText";
            this.lastNameText.PasswordChar = '\0';
            this.lastNameText.SelectedText = "";
            this.lastNameText.SelectionLength = 0;
            this.lastNameText.SelectionStart = 0;
            this.lastNameText.Size = new System.Drawing.Size(301, 23);
            this.lastNameText.TabIndex = 5;
            this.lastNameText.UseSystemPasswordChar = false;
            // 
            // extraInfoText
            // 
            this.extraInfoText.Depth = 0;
            this.extraInfoText.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.extraInfoText.Hint = "Your graduation year";
            this.extraInfoText.Location = new System.Drawing.Point(90, 414);
            this.extraInfoText.MouseState = MaterialSkin.MouseState.HOVER;
            this.extraInfoText.Name = "extraInfoText";
            this.extraInfoText.PasswordChar = '\0';
            this.extraInfoText.SelectedText = "";
            this.extraInfoText.SelectionLength = 0;
            this.extraInfoText.SelectionStart = 0;
            this.extraInfoText.Size = new System.Drawing.Size(301, 23);
            this.extraInfoText.TabIndex = 6;
            this.extraInfoText.UseSystemPasswordChar = false;
            // 
            // registerTile
            // 
            this.registerTile.ActiveControl = null;
            this.registerTile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.registerTile.Location = new System.Drawing.Point(90, 464);
            this.registerTile.Name = "registerTile";
            this.registerTile.Size = new System.Drawing.Size(301, 47);
            this.registerTile.TabIndex = 7;
            this.registerTile.Text = "Register";
            this.registerTile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.registerTile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.registerTile.UseSelectable = true;
            this.registerTile.Click += new System.EventHandler(this.registerTile_Click);
            // 
            // Signup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 611);
            this.Controls.Add(this.registerTile);
            this.Controls.Add(this.extraInfoText);
            this.Controls.Add(this.lastNameText);
            this.Controls.Add(this.firstNameText);
            this.Controls.Add(this.password2);
            this.Controls.Add(this.password1);
            this.Controls.Add(this.emailText);
            this.Controls.Add(this.signinLabel);
            this.Controls.Add(this.panel1);
            this.Name = "Signup";
            this.Text = "Please sign up";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label faculty;
        private System.Windows.Forms.Label student;
        private System.Windows.Forms.Label signinLabel;
        private MaterialSkin.Controls.MaterialSingleLineTextField emailText;
        private MaterialSkin.Controls.MaterialSingleLineTextField password1;
        private MaterialSkin.Controls.MaterialSingleLineTextField password2;
        private MaterialSkin.Controls.MaterialSingleLineTextField firstNameText;
        private MaterialSkin.Controls.MaterialSingleLineTextField lastNameText;
        private MaterialSkin.Controls.MaterialSingleLineTextField extraInfoText;
        private MetroFramework.Controls.MetroTile registerTile;
    }
}