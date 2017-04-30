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
    public partial class Signup : MetroFramework.Forms.MetroForm
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

            extraInfoText.Hint = "Graduation year";
        }

        // Changes the label text when faculty tab is clicked so that department info is captured.
        private void faculty_Click(object sender, EventArgs e)
        {
            isStudent = false;
            faculty.BackColor = Color.SkyBlue;
            student.BackColor = Color.FromArgb(224, 224, 224);

            extraInfoText.Hint = "Department";
        }

        private void registerTile_Click(object sender, EventArgs e)
        {
            if (verifyAllFields())
            {
                // Makes a REST call here
                ClientUserRegisterModel registerInfo = new ClientUserRegisterModel();
                registerInfo.UserEmail = emailText.Text;
                registerInfo.Pswd = password1.Text;
                registerInfo.IsStudent = isStudent;
                registerInfo.ExtraInfo = extraInfoText.Text;
                registerInfo.FirstName = firstNameText.Text;
                registerInfo.LastName = lastNameText.Text;

                HttpClient client = NetworkClient.getInstance().getHttpClient();

                HttpResponseMessage responseReceived = client.PostAsJsonAsync(BaseConnection.g_registerPostString, registerInfo).Result;

                if (responseReceived.IsSuccessStatusCode)
                {
                    MessageBox.Show("Your account has been registered. Please log in.");

                    // Opens the log in window here.

                    this.Hide();

                    LogInWindow login = new LogInWindow();
                    login.ShowDialog();

                    this.Close();
                }
                else
                {
                    //MessageBox.Show(responseReceived.Content.ReadAsAsync<string>().Result);
                }
            }
        }
    }
}
