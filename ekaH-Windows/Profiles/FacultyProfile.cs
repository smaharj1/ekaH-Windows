using ekaH_Windows.Profiles.UserControllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ekaH_Windows.Profiles
{
    public partial class FacultyProfile : MetroFramework.Forms.MetroForm
    {
        private string userEmail;

        private Dashboard ucDashboard;
        private FacultyCourseUC ucCourse;

        public FacultyProfile(string email)
        {
            InitializeComponent();

            userEmail = email;
        }

        private void FacultyProfile_Load(object sender, EventArgs e)
        {
            // Make REST calls here to handle bring up all the information needed.
            viewDashboard();
            

        }

        private void viewDashboard()
        {
            if (ucDashboard == null)
            {
                ucDashboard = new Dashboard();
                ucDashboard.Dock = DockStyle.Fill;

                contentPanel.Controls.Add(ucDashboard);
            }
            else
            {
                contentPanel.Controls["Dashboard"].BringToFront();
            }
        }



        private void dashboardControl_Click(object sender, EventArgs e)
        {
        }

        private void coursesControl_Click(object sender, EventArgs e)
        {
        }

        private void tabControl_Click(object sender, EventArgs e)
        {
            TabPage selectedTab = tabControl.SelectedTab;

            if (selectedTab == onlineChatTab)
            {
                // Handle the function for displaying chat
            }
            else if (selectedTab == coursesTab)
            {
                if (ucCourse == null)
                {
                    ucCourse = new FacultyCourseUC();
                    ucCourse.Dock = DockStyle.Fill;

                    contentPanel.Controls.Add(ucCourse);
                }

                contentPanel.Controls["FacultyCourseUC"].BringToFront();
                
            }
            else if (selectedTab == appointmentTab)
            {

            }
            else
            {
                // This will open the dashboard by default
                viewDashboard();
            }

        }
    }
}
