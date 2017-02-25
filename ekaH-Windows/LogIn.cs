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
    public partial class LogInWindow : Form
    {
        private Boolean isStudent;


        public LogInWindow()
        {
            InitializeComponent();
            isStudent = true;
        }

        private void LogIn_Load(object sender, EventArgs e)
        {

        }

        

        /**
         * Handles the log in of the user.
         * */
        private void executeLogin()
        {
            string details = "";

            details += emailText.Text;
            details += "\n" + passwordText.Text;

            //MessageBox.Show(details);

        }
        

        private void facultyButtonClicked(object sender, EventArgs e)
        {
            isStudent = false;
            faculty.BackColor = Color.SkyBlue;
            student.BackColor = Color.FromArgb(224, 224, 224);
        }

        private void student_Click(object sender, EventArgs e)
        {
            isStudent = true;
            student.BackColor = Color.SkyBlue;
            faculty.BackColor = Color.FromArgb(224, 224, 224);
        }

        private void signupLabel_Click(object sender, EventArgs e)
        {
            executeSignup();
        }

        private void executeSignup()
        {
            this.Hide();

            Signup register = new Signup();
            register.ShowDialog();

            this.Close();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            executeLogin();
        }
    }
}
