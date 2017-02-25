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
            this.label1 = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.rectangleShape2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.emailText = new System.Windows.Forms.TextBox();
            this.passwordText = new System.Windows.Forms.TextBox();
            this.student = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.faculty = new System.Windows.Forms.Label();
            this.signupLabel = new System.Windows.Forms.Label();
            this.loginButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 22F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(179, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Log In";
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape2,
            this.rectangleShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(483, 553);
            this.shapeContainer1.TabIndex = 1;
            this.shapeContainer1.TabStop = false;
            // 
            // rectangleShape2
            // 
            this.rectangleShape2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.rectangleShape2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.rectangleShape2.BorderColor = System.Drawing.Color.Transparent;
            this.rectangleShape2.Location = new System.Drawing.Point(93, 209);
            this.rectangleShape2.Name = "rectangleShape2";
            this.rectangleShape2.SelectionColor = System.Drawing.Color.White;
            this.rectangleShape2.Size = new System.Drawing.Size(300, 40);
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.rectangleShape1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.rectangleShape1.BorderColor = System.Drawing.Color.Transparent;
            this.rectangleShape1.Location = new System.Drawing.Point(93, 133);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.SelectionColor = System.Drawing.Color.White;
            this.rectangleShape1.Size = new System.Drawing.Size(300, 40);
            // 
            // emailText
            // 
            this.emailText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.emailText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.emailText.Font = new System.Drawing.Font("Verdana", 16F);
            this.emailText.ForeColor = System.Drawing.Color.Gray;
            this.emailText.Location = new System.Drawing.Point(109, 141);
            this.emailText.Name = "emailText";
            this.emailText.Size = new System.Drawing.Size(270, 26);
            this.emailText.TabIndex = 2;
            this.emailText.Text = "Email";
            this.emailText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // passwordText
            // 
            this.passwordText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.passwordText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passwordText.Font = new System.Drawing.Font("Verdana", 16F);
            this.passwordText.ForeColor = System.Drawing.Color.Gray;
            this.passwordText.Location = new System.Drawing.Point(109, 217);
            this.passwordText.Name = "passwordText";
            this.passwordText.Size = new System.Drawing.Size(270, 26);
            this.passwordText.TabIndex = 3;
            this.passwordText.Text = "password";
            this.passwordText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.passwordText.UseSystemPasswordChar = true;
            // 
            // student
            // 
            this.student.BackColor = System.Drawing.Color.SkyBlue;
            this.student.Cursor = System.Windows.Forms.Cursors.Hand;
            this.student.Font = new System.Drawing.Font("Verdana", 16F);
            this.student.ForeColor = System.Drawing.Color.Gray;
            this.student.Location = new System.Drawing.Point(1, 0);
            this.student.Name = "student";
            this.student.Size = new System.Drawing.Size(153, 38);
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
            this.panel1.Size = new System.Drawing.Size(301, 38);
            this.panel1.TabIndex = 6;
            // 
            // faculty
            // 
            this.faculty.Cursor = System.Windows.Forms.Cursors.Hand;
            this.faculty.Font = new System.Drawing.Font("Verdana", 16F);
            this.faculty.ForeColor = System.Drawing.Color.Gray;
            this.faculty.Location = new System.Drawing.Point(157, 0);
            this.faculty.Name = "faculty";
            this.faculty.Size = new System.Drawing.Size(144, 38);
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
            // loginButton
            // 
            this.loginButton.BackColor = System.Drawing.Color.SkyBlue;
            this.loginButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.loginButton.FlatAppearance.BorderSize = 0;
            this.loginButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.loginButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AliceBlue;
            this.loginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginButton.Font = new System.Drawing.Font("Verdana", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginButton.ForeColor = System.Drawing.Color.Gray;
            this.loginButton.Location = new System.Drawing.Point(93, 353);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(301, 40);
            this.loginButton.TabIndex = 13;
            this.loginButton.Text = "Log in";
            this.loginButton.UseVisualStyleBackColor = false;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // LogInWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(483, 553);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.signupLabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.passwordText);
            this.Controls.Add(this.emailText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.shapeContainer1);
            this.Name = "LogInWindow";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.LogIn_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape2;
        private System.Windows.Forms.TextBox emailText;
        private System.Windows.Forms.TextBox passwordText;
        private System.Windows.Forms.Label student;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label faculty;
        private System.Windows.Forms.Label signupLabel;
        private System.Windows.Forms.Button loginButton;
    }
}

