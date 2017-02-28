using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ekaH_Windows
{
    public partial class Signup : Form
    {
        private Boolean isStudent;

        public Signup()
        {
            isStudent = true;
            InitializeComponent();
        }

        private void signinLabel_Click(object sender, EventArgs e)
        {
            this.Hide();

            LogInWindow loginWindow = new LogInWindow();
            loginWindow.ShowDialog();

            this.Close(); 
        }

        private void signupButton_Click(object sender, EventArgs e)
        {
            if (verifyAllFields())
            {
                // Make a REST call here

            }
            
        }

        // Verifies that all the fields meet the requirement before sending the data to the server.
        private bool verifyAllFields()
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(emailText.Text);
               

                if (password1.Text != password2.Text)
                {
                    MessageBox.Show("Your passwords don't match. \n Please enter it again.");
                    return false;
                }

                if (firstNameText.Text == "" || lastNameText.Text == "" || extraInfoText.Text == "")
                {
                    MessageBox.Show("Please fill in your first and last name info.");
                    return false;
                }

            }
            catch
            {
                MessageBox.Show("Your email address is not in a proper format. \n Please enter it again.");
                return false;
            }
            return true;
        }

        // Changes the label text when when student tab is clicked so that graduation year is captured.
        private void student_Click(object sender, EventArgs e)
        {
            isStudent = true;
            student.BackColor = Color.SkyBlue;
            faculty.BackColor = Color.FromArgb(224, 224, 224);

            extraInfoText.Text = "Graduation year";
        }

        // Changes the label text when faculty tab is clicked so that department info is captured.
        private void faculty_Click(object sender, EventArgs e)
        {
            isStudent = false;
            faculty.BackColor = Color.SkyBlue;
            student.BackColor = Color.FromArgb(224, 224, 224);

            extraInfoText.Text = "Department";
        }
    }
}
