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

namespace ekaH_Windows.Profiles.UserControllers
{
    public partial class AppointmentControl : MetroFramework.Controls.MetroUserControl
    {
        private Object Parent { get; set; }
        private bool isStudent;
        private Object ucController;
        private object resultPanel;

        public AppointmentControl(Object profile, bool isStd)
        {
            Parent = profile;
            isStudent = isStd;

            InitializeComponent();
        }

        // Start the Schedule App or something else for professor.
        private void AppointmentControl_Load(object sender, EventArgs e)
        {
            if (isStudent)
            {
                ScheduleAppUC ucApp = new ScheduleAppUC(this);
                ucApp.Dock = DockStyle.Fill;
                ucController = ucApp;

                contentPanel.Controls.Add((ScheduleAppUC) ucController);
            }
            else
            {
                // Faculty thing is done here.
            }

            // Populate the appointments in approved and yet to be confirmed.
            refreshController();
        }

        private MetroTile makeAppointmentTile(Appointment app, int x, int y)
        {
            MetroTile newTile = new MetroTile();
            DateTime date = app.StartTime;
            StringBuilder display = new StringBuilder();
            display.Append(date.ToString("MM/dd/yyyy HH:mm tt") + " - ");
            display.Append(app.EndTime.ToString("HH:mm tt"));

            newTile.Text = display.ToString();
            newTile.Location = new Point(x, y);
            newTile.Tag = app;
            newTile.Click += new EventHandler(handleAppointmentClick);
            newTile.Size = new Size(upcomingAppPanel.Width - 40, 80);
            newTile.Cursor = Cursors.Hand;
            
            return newTile;
        }

        // Handles what to do when appointments in upcoming and pending are clicked.
        private void handleAppointmentClick(object sender, EventArgs e)
        {
            MetroTile tile = (MetroTile)sender;
            Appointment app = (Appointment)tile.Tag;

            // Opens the appointment action form that takes in the appointment object and 
            // if it is student or not for appropriate actions.
            AppointmentAction actionForm = new AppointmentAction(app, isStudent);
            actionForm.ShowDialog();

            refreshController();
        }

        // It refreshes the upcoming and pending panels
        public void refreshController()
        {
            List<Appointment> appointments = executeGetAppointments();

            if (appointments == null) return;

            pendingAppPanel.Controls.Clear();
            upcomingAppPanel.Controls.Clear();

            int approveX = 10, approveY = 10, pendingX = 10, pendingY = 10;

            foreach (Appointment app in appointments)
            {
                // Checks if it is confirmed apppointment of still needs approval.
                if (app.Confirmed && app.StartTime >= DateTime.Now)
                {
                    MetroTile tile = makeAppointmentTile(app, approveX, approveY);
                    tile.UseCustomBackColor = true;
                    tile.BackColor = Color.Green;

                    upcomingAppPanel.Controls.Add(tile);
                    approveY += 90;
                }
                else
                {
                    MetroTile tile = makeAppointmentTile(app, pendingX, pendingY);
                    tile.UseCustomBackColor = true;
                    tile.BackColor = Color.OrangeRed;

                    pendingAppPanel.Controls.Add(tile);
                    pendingY += 90;
                }
            }
            
            
        }

        private List<Appointment> executeGetAppointments()
        {
            HttpClient client = NetworkClient.getInstance().getHttpClient();
            List<Appointment> appointments;

            // Checks if its a student, then brings the student appointments. 
            // Else, it brings the professor appointments.
            string uri = "";

            if (isStudent)
            {
                uri = BaseConnection.appointments + "/" + BaseConnection.studentString + "/" +
                    getEmail() + "/";
            }
            else
            {
                uri = BaseConnection.appointments + "/" + BaseConnection.facultyString + "/" +
                    getEmail() + "/";
            }

            try
            {
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
                MetroMessageBox.Show(this, "Server might be shut down right now!", "Server down!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return null;

        }

        public string getEmail()
        {
            if (isStudent)
            {
                return ((StudentProfile)Parent).UserEmail;
            }
            else
            {
                return ((FacultyProfile)Parent).userEmail;
            }
        }
    }
}
