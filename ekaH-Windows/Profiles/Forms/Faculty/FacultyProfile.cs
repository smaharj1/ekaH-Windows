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
using ekaH_Windows.Profiles.Forms;

namespace ekaH_Windows.Profiles
{
    /// <summary>
    /// This class is the initial form when faculty logs in.
    /// </summary>
    public partial class FacultyProfile : MetroFramework.Forms.MetroForm
    {
        /// <summary>
        /// It holds the user's email.
        /// </summary>
        public string m_userEmail;

        /// <summary>
        /// It holds the dashboard controller for faculty.
        /// </summary>
        private FacultyDashboardUC m_ucDashboard;

        /// <summary>
        /// It holds the course controller for faculty.
        /// </summary>
        private FacultyCourseUC m_ucCourse;

        /// <summary>
        /// It holds the appointment controller for faculty.
        /// </summary>
        private AppointmentControl m_ucAppointment;

        /// <summary>
        /// It holds the faculty info.
        /// </summary>
        public FacultyInfo m_faculty;

        /// <summary>
        /// It holds the FacultyProfile object so that this class can be singleton.
        /// </summary>
        private static FacultyProfile m_facultyProfile;

        /// <summary>
        /// This is a constructor that initializes the user's email.
        /// </summary>
        /// <param name="email"></param>
        private FacultyProfile(string email)
        {
            InitializeComponent();

            m_userEmail = email;
        }

        /// <summary>
        /// This function gets an instance of this class making it singleton.
        /// </summary>
        /// <param name="a_email">It holds the email of current user.</param>
        /// <returns>Returns the Faculty Profile object.</returns>
        public static FacultyProfile getInstance(string a_email)
        {
            if (m_facultyProfile == null)
            {
                m_facultyProfile = new FacultyProfile(a_email);
            }

            return m_facultyProfile;
        }

        /// <summary>
        /// This function gets the faculty's information and views dashboard after the form
        /// loads.
        /// </summary>
        /// <param name="a_sender">It holds the sender.</param>
        /// <param name="a_event"> It holds the event.</param>
        private void FacultyProfile_Load(object a_sender, EventArgs a_event)
        {
            /// Make REST calls here to handle bring up all the information needed.
            GetFacultyInfo();

            ViewDashboard();
        }

        /// <summary>
        /// This function makes a request to the server to get the faculty's information.
        /// </summary>
        public void GetFacultyInfo()
        {
            FacultyInfo responseFaculty;

            /// Gets the faculty information here. 
            HttpClient client = NetworkClient.getInstance().getHttpClient();

            string requestURI = BaseConnection.g_facultyString + "/" + m_userEmail + "/";

            try
            {
                /// List data response. This is the blocking call.
                var response = client.GetAsync(requestURI).Result;

                /// Checks if it is successfully gotten. If yes,
                /// then it puts the information to the screen to display.
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

                    contactLabel.Text = m_userEmail + " " + responseFaculty.Phone;

                    m_faculty = responseFaculty;

                }
                else
                {
                    m_faculty = null;
                    throw new Exception();

                }
            }
            catch(Exception)
            {
                Worker.printServerError(this);
            }
        }
        
        /// <summary>
        /// This function displays the dashboard by initializing it first if necessary.
        /// </summary>
        private void ViewDashboard()
        {
            if (m_ucDashboard == null)
            {
                m_ucDashboard = new FacultyDashboardUC(m_userEmail);
                m_ucDashboard.Dock = DockStyle.Fill;

                contentPanel.Controls.Add(m_ucDashboard);
            }

            m_ucDashboard.BringToFront();
            
        }
        /// <summary>
        /// This function displays the appointments by initializing it first if necessary.
        /// </summary>
        private void ViewAppointments()
        {
            if (m_ucAppointment == null)
            {
                m_ucAppointment = new AppointmentControl(this, false);
                m_ucAppointment.Dock = DockStyle.Fill;

                contentPanel.Controls.Add(m_ucAppointment);
            }

            contentPanel.Controls["AppointmentControl"].BringToFront();
        }

        /// <summary>
        /// This function displays the Courses by initializing it first if necessary.
        /// </summary>
        private void ViewCourses()
        {
            if (m_ucCourse == null)
            {
                m_ucCourse = new FacultyCourseUC(m_userEmail);
                m_ucCourse.Dock = DockStyle.Fill;

                contentPanel.Controls.Add(m_ucCourse);
            }

            m_ucCourse.BringToFront();
        }

        private void dashboardControl_Click(object sender, EventArgs e)
        {
        }

        private void coursesControl_Click(object sender, EventArgs e)
        {
        }

        public void ViewChat()
        {
            OnlineChat chat = new OnlineChat(m_userEmail);
            chat.ShowDialog();
        }

        /// <summary>
        /// This function switches to desired pages as the user wants.
        /// </summary>
        /// <param name="a_sender">It holds the sender.</param>
        /// <param name="a_event">It holds the event.</param>
        private void TabControl_Click(object a_sender, EventArgs a_event)
        {
            TabPage selectedTab = tabControl.SelectedTab;

            if (selectedTab == onlineChatTab)
            {
                /// Handle the function for displaying chat
                ViewChat();
            }
            else if (selectedTab == coursesTab)
            {
                ViewCourses();
            }
            else if (selectedTab == appointmentTab)
            {
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
