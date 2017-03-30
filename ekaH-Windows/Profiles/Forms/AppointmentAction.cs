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
    public partial class AppointmentAction : MetroFramework.Forms.MetroForm
    {
        private bool isStudent;
        private Appointment appointment;
        private FullAppointmentInfo fullApp;

        public AppointmentAction(Appointment app, bool isStd)
        {
            appointment = app;
            isStudent = isStd;
            InitializeComponent();
        }

        private void AppointmentAction_Load(object sender, EventArgs e)
        {
            if (isStudent)
            {
                approveTile.Enabled = false;
            }

            fullApp = executeGetFullAppointment(appointment.id);

            printToForm(fullApp);
        }

        private void printToForm(FullAppointmentInfo info)
        {
            StringBuilder build = new StringBuilder();
            build.Append(info.Faculty.FirstName + " ");
            build.Append(info.Faculty.LastName + " -> ");
            build.Append(info.Faculty.Email);

            professorLabel.Text = build.ToString();
            build.Clear();

            build.Append(info.Student.FirstName + " ");
            build.Append(info.Student.LastName + " -> ");
            build.Append(info.Student.Email);
            attendeeLabel.Text = build.ToString();

            build.Clear();

            startTimeLabel.Text = info.Appointment.StartTime.ToShortDateString() + " " +
                info.Appointment.StartTime.ToShortTimeString();

            endTimeLabel.Text = info.Appointment.EndTime.ToShortDateString() + " " +
                info.Appointment.EndTime.ToShortTimeString();

        }

        private FullAppointmentInfo executeGetFullAppointment(int appID)
        {
            HttpClient client = NetworkClient.getInstance().getHttpClient();

            string uri = BaseConnection.appointments + "/" + BaseConnection.fullInfo + "/" + appID;

            FullAppointmentInfo fullInfo = null;
            try
            {
                var resp = client.GetAsync(uri).Result;

                if (resp.IsSuccessStatusCode)
                {
                    fullInfo = resp.Content.ReadAsAsync<FullAppointmentInfo>().Result;
                }
            }
            catch(Exception)
            {
                MetroMessageBox.Show(this, "Server might be shut down right now!", "Server down!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return fullInfo;
        }

        private void approveTile_Click(object sender, EventArgs e)
        {
            if (executePutAppointment())
            {
                Dispose();
            }
        }

        private bool executePutAppointment()
        {
            HttpClient client = NetworkClient.getInstance().getHttpClient();
            appointment.Confirmed = true;
            string uri = BaseConnection.appointments + "/" + BaseConnection.app + "/" + appointment.id; 

            try
            {
                var resp = client.PutAsJsonAsync(uri, appointment).Result;

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
            return false;
        }

        private void deleteTile_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MetroMessageBox.Show(this, "Are you sure you want to delete appointment?", "Schedule?",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                if (executeDeleteAppointment())
                {
                    Dispose();
                }
            }
        }

        private bool executeDeleteAppointment()
        {
            HttpClient client = NetworkClient.getInstance().getHttpClient();

            string uri = BaseConnection.appointments + "/" + BaseConnection.app + "/" + appointment.id;

            try
            {
                var resp = client.DeleteAsync(uri).Result;

                if (resp.IsSuccessStatusCode) return true;
                else return false;
                
            }
            catch (Exception)
            {
                MetroMessageBox.Show(this, "Server might be shut down right now! Try again later", "Server down!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return false;
        }
    }
}
