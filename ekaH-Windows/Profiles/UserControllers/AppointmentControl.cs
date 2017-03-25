using System;
using ekaH_Windows.Profiles.UserControllers.Student;
using System.Windows.Forms;

namespace ekaH_Windows.Profiles.UserControllers
{
    public partial class AppointmentControl : MetroFramework.Controls.MetroUserControl
    {
        private Object Parent { get; set; }
        private bool isStudent;
        private Object ucController;

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
