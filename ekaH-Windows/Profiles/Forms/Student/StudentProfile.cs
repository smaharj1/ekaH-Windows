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
using MetroFramework;
using ekaH_Windows.Profiles.UserControllers.Student;
using ekaH_Windows.Profiles.UserControllers;

namespace ekaH_Windows.Profiles
{
    public partial class StudentProfile : MetroFramework.Forms.MetroForm
    {
        public string UserEmail { get; set; }
        public StudentInfo CurrentStudent;
        public bool isStudent = true;

        private StudentDashboardUC ucDashboard;
        private StudentCourseUC ucCourses;
        private AppointmentControl ucAppointments;


        private static StudentProfile student;

        private StudentProfile(string email)
        {
            InitializeComponent();

            UserEmail = email;
            initializeAllTabs();

        }

        public static StudentProfile getInstance(string email)
        {
            if (student == null)
            {
                student = new StudentProfile(email);
            }

            return student;
        }

        

        private void StudentProfile_Load(object sender, EventArgs e)
        {
            getStudentInfo();

            viewDashboard();
        }

        private void initializeAllTabs()
        {
            ucDashboard = new StudentDashboardUC(this);
            ucDashboard.Dock = DockStyle.Fill;

            ucCourses = new StudentCourseUC(this);
            ucCourses.Dock = DockStyle.Fill;

            ucAppointments = new AppointmentControl(this, true);
            ucAppointments.Dock = DockStyle.Fill;

            contentPanel.Controls.Add(ucDashboard);
            contentPanel.Controls.Add(ucCourses);
            contentPanel.Controls.Add(ucAppointments);
            
        }

        // This returns the student's information from the server.
        public void getStudentInfo()
        {
            StudentInfo responseStudent;

            // Gets the faculty information here. 
            HttpClient client = NetworkClient.getInstance().getHttpClient();

            string requestURI = BaseConnection.studentString + "/" + UserEmail + "/";

            try
            {
                // List data response. This is the blocking call.
                var response = client.GetAsync(requestURI).Result;

                if (response.IsSuccessStatusCode)
                {
                    responseStudent = response.Content.ReadAsAsync<StudentInfo>().Result;

                    // Rewrite the information in the labels
                    firstNameLabel.Text = responseStudent.FirstName;
                    lastNameLabel.Text = responseStudent.LastName;
                    educationLabel.Text = responseStudent.Education + " in " + responseStudent.Concentration;

                    //Address responseStudent = responseStudent.Address;

                    addressLabel.Text = responseStudent.StreetAdd1 == "" ? "" : responseStudent.StreetAdd1 + "\n";
                    addressLabel.Text += responseStudent.StreetAdd2 == "" ? "" : responseStudent.StreetAdd2 + "\n";
                    addressLabel.Text += responseStudent.State == "" ? "" : responseStudent.State + ", ";
                    addressLabel.Text += responseStudent.Zip == "" ? "" : responseStudent.Zip + "\n";

                    contactLabel.Text = UserEmail + " " + responseStudent.Phone;

                    CurrentStudent = responseStudent;

                }
                else
                {
                    MetroMessageBox.Show(this, "Could not get the student information because of server acting up :)",
                        "Server down!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            catch(Exception)
            {
                MetroMessageBox.Show(this, "Server might be shut down right now!", "Server down!", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void viewDashboard()
        {
            if (ucDashboard == null)
            {
                // DO NOT pass in the email. Since StudentProfile is static class, directly access it from children classes instead.
                ucDashboard = new StudentDashboardUC(this);
                ucDashboard.Dock = DockStyle.Fill;

                contentPanel.Controls.Add(ucDashboard);
            }

            ucDashboard.BringToFront();
        }

        private void viewAppointments()
        {
            if (ucAppointments == null)
            {
                // DO NOT pass in the email. Since StudentProfile is static class, directly access it from children classes instead.
                ucAppointments = new AppointmentControl(this, true);
                ucAppointments.Dock = DockStyle.Fill;

                contentPanel.Controls.Add(ucAppointments);
            }

            ucAppointments.BringToFront();
        }

        private void viewCourses()
        {
            if (ucCourses == null)
            {
                // DO NOT pass in the email. Since StudentProfile is static class, directly access it from children classes instead.
                ucCourses = new StudentCourseUC(this);
                ucCourses.Dock = DockStyle.Fill;

                contentPanel.Controls.Add(ucCourses);
            }

            ucCourses.BringToFront();
        }

        // Handles the tab control situation.
        public void onClickTabControl(Object sender, EventArgs e)
        {
            TabPage selectedTab = tabControl.SelectedTab;

            if (selectedTab == onlineChatTab)
            {
                // Handle the function for displaying chat
            }
            else if (selectedTab == coursesTab)
            {
                if (ucCourses != null)
                {
                    ucCourses.executeGetRequest();
                }
                viewCourses();
            }
            else if (selectedTab == appointmentTab)
            {
                if (ucAppointments != null) ucAppointments.refreshController();
                viewAppointments();
            }
            else
            {
                // This will open the dashboard by default
                viewDashboard();
            }
        }
    }
}
