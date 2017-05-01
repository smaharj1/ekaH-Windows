using ekaH_Windows.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ekaH_Windows
{
    /// <summary>
    /// This class lets the users register to the application.
    /// </summary>
    public partial class Signup : MetroFramework.Forms.MetroForm
    {
        /// <summary>
        /// It holds if the user is student or professor.
        /// </summary>
        private bool isStudent { get; set; }

        /// <summary>
        /// This is a default constructor.
        /// </summary>
        public Signup()
        {
            isStudent = true;
            InitializeComponent();
        }

        /// <summary>
        /// This function returns to log in page when the button is clicked.
        /// </summary>
        /// <param name="a_sender">It holds the sender.</param>
        /// <param name="a_event">It holds the event.</param>
        private void SigninLabel_Click(object a_sender, EventArgs a_event)
        {
            this.Hide();

            /// Opens the log in window and closes the signup window.
            LogInWindow loginWindow = new LogInWindow();
            loginWindow.ShowDialog();

            this.Close(); 
        }

        /// <summary>
        /// This function verifies that all the fields meet the requirement before sending the data to the server.
        /// </summary>
        /// <returns>Returns true if all the fields have correct values.</returns>
        private bool VerifyAllFields()
        {
            try
            {
                /// Verifies the name fields and address fields.
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

        /// <summary>
        /// This function changes the label text when when student tab is clicked so that graduation year is captured.
        /// </summary>
        /// <param name="a_sender">It holds the sender.</param>
        /// <param name="a_event">It holds the events.</param>
        private void Student_Click(object a_sender, EventArgs a_event)
        {
            isStudent = true;
            student.BackColor = Color.SkyBlue;
            faculty.BackColor = Color.FromArgb(224, 224, 224);

            extraInfoText.Hint = "Graduation year";
        }

        /// <summary>
        /// This function changes the label text when faculty tab is clicked so that department info is captured.
        /// </summary>
        /// <param name="a_sender">It holds the sender.</param>
        /// <param name="a_event">It holds the events.</param>
        private void Faculty_Click(object a_sender, EventArgs a_event)
        {
            isStudent = false;
            faculty.BackColor = Color.SkyBlue;
            student.BackColor = Color.FromArgb(224, 224, 224);

            extraInfoText.Hint = "Department";
        }

        /// <summary>
        /// This function registers the user when the tile is clicked.
        /// </summary>
        /// <param name="a_sender">It holds the sender.</param>
        /// <param name="a_event">It holds the events.</param>
        private void registerTile_Click(object a_sender, EventArgs a_event)
        {
            if (VerifyAllFields())
            {
                /// Makes a REST call here
                ClientUserRegisterModel registerInfo = new ClientUserRegisterModel();
                registerInfo.UserEmail = emailText.Text;
                registerInfo.Pswd = password1.Text;
                registerInfo.IsStudent = isStudent;
                registerInfo.ExtraInfo = extraInfoText.Text;
                registerInfo.FirstName = firstNameText.Text;
                registerInfo.LastName = lastNameText.Text;

                HttpClient client = NetworkClient.getInstance().getHttpClient();

                HttpResponseMessage responseReceived = client.PostAsJsonAsync(BaseConnection.g_registerPostString, registerInfo).Result;

                /// Checks if the server was able to register the user.
                if (responseReceived.IsSuccessStatusCode)
                {
                    MessageBox.Show("Your account has been registered. Please log in.");

                    /// Opens the log in window here.
                    this.Hide();

                    LogInWindow login = new LogInWindow();
                    login.ShowDialog();

                    this.Close();
                }
                else
                {
                    Worker.printServerError(this);
                }
            }
        }
    }
}
