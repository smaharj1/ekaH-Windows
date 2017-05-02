using System;
using System.Windows.Forms;
using System.Net.Http;
using ekaH_Windows.Model;
using MetroFramework;
using System.Collections.Generic;
using MetroFramework.Controls;
using System.Drawing;
using System.Text;
using System.Net;

namespace ekaH_Windows.Profiles.UserControllers.Student
{
    /// <summary>
    /// This class is a controller for students to schedule appointment with their professor.
    /// </summary>
    public partial class ScheduleAppUC : MetroUserControl
    {
        /// <summary>
        /// It holds the email of the student.
        /// </summary>
        private string m_email;

        /// <summary>
        /// It holds the appointment controller which is a parent of this controller.
        /// </summary>
        private AppointmentControl m_appControl;

        /// <summary>
        /// It is a constructor which initializes the parent controller.
        /// </summary>
        /// <param name="a_parent">It is a parent controller.</param>
        public ScheduleAppUC(Object a_parent)
        {
            m_appControl = (AppointmentControl)a_parent;
            m_email = m_appControl.GetEmail();

            InitializeComponent();
        }

        private void ScheduleAppUC_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// This function is triggered when the enter is clicked in the search box.
        /// </summary>
        /// <param name="a_sender">It holds the sender.</param>
        /// <param name="a_event">It holds the event args.</param>
        public void SearchBox_EnterPressed(object a_sender, KeyEventArgs a_event)
        {
            /// If enter is pressed, it searches the available times for that professor.
            if (a_event.KeyData == Keys.Enter)
            {
                PerformGetSchedule(searchBox.Text);

                PerformGetAvailability(searchBox.Text);
            }
        }

        /// <summary>
        /// The function makes an appointment tile.
        /// </summary>
        /// <param name="a_app">It holds the appointment to make tile for.</param>
        /// <param name="a_xCoord">It holds the x coordinate.</param>
        /// <param name="a_yCoord">It holds the y coordinate.</param>
        /// <returns>Returns the newly created tile.</returns>
        private MetroTile MakeAppointmentTile(Appointment a_app, int a_xCoord, int a_yCoord)
        {
            /// Builds a tile and puts the necessary texts.
            MetroTile newTile = new MetroTile();
            DateTime date = a_app.StartTime;
            StringBuilder display = new StringBuilder();
            display.Append(date.ToString("MM/dd/yyyy hh:mm tt") + " - " );
            display.Append(a_app.EndTime.ToString("hh:mm tt"));

            newTile.Text = display.ToString();
            newTile.Location = new Point(a_xCoord, a_yCoord);
            newTile.Tag = a_app;
            newTile.Click += new EventHandler(ScheduleAppointmentTileClicked);
            newTile.Size = new Size(resultPanel.Width - 40, 80);
            newTile.Cursor = Cursors.Hand;

            /// Returns the newly created tile.
            return newTile;
        }

