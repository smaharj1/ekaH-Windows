using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ekaH_Windows.Model;
using System.Net.Http;
using MetroFramework;

namespace ekaH_Windows.Profiles.UserControllers.Faculty
{
    public partial class FacultyScheduleUC : MetroFramework.Controls.MetroUserControl
    {
        private AppointmentControl appControl;
        private bool firstTime;
        private Schedule schedule;
        private List<DayInfo> days = new List<DayInfo>();

        public FacultyScheduleUC(object parent)
        {
            appControl = (AppointmentControl) parent;
            firstTime = true;
            InitializeComponent();
        }

        private void addBox_Click(object sender, EventArgs e)
        {
            if (!verifyFields())
            {
                return;
            }

            // Checks if it is the first time and sets the initial values for it.
            if (firstTime)
            {
                schedule = new Schedule();
                
                schedule.StartDate = startDatePicker.Value;
                schedule.EndDate = endDatePicker.Value;
                schedule.ProfessorID = appControl.getEmail();
                firstTime = false;
                startDatePicker.Enabled = false;
                endDatePicker.Enabled = false;
            }

            DayInfo day = new DayInfo();
            day.Day = (DayOfWeek)dayComboBox.SelectedIndex;

            TimeSpan temp = startTimePicker.Value.TimeOfDay;
            day.startTime = new TimeSpan(temp.Hours, temp.Minutes, 0);

            temp = endTimePicker.Value.TimeOfDay;
            day.endTime = new TimeSpan(temp.Hours, temp.Minutes, 0);

            days.Add(day);

            dayComboBox.ResetText();

            MetroMessageBox.Show(this, "Successfully added",
                    "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool verifyFields()
        {
            return dayComboBox.SelectedIndex != -1;
        }

        private void metroLabel3_Click(object sender, EventArgs e)
        {

        }

        // Submit event handler
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            schedule.Days = days.ToArray();

            if (executePostSchedule())
            {
                MetroMessageBox.Show(this, "Schedule has been posted. Now, the students can find you easily ;)",
                    "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                refreshController();
            }
            
        }

        private void refreshController()
        {
            startDatePicker.Enabled = true;
            endDatePicker.Enabled = true;
            schedule = null;
            firstTime = true;
            days.Clear();
        }

        private bool executePostSchedule()
        {
            HttpClient client = NetworkClient.getInstance().getHttpClient();

            string uri = BaseConnection.appointments + "/" + BaseConnection.schedule;

            try
            {
                var resp = client.PostAsJsonAsync(uri, schedule).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            catch(Exception)
            {
                Worker.printServerError(this);
            }

            return false;
        }
    }
}
