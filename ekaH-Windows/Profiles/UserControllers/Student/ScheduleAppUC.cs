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
    public partial class ScheduleAppUC : MetroUserControl
    {
        private string email;
        private AppointmentControl appControl;


        public ScheduleAppUC(Object parent)
        {
            appControl = (AppointmentControl)parent;
            email = appControl.getEmail();

            InitializeComponent();
        }

        private void ScheduleAppUC_Load(object sender, EventArgs e)
        {

        }

        public void searchBox_EnterPressed(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                performGetSchedule(searchBox.Text);

                performGetAvailability(searchBox.Text);
            }
        }

        private MetroTile makeAppointmentTile(Appointment app, int x, int y)
        {
            MetroTile newTile = new MetroTile();
            DateTime date = app.StartTime;
            StringBuilder display = new StringBuilder();
            display.Append(date.ToString("MM/dd/yyyy HH:mm tt") + " - " );
            display.Append(app.EndTime.ToString("HH:mm tt"));

            newTile.Text = display.ToString();
            newTile.Location = new Point(x, y);
            newTile.Tag = app;
            newTile.Click += new EventHandler(scheduleAppointmentTileClicked);
            newTile.Size = new Size(resultPanel.Width - 40, 80);

            return newTile;

        }

        private void scheduleAppointmentTileClicked(Object sender, EventArgs e)
        {
            DialogResult dialogResult = MetroMessageBox.Show(this, "Are you sure you want to schedule?", "Schedule?",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                MetroTile selectedTile = (MetroTile)sender;
                Appointment appointment = (Appointment)selectedTile.Tag;
                appointment.AttendeeID = email;

                performPostAppointment(appointment);
            }
            
        }

        private void performPostAppointment(Appointment appointment)
        {
            HttpClient client = NetworkClient.getInstance().getHttpClient();

            string uri = BaseConnection.appointments + "/" + BaseConnection.app;

            try
            {
                var resp = client.PostAsJsonAsync(uri, appointment).Result;

                if (resp.StatusCode == HttpStatusCode.Conflict)
                {
                    MetroMessageBox.Show(this, "Someone has already confirmed this spot!", "Conflict!"
                        , MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (resp.IsSuccessStatusCode)
                {
                    // Refresh the appointment control with the fresh data.
                    refreshControl();

                    MetroMessageBox.Show(this, "Successfully requested for appointment", "Success!"
                        , MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception)
            {

            }
        }

        private void refreshControl()
        {
            searchBox.Text = "";
            resultPanel.Controls.Clear();
            infoPanel.Visible = false;
            resultPanel.Visible = false;
        }

        private void performGetAvailability(string text)
        {
            HttpClient client = NetworkClient.getInstance().getHttpClient();

            string uri = BaseConnection.appointments + "/" + BaseConnection.schedules + "/" + text + "/";

            List<Appointment> availableDates = null;
            try
            {
                var resp = client.GetAsync(uri).Result;

                if (resp.IsSuccessStatusCode)
                {
                    availableDates = resp.Content.ReadAsAsync<List<Appointment>>().Result;
                }
            }
            catch(Exception)
            {
                MetroMessageBox.Show(this, "Server might be shut down right now!", "Server down!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (availableDates != null)
            {
                int x = 10, y = 10;

                resultPanel.Visible = true;
                resultPanel.Controls.Clear();

                foreach(Appointment app in availableDates)
                {
                    MetroTile tile = makeAppointmentTile(app, x, y);
                    resultPanel.Controls.Add(tile);
                    y += 90;
                }
            }
        }

        // Gets the schedule for the next two weeks.
        private void performGetSchedule(string searchTerm)
        {
            // Gets the faculty information here. 
            HttpClient client = NetworkClient.getInstance().getHttpClient();

            string requestURI = BaseConnection.appointments + "/" + BaseConnection.facSchedule + "/" + searchTerm+"/";

            Schedule resSchedule;
            try
            {
                // List data response. This is the blocking call.
                var response = client.GetAsync(requestURI).Result;

                if (response.IsSuccessStatusCode)
                {
                    resSchedule = response.Content.ReadAsAsync<Schedule>().Result;

                    emailTextBox.Text = resSchedule.ProfessorID;

                    daysTextBox.Text = "";


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
                    MetroMessageBox.Show(this, "Could not get the student information because of server acting up :)",
                        "Server down!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            catch (Exception)
            {
                MetroMessageBox.Show(this, "Server might be shut down right now!", "Server down!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        

    }
}