        /// <summary>
        /// This function is triggered when the available times tile is clicked to make an appointment.
        /// </summary>
        /// <param name="a_sender">It holds the sender.</param>
        /// <param name="a_event">It holds the event args.</param>
        private void ScheduleAppointmentTileClicked(Object a_sender, EventArgs a_event)
        {
            
            DialogResult dialogResult = MetroMessageBox.Show(this, "Are you sure you want to schedule?", "Schedule?",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            /// Makes sure that user really wants to make an appointment and makes an appointment.
            if (dialogResult == DialogResult.Yes)
            {
                MetroTile selectedTile = (MetroTile)a_sender;
                Appointment appointment = (Appointment)selectedTile.Tag;
                appointment.AttendeeID = m_email;

                /// If server receives the request successfully, then refreshes the controller.
                if (PerformPostAppointment(appointment))
                {
                    m_appControl.RefreshController();
                }
            } 
        }

        /// <summary>
        /// This function makes an appointment.
        /// </summary>
        /// <param name="a_appointment">It holds the appointment to be posted.</param>
        /// <returns>Returns true if server successfully accepts the appointment request.</returns>
        private bool PerformPostAppointment(Appointment a_appointment)
        {
            HttpClient client = NetworkClient.getInstance().getHttpClient();

            string uri = BaseConnection.g_appointments + "/" + BaseConnection.g_app;

            try
            {
                /// Posts the assignment and checks if it was successful.
                var resp = client.PostAsJsonAsync(uri, a_appointment).Result;

                if (resp.StatusCode == HttpStatusCode.Conflict)
                {
                    MetroMessageBox.Show(this, "Someone has already confirmed this spot!", "Conflict!"
                        , MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (resp.IsSuccessStatusCode)
                {
                    // Refresh the appointment control with the fresh data.
                    RefreshControl();

                    MetroMessageBox.Show(this, "Successfully requested for appointment", "Success!"
                        , MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
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

            /// Returns false if posting was unsuccessful due to many reasons.
            return false;
        }

        /// <summary>
        /// This function refreshes the controller.
        /// </summary>
        private void RefreshControl()
        {
            searchBox.Text = "";
            resultPanel.Controls.Clear();
            infoPanel.Visible = false;
            resultPanel.Visible = false;
        }

        /// <summary>
        /// This function gets all the available times for the professor.
        /// </summary>
        /// <param name="a_text"></param>
        private void PerformGetAvailability(string a_text)
        {
            HttpClient client = NetworkClient.getInstance().getHttpClient();

            string uri = BaseConnection.g_appointments + "/" + BaseConnection.g_schedules + "/" + a_text + "/";

            List<Appointment> availableDates = null;
            try
            {
                /// Gets all the available dates divided into the chunks of half an hour.
                var resp = client.GetAsync(uri).Result;

                if (resp.IsSuccessStatusCode)
                {
                    availableDates = resp.Content.ReadAsAsync<List<Appointment>>().Result;
                }
            }
            catch(Exception)
            {
                Worker.printServerError(this);
            }

            /// Builds the tiles dynamically if the dates are available.
            if (availableDates != null)
            {
                int x = 10, y = 10;

                resultPanel.Visible = true;
                resultPanel.Controls.Clear();

                foreach(Appointment app in availableDates)
                {
                    MetroTile tile = MakeAppointmentTile(app, x, y);
                    resultPanel.Controls.Add(tile);
                    y += 90;
                }
            }
        }

        // Gets the schedule for the next two weeks.
        /// <summary>
        /// This function gets the actual weekly schedul of the professor and displays it 
        /// in user friendly manner.
        /// </summary>
        /// <param name="a_searchTerm"></param>
        private void PerformGetSchedule(string a_searchTerm)
        {
            /// Gets the faculty information here. 
            HttpClient client = NetworkClient.getInstance().getHttpClient();

            string requestURI = BaseConnection.g_appointments + "/" + BaseConnection.g_facSchedule + "/" + a_searchTerm+"/";

            Schedule resSchedule;
            try
            {
                /// List data response. This is the blocking call.
                var response = client.GetAsync(requestURI).Result;

                if (response.IsSuccessStatusCode)
                {
                    resSchedule = response.Content.ReadAsAsync<Schedule>().Result;

                    emailTextBox.Text = resSchedule.ProfessorID;

                    daysTextBox.Text = "";

                    /// Converts the data received into user friendly text.
                    foreach (DayInfo day in resSchedule.Days)
                    {
                        DateTime tempStart = DateTime.Today + day.startTime;
                        DateTime tempEnd = DateTime.Today + day.endTime;
                        daysTextBox.Text += day.Day.ToString() +":  "+tempStart.ToString("hh:mm tt") +
                            "-" + tempEnd.ToString("hh:mm tt") +"\r\n";
                    }

                    infoPanel.Visible = true;
                }
                else
                {
                    Worker.printServerError(this);
                }
            }
            catch (Exception)
            {
                Worker.printServerError(this);
            }
        }
    }
}
