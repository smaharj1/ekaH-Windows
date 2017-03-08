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
            loginInfo.userEmail = emailText.Text;
            loginInfo.isStudent = this.isStudent;

            HttpClient client = NetworkClient.getInstance().getHttpClient();
           
            // List data response. This is the blocking call.
            HttpResponseMessage response = client.PostAsJsonAsync(BaseConnection.loginPostString, loginInfo).Result; 

            if (response.IsSuccessStatusCode)
            {
                // Here, open the new relevant form according to student or professor.
                this.Hide();


                if (loginInfo.isStudent)
                {
                    StudentProfile studentProfile = new StudentProfile(loginInfo.userEmail);
                    studentProfile.ShowDialog();
                    
                }
                else
                {
                    FacultyProfile studentProfile = FacultyProfile.getInstance(loginInfo.userEmail);
                    studentProfile.ShowDialog();
                }
                this.Close();
                
            }
            else
            {
                MessageBox.Show(response.Content.ReadAsAsync<string>().Result);
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
