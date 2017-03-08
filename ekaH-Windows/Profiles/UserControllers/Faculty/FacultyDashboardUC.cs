using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ekaH_Windows.Profiles.Forms;

namespace ekaH_Windows.Profiles.UserControllers
{
    public partial class FacultyDashboardUC : MetroFramework.Controls.MetroUserControl
    {
        public string emailID;

        public FacultyDashboardUC()
        {
            InitializeComponent();

            fillWelcome();
        }

        public FacultyDashboardUC(string email)
        {
            emailID = email;
            InitializeComponent();

            fillWelcome();
        }

        private void fillWelcome()
        {
            welcomeLabel.Text = "Your immediate options made easy! Please choose from the menu and go right into it.";
            
        }

        private void courseTile_Click(object sender, EventArgs e)
        {
            CourseModification addCourse = new CourseModification(emailID);
            addCourse.ShowDialog();

        }
        
        private void updateInfoTile_Click(object sender, EventArgs e)
        {
            FacultyProfile profile = FacultyProfile.getInstance(emailID);

            UpdateInfo update = new UpdateInfo(profile.Faculty);
            update.ShowDialog();

            FacultyProfile.getInstance(emailID).getFacultyInfo();
        }
    }
}
