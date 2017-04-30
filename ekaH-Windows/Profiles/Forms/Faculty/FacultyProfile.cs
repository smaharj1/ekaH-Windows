using ekaH_Windows.Model;
using ekaH_Windows.Profiles.UserControllers;
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

namespace ekaH_Windows.Profiles
{
    public partial class FacultyProfile : MetroFramework.Forms.MetroForm
    {
        public string userEmail;

        private FacultyDashboardUC ucDashboard;
        private FacultyCourseUC ucCourse;
        private AppointmentControl ucAppointment;

        public FacultyInfo Faculty;

        private static FacultyProfile facultyProfile;

        private FacultyProfile(string email)
        {
            InitializeComponent();

            userEmail = email;
        }

        public static FacultyProfile getInstance(string email)
        {
            if (facultyProfile == null)
            {
                facultyProfile = new FacultyProfile(email);
            }

            return facultyProfile;
        }

        private void FacultyProfile_Load(object sender, EventArgs e)
        {
            // Make REST calls here to handle bring up all the information needed.
            getFacultyInfo();

            viewDashboard();

        }

        public void getFacultyInfo()
        {
            FacultyInfo responseFaculty;

            // Gets the faculty information here. 
            HttpClient client = NetworkClient.getInstance().getHttpClient();

            string requestURI = BaseConnection.g_facultyString + "/" + userEmail + "/";

            try
            {
                // List data response. This is the blocking call.
                var response = client.GetAsync(requestURI).Result;

                if (response.IsSuccessStatusCode)
                {
                    responseFaculty = response.Content.ReadAsAsync<FacultyInfo>().Result;

                    // Rewrite the information in the labels
                    firstNameLabel.Text = responseFaculty.FirstName;
                    lastNameLabel.Text = responseFaculty.LastName;
                    educationLabel.Text = responseFaculty.Education + " in " + responseFaculty.Concentration;

                    departmentLabel.Text = responseFaculty.Department == "" ? "" : "Department of " + responseFaculty.Department;

                    addressLabel.Text = responseFaculty.StreetAdd1 == "" ? "" : responseFaculty.StreetAdd1 + "\n";
                    addressLabel.Text += responseFaculty.StreetAdd2 == "" ? "" : responseFaculty.StreetAdd2 + "\n";
                    addressLabel.Text += responseFaculty.State == "" ? "" : responseFaculty.State + ", ";
                    addressLabel.Text += responseFaculty.Zip == "" ? "" : responseFaculty.Zip + "\n";

                    contactLabel.Text = userEmail + " " + responseFaculty.Phone;

                    Faculty = responseFaculty;

                }
                else
                {
                    Faculty = null;
                    MetroMessageBox.Show(this, "Could not get the faculty information because of server acting up :)", "Server down!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            catch(Exception)
            {
                MetroMessageBox.Show(this, "Server might be shut down right now!", "Server down!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
        

        private void viewDashboard()
        {
            if (ucDashboard == null)
            {
                ucDashboard = new FacultyDashboardUC(userEmail);
                ucDashboard.Dock = DockStyle.Fill;

                contentPanel.Controls.Add(ucDashboard);
            }


            //contentPanel.Controls["Dashboard"].BringToFront();
            ucDashboard.BringToFront();
            
        }

        private void viewAppointments()
        {
            if (ucAppointment == null)
            {
                ucAppointment = new AppointmentControl(this, false);
                ucAppointment.Dock = DockStyle.Fill;

                contentPanel.Controls.Add(ucAppointment);
            }

            contentPanel.Controls["AppointmentControl"].BringToFront();
        }

        private void viewCourses()
        {
            if (ucCourse == null)
            {
                ucCourse = new FacultyCourseUC(userEmail);
                ucCourse.Dock = DockStyle.Fill;

                contentPanel.Controls.Add(ucCourse);
            }

            //contentPanel.Controls["FacultyCourseUC"].BringToFront();
            ucCourse.BringToFront();
        }

        private void dashboardControl_Click(object sender, EventArgs e)
        {
        }

        private void coursesControl_Click(object sender, EventArgs e)
        {
        }

        private void tabControl_Click(object sender, EventArgs e)
        {
            TabPage selectedTab = tabControl.SelectedTab;

            if (selectedTab == onlineChatTab)
            {
                // Handle the function for displaying chat
            }
            else if (selectedTab == coursesTab)
            {
                viewCourses();
            }
            else if (selectedTab == appointmentTab)
            {
                viewAppointments();
            }
            else
            {
                // This will open the dashboard by default
                viewDashboard();
            }

        }

        /*
        private void label2_Click(object sender, EventArgs e)
        {

        }*/
    }
}
