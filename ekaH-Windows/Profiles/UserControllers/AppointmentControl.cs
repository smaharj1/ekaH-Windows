using System;
using ekaH_Windows.Profiles.UserControllers.Student;
using System.Windows.Forms;
using ekaH_Windows.Model;
using System.Collections.Generic;
using System.Net.Http;
using MetroFramework;
using MetroFramework.Controls;
using System.Text;
using System.Drawing;
using ekaH_Windows.Profiles.Forms;
using ekaH_Windows.Profiles.UserControllers.Faculty;

namespace ekaH_Windows.Profiles.UserControllers
{
    /// <summary>
    /// This class is a controller for handling the appointments page for both students and professors.
    /// For students, it helps them pick the appointment time and divides it accordingly.
    /// </summary>
    public partial class AppointmentControl : MetroFramework.Controls.MetroUserControl
    {
        /// <summary>
        /// It holds the parent form of the controller. It can be Student or Professor's profile.
        /// </summary>
        private Object m_parent { get; set; }

        /// <summary>
        /// It holds if the user is student or not.
        /// </summary>
        private bool m_isStudent;

        /// <summary>
        /// It holds the inner controller assigned for separate functionalities of professors
        /// and students.
        /// </summary>
        private Object m_ucController;

        /// <summary>
        /// It is a constructor. It initializes the parent profile and if the user is a student.
        /// </summary>
        /// <param name="a_profile">It holds the parent profile.</param>
        /// <param name="a_isStd">It holds if the user is student.</param>
        public AppointmentControl(Object a_profile, bool a_isStd)
        {
            m_parent = a_profile;
            m_isStudent = a_isStd;

            InitializeComponent();
        }

        /// <summary>
        /// This function starts the Schedule App or something else for professor.
        /// </summary>
        /// <param name="a_sender">It holds the sender.</param>
        /// <param name="a_event">It holds the event.</param>
        private void AppointmentControl_Load(object a_sender, EventArgs a_event)
        {
            /// Checks if the user is student or professor.
            /// If it is a student, then allow them to search the appointments and
            /// set it while it allows the professors to plan the schedule for the whole
            /// semester.
            if (m_isStudent)
            {
                ScheduleAppUC ucApp = new ScheduleAppUC(this);
                ucApp.Dock = DockStyle.Fill;
                m_ucController = ucApp;

                contentPanel.Controls.Add((ScheduleAppUC) m_ucController);
            }
            else
            {
                FacultyScheduleUC ucFaculty = new FacultyScheduleUC(this);
                ucFaculty.Dock = DockStyle.Fill;
                m_ucController = ucFaculty;

                contentPanel.Controls.Add((FacultyScheduleUC)m_ucController);
            }

            /// Populates the appointments in approved and yet to be confirmed.
            RefreshController();
        }

        /// <summary>
        /// This function makes the Metro tile for the single appointment.
        /// </summary>
        /// <param name="a_app">It holds the appointment object.</param>
        /// <param name="a_xCoord">It holds the x coordinate value.</param>
        /// <param name="a_yCoord">It holds the y coordinate value.</param>
        /// <returns>Returns the new tile dynamically made.</returns>
        private MetroTile MakeAppointmentTile(Appointment a_app, int a_xCoord, int a_yCoord)
        {
            /// Makes a new tile and sets the text for the tile.
            MetroTile newTile = new MetroTile();
            DateTime date = a_app.StartTime;
            StringBuilder display = new StringBuilder();
            display.Append(date.ToString("MM/dd/yyyy hh:mm tt") + " - ");
            display.Append(a_app.EndTime.ToString("hh:mm tt"));

            newTile.Text = display.ToString();
            newTile.Location = new Point(a_xCoord, a_yCoord);
            newTile.Tag = a_app;
            newTile.Click += new EventHandler(HandleAppointmentClick);
            newTile.Size = new Size(upcomingAppPanel.Width - 40, 80);
            newTile.Cursor = Cursors.Hand;
            
            return newTile;
        }

        /// <summary>
        /// This function handles what to do when appointments in upcoming and pending are clicked.
        /// </summary>
        /// <param name="a_sender">It holds the sender.</param>
        /// <param name="a_event">It holds the event.</param>
        private void HandleAppointmentClick(object a_sender, EventArgs a_event)
        {
            MetroTile tile = (MetroTile)a_sender;
            Appointment app = (Appointment)tile.Tag;

            /// Opens the appointment action form that takes in the appointment object and 
            /// if it is student or not for appropriate actions.
            AppointmentAction actionForm = new AppointmentAction(app, m_isStudent);
            actionForm.ShowDialog();

            /// Refreshes the UI of the controller.
            RefreshController();
        }

        /// <summary>
        /// This function refreshes all the components of the controller like upcoming
        /// and pending appointments panel.
        /// </summary>
        public void RefreshController()
        {
            /// Gets all the existing appointments of the student/professor from the server.
            List<Appointment> appointments = ExecuteGetAppointments();

            if (appointments == null) return;

            pendingAppPanel.Controls.Clear();
            upcomingAppPanel.Controls.Clear();

            /// Initial values for the x and y coordinates of the tile.
            int approveX = 10, approveY = 10, pendingX = 10, pendingY = 10;

            /// Loops through each appointment and puts it in the desired panel.
            foreach (Appointment app in appointments)
            {
                /// Checks if it is confirmed apppointment of still needs approval.
                if (app.Confirmed && app.StartTime >= DateTime.Now)
                {
                    MetroTile tile = MakeAppointmentTile(app, approveX, approveY);
                    tile.UseCustomBackColor = true;
                    tile.BackColor = Color.Green;

                    upcomingAppPanel.Controls.Add(tile);
                    approveY += 90;
                }
                else
                {
                    MetroTile tile = MakeAppointmentTile(app, pendingX, pendingY);
                    tile.UseCustomBackColor = true;
                    tile.BackColor = Color.DarkOrange;

                    pendingAppPanel.Controls.Add(tile);
                    pendingY += 90;
                }
            }
            
            
        }

        /// <summary>
        /// This function gets the existing appointments from the server.
        /// </summary>
        /// <returns>Returns the list of all the existing appointments from the server.</returns>
        private List<Appointment> ExecuteGetAppointments()
        {
            HttpClient client = NetworkClient.getInstance().getHttpClient();
            List<Appointment> appointments;

            /// Checks if its a student, then brings the student appointments. 
            /// Else, it brings the professor appointments.
            string uri = "";

            /// Sets the URI of the request according to who is using it.
            if (m_isStudent)
            {
                uri = BaseConnection.g_appointments + "/" + BaseConnection.g_studentString + "/" +
                    GetEmail() + "/";
            }
            else
            {
                uri = BaseConnection.g_appointments + "/" + BaseConnection.g_facultyString + "/" +
                    GetEmail() + "/";
            }

            try
            {
                /// Gets the list from the server.
                var resp = client.GetAsync(uri).Result;

                if (resp.IsSuccessStatusCode)
                {
                    appointments = resp.Content.ReadAsAsync<List<Appointment>>().Result;
                    return appointments;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch(Exception)
            {
                Worker.printServerError(this);
            }

            /// Returns null if nothing is found.
            return null;
        }

        /// <summary>
        /// This function gets the email of the user.
        /// </summary>
        /// <returns>Returns the current user's email.</returns>
        public string GetEmail()
        {
            if (m_isStudent)
            {
                return ((StudentProfile)m_parent).m_userEmail;
            }
            else
            {
                return ((FacultyProfile)m_parent).m_userEmail;
            }
        }
    }
}
