using ekaH_Windows.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ekaH_Windows.Profiles;
using MetroFramework;

namespace ekaH_Windows
{
    public partial class LogInWindow : MetroFramework.Forms.MetroForm
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
            ClientUserLoginModel loginInfo = new ClientUserLoginModel();
            loginInfo.pswd = passwordText.Text;
            loginInfo.email = emailText.Text;
            loginInfo.member_type = isStudent ? (sbyte)1:(sbyte)0;

            HttpClient client = NetworkClient.getInstance().getHttpClient();
           
            // List data response. This is the blocking call.
            HttpResponseMessage response = client.PostAsJsonAsync(BaseConnection.loginPostString, loginInfo).Result; 

            if (response.IsSuccessStatusCode)
            {
                // Here, open the new relevant form according to student or professor.
                this.Hide();


                if (isStudent)
                {
                    StudentProfile studentProfile = StudentProfile.getInstance(loginInfo.email);
                    studentProfile.ShowDialog();
                    
                }
                else
                {
                    FacultyProfile studentProfile = FacultyProfile.getInstance(loginInfo.email);
                    studentProfile.ShowDialog();
                }
                this.Close();
                
            }
            else
            {
                MetroMessageBox.Show(this, "Cannot find the specified user", "Log in info incorrect", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


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

        

        private bool verifyLogin()
        {

            // Verifies the log in info like formating and stuff before it executes the login.
            try
            {
                var addr = new System.Net.Mail.MailAddress(emailText.Text);

                if (emailText.Text == "" || passwordText.Text == "")
                {
                    MessageBox.Show("Password field is empty please enter again. \n Please enter it again.");
                    return false;
                }


            }
            catch (Exception)
            {
                MessageBox.Show("Your email address is not in a proper format. \n Please enter it again.");
                return false;                
            }

            return true;

        }

        private void loginButton_Click_1(object sender, EventArgs e)
        {
            if (verifyLogin()) executeLogin();
        }
    }
}
