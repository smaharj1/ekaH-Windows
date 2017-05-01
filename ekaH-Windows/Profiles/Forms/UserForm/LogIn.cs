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
    /// <summary>
    /// This class lets the log in functionalities to the user.
    /// </summary>
    public partial class LogInWindow : MetroFramework.Forms.MetroForm
    {
        /// <summary>
        /// It holds if the user is student or professor.
        /// </summary>
        private bool m_isStudent;

        /// <summary>
        /// This is a constructor. 
        /// </summary>
        public LogInWindow()
        {
            InitializeComponent();
            m_isStudent = true;
        }

        private void LogIn_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// This function handles the log in functionality of the user.
        /// </summary>
        private void ExecuteLogin()
        {
            /// Forms a model with the user provided information.
            ClientUserLoginModel loginInfo = new ClientUserLoginModel();
            loginInfo.Pswd = passwordText.Text;
            loginInfo.Email = emailText.Text;
            loginInfo.Member_type = m_isStudent ? (sbyte)1:(sbyte)0;

            HttpClient client = NetworkClient.getInstance().getHttpClient();
           
            /// List data response. This is the blocking call.
            HttpResponseMessage response = client.PostAsJsonAsync(BaseConnection.g_loginPostString, loginInfo).Result; 

            if (response.IsSuccessStatusCode)
            {
                /// Here, open the new relevant form according to student or professor.
                this.Hide();

                /// Opens the student/professor profile according to the information provided.
                if (m_isStudent)
                {
                    StudentProfile studentProfile = StudentProfile.GetInstance(loginInfo.Email);
                    studentProfile.ShowDialog();
                    
                }
                else
                {
                    FacultyProfile studentProfile = FacultyProfile.getInstance(loginInfo.Email);
                    studentProfile.ShowDialog();
                }
                this.Close();
                
            }
            else
            {
                MetroMessageBox.Show(this, "Cannot find the specified user", "Log in info incorrect", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        
        /// <summary>
        /// This function changes the m_isStudent variable when faculty button is clicked.
        /// </summary>
        /// <param name="a_sender">It holds the sender.</param>
        /// <param name="a_event">It holds the event.</param>
        private void FacultyButtonClicked(object a_sender, EventArgs a_event)
        {
            /// Changes the student value to false.
            m_isStudent = false;
            faculty.BackColor = Color.SkyBlue;
            student.BackColor = Color.FromArgb(224, 224, 224);
        }

        /// <summary>
        /// This function changes the student variable to true.
        /// </summary>
        /// <param name="a_sender">It holds the sender.</param>
        /// <param name="a_event">It holds the event.</param>
        private void Student_Click(object a_sender, EventArgs a_event)
        {
            m_isStudent = true;
            student.BackColor = Color.SkyBlue;
            faculty.BackColor = Color.FromArgb(224, 224, 224);
        }

        /// <summary>
        /// This function executes signup logic when the button is clicked.
        /// </summary>
        /// <param name="a_sender"></param>
        /// <param name="a_event"></param>
        private void SignupLabel_Click(object a_sender, EventArgs a_event)
        {
            ExecuteSignup();
        }

        /// <summary>
        /// This function performs sign up.
        /// </summary>
        private void ExecuteSignup()
        {
            this.Hide();

            /// Opens up Sign up form.
            Signup register = new Signup();
            register.ShowDialog();

            this.Close();
        }

        
        /// <summary>
        /// This funciton verifies if the user information provided is correct.
        /// </summary>
        /// <returns>Returns true if all the information provided by the user is correct.</returns>
        private bool VerifyLogin()
        {
            /// Verifies the log in info like formating and stuff before it executes the login.
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

        /// <summary>
        /// This function verifies the log in credentials and logs in the user.
        /// </summary>
        /// <param name="a_sender">It holds the sender.</param>
        /// <param name="a_event">It holds the events.</param>
        private void LoginButton_Click_1(object a_sender, EventArgs a_event)
        {
            if (VerifyLogin()) ExecuteLogin();
        }
    }
}
