namespace ekaH_Windows
{
    partial class LogInWindow
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
            this.student = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.faculty = new System.Windows.Forms.Label();
            this.signupLabel = new System.Windows.Forms.Label();
            this.emailText = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.passwordText = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.loginButton = new MetroFramework.Controls.MetroTile();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // student
            // 
            this.student.BackColor = System.Drawing.Color.SkyBlue;
            this.student.Cursor = System.Windows.Forms.Cursors.Hand;
            this.student.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.student.ForeColor = System.Drawing.Color.Gray;
            this.student.Location = new System.Drawing.Point(1, 0);
            this.student.Name = "student";
            this.student.Size = new System.Drawing.Size(153, 27);
            this.student.TabIndex = 2;
            this.student.Text = "Student";
            this.student.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.student.Click += new System.EventHandler(this.student_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.faculty);
            this.panel1.Controls.Add(this.student);
            this.panel1.Location = new System.Drawing.Point(93, 288);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(301, 25);
            this.panel1.TabIndex = 6;
            // 
            // faculty
            // 
            this.faculty.Cursor = System.Windows.Forms.Cursors.Hand;
            this.faculty.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.faculty.ForeColor = System.Drawing.Color.Gray;
            this.faculty.Location = new System.Drawing.Point(157, 0);
            this.faculty.Name = "faculty";
            this.faculty.Size = new System.Drawing.Size(144, 27);
            this.faculty.TabIndex = 3;
            this.faculty.Text = "Faculty";
            this.faculty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.faculty.Click += new System.EventHandler(this.facultyButtonClicked);
            // 
            // signupLabel
            // 
            this.signupLabel.AutoSize = true;
            this.signupLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.signupLabel.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signupLabel.ForeColor = System.Drawing.Color.Gray;
            this.signupLabel.Location = new System.Drawing.Point(155, 431);
            this.signupLabel.Name = "signupLabel";
            this.signupLabel.Size = new System.Drawing.Size(161, 17);
            this.signupLabel.TabIndex = 7;
            this.signupLabel.Text = "No Account? Sign up.";
            this.signupLabel.Click += new System.EventHandler(this.signupLabel_Click);
            // 
            // emailText
            // 
            this.emailText.Depth = 0;
            this.emailText.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailText.Hint = "Enter your email";
            this.emailText.Location = new System.Drawing.Point(93, 165);
            this.emailText.MouseState = MaterialSkin.MouseState.HOVER;
            this.emailText.Name = "emailText";
            this.emailText.PasswordChar = '\0';
            this.emailText.SelectedText = "";
            this.emailText.SelectionLength = 0;
            this.emailText.SelectionStart = 0;
            this.emailText.Size = new System.Drawing.Size(301, 23);
            this.emailText.TabIndex = 14;
            this.emailText.UseSystemPasswordChar = false;
            // 
            // passwordText
            // 
            this.passwordText.Depth = 0;
            this.passwordText.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordText.Hint = "Enter your password";
            this.passwordText.Location = new System.Drawing.Point(93, 225);
            this.passwordText.MouseState = MaterialSkin.MouseState.HOVER;
            this.passwordText.Name = "passwordText";
            this.passwordText.PasswordChar = '\0';
            this.passwordText.SelectedText = "";
            this.passwordText.SelectionLength = 0;
            this.passwordText.SelectionStart = 0;
            this.passwordText.Size = new System.Drawing.Size(301, 23);
            this.passwordText.TabIndex = 15;
            this.passwordText.UseSystemPasswordChar = true;
            // 
            // loginButton
            // 
            this.loginButton.ActiveControl = null;
            this.loginButton.Location = new System.Drawing.Point(93, 343);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(301, 49);
            this.loginButton.TabIndex = 16;
            this.loginButton.Text = "Log In";
            this.loginButton.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.loginButton.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.loginButton.UseSelectable = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click_1);
            // 
            // LogInWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 553);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.passwordText);
            this.Controls.Add(this.emailText);
            this.Controls.Add(this.signupLabel);
            this.Controls.Add(this.panel1);
            this.Name = "LogInWindow";
            this.Text = "Log In to your account";
            this.Load += new System.EventHandler(this.LogIn_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label student;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label faculty;
        private System.Windows.Forms.Label signupLabel;
        private MaterialSkin.Controls.MaterialSingleLineTextField emailText;
        private MaterialSkin.Controls.MaterialSingleLineTextField passwordText;
        private MetroFramework.Controls.MetroTile loginButton;
    }
}

