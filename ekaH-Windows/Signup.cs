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
            loginWindow.Show();

            this.Close(); 
        }

        private void signupButton_Click(object sender, EventArgs e)
        {
            // Make a REST call here
        }

        private void student_Click(object sender, EventArgs e)
        {
            isStudent = true;
            student.BackColor = Color.SkyBlue;
            faculty.BackColor = Color.FromArgb(224, 224, 224);

            extraInfoText.Text = "Graduation year";
        }

        private void faculty_Click(object sender, EventArgs e)
        {
            isStudent = false;
            faculty.BackColor = Color.SkyBlue;
            student.BackColor = Color.FromArgb(224, 224, 224);

            extraInfoText.Text = "Department";
        }
    }
}
