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
using ekaH_Windows.Profiles.Forms;

namespace ekaH_Windows.Profiles
{
    /// <summary>
    /// This class views the form and its functionalities for student.
    /// </summary>
    public partial class StudentProfile : MetroFramework.Forms.MetroForm
    {
        /// <summary>
        /// It holds the user's email.
        /// </summary>
        public string m_userEmail { get; set; }

        /// <summary>
        /// It holds the student info of the current student.
        /// </summary>
        public StudentInfo m_currentStudent { get; set; }

        /// <summary>
        /// It holds the controller of dashboard.
        /// </summary>
        private StudentDashboardUC m_ucDashboard;

        /// <summary>
        /// It holds the controller of courses.
        /// </summary>
        private StudentCourseUC m_ucCourses;

        /// <summary>
        /// It holds the controller of appointments.
        /// </summary>
        private AppointmentControl m_ucAppointments;

        /// <summary>
        /// It holds the instance of StudentProfile in order to make it singleton class.
        /// </summary>
        private static StudentProfile student;

        /// <summary>
        /// This is a constructor that initializes the email of the user.
        /// </summary>
        /// <param name="a_email">It holds the user's email address.</param>
        private StudentProfile(string a_email)
        {
            InitializeComponent();

            m_userEmail = a_email;

            /// Starts all the tabs.
            InitializeAllTabs();
        }

        /// <summary>
        /// This function gives the instance of this class making it the only
        /// way to access it.
        /// </summary>
        /// <param name="a_email">It holds the email address.</param>
        /// <returns></returns>
        public static StudentProfile GetInstance(string a_email)
        {
            // Creates a new instance if student is null.
            if (student == null)
            {
                student = new StudentProfile(a_email);
            }

            return student;
        }

        /// <summary>
        /// This function gets the information of the student and initializes the 
        /// dashboard as the first view.
        /// </summary>
        /// <param name="a_sender">It holds the sender.</param>
        /// <param name="a_event">It holds the event.</param>
        private void StudentProfile_Load(object a_sender, EventArgs a_event)
        {
            GetStudentInfo();

            ViewDashboard();
        }

        /// <summary>
        /// This function initializes all the controllers namely
        /// dashbaord, courses, and appointments.
        /// </summary>
        private void InitializeAllTabs()
        {
            m_ucDashboard = new StudentDashboardUC(this);
            m_ucDashboard.Dock = DockStyle.Fill;

            m_ucCourses = new StudentCourseUC(this);
            m_ucCourses.Dock = DockStyle.Fill;

            m_ucAppointments = new AppointmentControl(this, true);
            m_ucAppointments.Dock = DockStyle.Fill;

            /// Adds all the initialized contollers to the panel.
            contentPanel.Controls.Add(m_ucDashboard);
            contentPanel.Controls.Add(m_ucCourses);
            contentPanel.Controls.Add(m_ucAppointments);
            
        }

        // This returns the student's information from the server.
        /// <summary>
        /// This function gets the account information of the user from the server.
        /// </summary>
        public void GetStudentInfo()
        {
            StudentInfo responseStudent;

            /// Gets the faculty information here. 
            HttpClient client = NetworkClient.getInstance().getHttpClient();

            string requestURI = BaseConnection.g_studentString + "/" + m_userEmail + "/";

            try
            {
                /// List data response. This is the blocking call.
                var response = client.GetAsync(requestURI).Result;

                if (response.IsSuccessStatusCode)
                {
                    responseStudent = response.Content.ReadAsAsync<StudentInfo>().Result;

                    /// Rewrite the information in the labels
                    firstNameLabel.Text = responseStudent.FirstName;
                    lastNameLabel.Text = responseStudent.LastName;
                    educationLabel.Text = responseStudent.Education + " in " + responseStudent.Concentration;

                    addressLabel.Text = responseStudent.StreetAdd1 == "" ? "" : responseStudent.StreetAdd1 + "\n";
                    addressLabel.Text += responseStudent.StreetAdd2 == "" ? "" : responseStudent.StreetAdd2 + "\n";
                    addressLabel.Text += responseStudent.State == "" ? "" : responseStudent.State + ", ";
                    addressLabel.Text += responseStudent.Zip == "" ? "" : responseStudent.Zip + "\n";

                    contactLabel.Text = m_userEmail + " " + responseStudent.Phone;

                    m_currentStudent = responseStudent;

                }
                else
                {
                    Worker.printServerError(this);
                }
            }
            catch(Exception)
            {
                Worker.printServerError(this);
            }
        }

        /// <summary>
        /// This function views the dashboard of the student.
        /// </summary>
        private void ViewDashboard()
        {
            if (m_ucDashboard == null)
            {
                /// Since StudentProfile is static class, directly access it from children classes instead.
                m_ucDashboard = new StudentDashboardUC(this);
                m_ucDashboard.Dock = DockStyle.Fill;

                contentPanel.Controls.Add(m_ucDashboard);
            }

            m_ucDashboard.BringToFront();
        }

        /// <summary>
        /// This function views the appointment controller.
        /// </summary>
        private void ViewAppointments()
        {
            if (m_ucAppointments == null)
            {
                // Since StudentProfile is static class, directly access it from children classes instead.
                m_ucAppointments = new AppointmentControl(this, true);
                m_ucAppointments.Dock = DockStyle.Fill;

                contentPanel.Controls.Add(m_ucAppointments);
            }

            m_ucAppointments.BringToFront();
        }

        /// <summary>
        /// This function views the courses controller.
        /// </summary>
        private void ViewCourses()
        {
            if (m_ucCourses == null)
            {
                // Since StudentProfile is static class, directly access it from children classes instead.
                m_ucCourses = new StudentCourseUC(this);
                m_ucCourses.Dock = DockStyle.Fill;

                contentPanel.Controls.Add(m_ucCourses);
            }

            m_ucCourses.BringToFront();
        }

        // Handles the tab control situation.
        /// <summary>
        /// This function handles the selection of pages on click.
        /// </summary>
        /// <param name="a_sender">It holds the sender.</param>
        /// <param name="a_event">It holds the event.</param>
        public void onClickTabControl(Object a_sender, EventArgs a_event)
        {
            TabPage selectedTab = tabControl.SelectedTab;

            /// Navigates to the selected tab according to the selection.
            if (selectedTab == onlineChatTab)
            {
                OnlineChat chat = new OnlineChat(m_userEmail);
                chat.ShowDialog();
            }
            else if (selectedTab == coursesTab)
            {
                if (m_ucCourses != null)
                {
                    m_ucCourses.ExecuteGetRequest();
                }
                ViewCourses();
            }
            else if (selectedTab == appointmentTab)
            {
                if (m_ucAppointments != null) m_ucAppointments.RefreshController();
                ViewAppointments();
            }
            else
            {
                /// This will open the dashboard by default
                ViewDashboard();
            }
        }
    }
}
