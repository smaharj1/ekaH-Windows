using ekaH_Windows.Model;
using MetroFramework;
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

namespace ekaH_Windows.Profiles.Forms
{
    /// <summary>
    /// This class provides the details of an appointment made and allows the user to take actions such as delete/approve.
    /// </summary>
    public partial class AppointmentAction : MetroFramework.Forms.MetroForm
    {
        /// <summary>
        /// It represents if the student is logged in or the professor.
        /// </summary>
        private bool m_isStudent; 

        /// <summary>
        /// It holds the current appointment object.
        /// </summary>
        private Appointment m_appointment;

        /// <summary>
        /// It holds the full information of the people in the appointment.
        /// </summary>
        private FullAppointmentInfo m_fullApp;

        /// <summary>
        /// It is a constructor that initializes the appointment object and if student is logged in.
        /// </summary>
        /// <param name="a_app">It holds the value of current appointment object.</param>
        /// <param name="a_isStd">It holds boolean value of if the student is logged in or professor.</param>
        public AppointmentAction(Appointment a_app, bool a_isStd)
        {
            // Initializes the appointments and boolean for student.
            m_appointment = a_app;
            m_isStudent = a_isStd;
            InitializeComponent();
        }

        /// <summary>
        /// This function calls the server to get full information of the appointment and displays it on the screen.
        /// </summary>
        /// <param name="a_sender">It is the sender object.</param>
        /// <param name="a_event">It is the event arguments if exists.</param>
        private void AppointmentAction_Load(object a_sender, EventArgs a_event)
        {
            // Enables the approval tile only if professor is logged into the application.
            if (m_isStudent)
            {
                approveTile.Enabled = false;
            }

            // Gets the information of the appointment and prints it on the screen.
            m_fullApp = ExecuteGetFullAppointment(m_appointment.Id);

            PrintToForm(m_fullApp);
        }

        /// <summary>
        /// This function prints the information about the appointment on the screen.
        /// </summary>
        /// <param name="a_info">It holds the full information of the appointment.</param>
        private void PrintToForm(FullAppointmentInfo a_info)
        {
            // Builds the given information into a string before printing it on the screen.
            StringBuilder build = new StringBuilder();
            build.Append(a_info.Faculty.FirstName + " ");
            build.Append(a_info.Faculty.LastName + " -> ");
            build.Append(a_info.Faculty.Email);

            professorLabel.Text = build.ToString();
            build.Clear();

            build.Append(a_info.Student.FirstName + " ");
            build.Append(a_info.Student.LastName + " -> ");
            build.Append(a_info.Student.Email);
            attendeeLabel.Text = build.ToString();

            build.Clear();

            // Prints the labels on the screen.
            startTimeLabel.Text = a_info.Appointment.StartTime.ToShortDateString() + " " +
                a_info.Appointment.StartTime.ToShortTimeString();

            endTimeLabel.Text = a_info.Appointment.EndTime.ToShortDateString() + " " +
                a_info.Appointment.EndTime.ToShortTimeString();
        }

        /// <summary>
        /// This function calls the server to get more information about the appointment master and student.
        /// </summary>
        /// <param name="a_appID">It holds the appointment id that needs to be referred to get more info.</param>
        /// <returns>Returns the FullAppointmentInfo object that contains the student and professor details.</returns>
        private FullAppointmentInfo ExecuteGetFullAppointment(int a_appID)
        {
            /// Gets the instance of http client to make call to the server.
            HttpClient client = NetworkClient.getInstance().getHttpClient();

            /// Builds the necessary URI for making the call.
            string uri = BaseConnection.g_appointments + "/" + BaseConnection.g_fullInfo + "/" + a_appID;

            FullAppointmentInfo fullInfo = null;
            try
            {
                // Gets the response from the server and stores the information to fullInfo if the data is successfully received.
                var resp = client.GetAsync(uri).Result;

                if (resp.IsSuccessStatusCode)
                {
                    fullInfo = resp.Content.ReadAsAsync<FullAppointmentInfo>().Result;
                }
            }
            catch(Exception)
            {
                // Prints the error message.
                Worker.printServerError(this);
            }

            return fullInfo;
        }

        /// <summary>
        /// This function approves the appointment request.
        /// </summary>
        /// <param name="a_sender">It holds the sender object.</param>
        /// <param name="a_eventArg">It holds the event arguments.</param>
        private void ApproveTile_Click(object a_sender, EventArgs a_eventArg)
        {
            // Approves the appointment and sends the info to server.
            if (ExecutePutAppointment())
            {
                Dispose();
            }
        }

        /// <summary>
        /// This function sends a call to the server to approve the appointment request.
        /// </summary>
        /// <returns>Returns true if the request is successfully approved.</returns>
        private bool ExecutePutAppointment()
        {
            HttpClient client = NetworkClient.getInstance().getHttpClient();

            m_appointment.Confirmed = true;

            /// It prepares a URI string to make call to.
            string uri = BaseConnection.g_appointments + "/" + BaseConnection.g_app + "/" + m_appointment.Id; 

            try
            {
                // Makes the call to the server to check the confirmation status and return true if it is successfully changed.
                var resp = client.PutAsJsonAsync(uri, m_appointment).Result;

                if (resp.IsSuccessStatusCode)
                {
                    MetroMessageBox.Show(this, "Done! The appointment is confirmed", "Success!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            }
            catch(Exception)
            {
                Worker.printServerError(this);
            }

            /// Returns false if exceptions were caught.
            return false;
        }

        /// <summary>
        /// This function deletes the appointment.
        /// </summary>
        /// <param name="a_sender">It holds sender object.</param>
        /// <param name="a_event">It holds event arguments.</param>
        private void DeleteTile_Click(object a_sender, EventArgs a_event)
        {
            // Asks the user if they are sure that they would like to delete the appointment and then deletes it. 
            DialogResult dialogResult = MetroMessageBox.Show(this, "Are you sure you want to delete appointment?", "Schedule?",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                if (ExecuteDeleteAppointment())
                {
                    Dispose();
                }
            }
        }

        /// <summary>
        /// This function executes the server call to delete the existing appointment.
        /// </summary>
        /// <returns>Returns true if the appointment is successfully deleted.</returns>
        private bool ExecuteDeleteAppointment()
        {
            HttpClient client = NetworkClient.getInstance().getHttpClient();

            string uri = BaseConnection.g_appointments + "/" + BaseConnection.g_app + "/" + m_appointment.Id;

            /// Deletes the indicated appointment from the server.
            try
            {
                var resp = client.DeleteAsync(uri).Result;

                if (resp.IsSuccessStatusCode) return true;
                else return false;
                
            }
            catch (Exception)
            {
                Worker.printServerError(this);
            }

            /// Returns false if deletion is unsuccessful.
            return false;
        }
    }
}
