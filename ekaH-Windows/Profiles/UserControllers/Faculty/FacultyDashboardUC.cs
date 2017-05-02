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
    /// <summary>
    /// This function handles the dashboard of faculty. It is different from student
    /// dashboard.
    /// </summary>
    public partial class FacultyDashboardUC : MetroFramework.Controls.MetroUserControl
    {
        /// <summary>
        /// It holds the email address of faculty.
        /// </summary>
        public string m_emailID;

        /// <summary>
        /// This is a constructor that initializes the email.
        /// </summary>
        /// <param name="email"></param>
        public FacultyDashboardUC(string email)
        {
            m_emailID = email;
            InitializeComponent();

            /// Display the welcome message.
            welcomeLabel.Text = "Your immediate options made easy! Please choose from the menu and go right into it.";
        }

        /// <summary>
        /// This function handles modification of the course when the tile is clicked.
        /// </summary>
        /// <param name="a_sender">It holds the sender.</param>
        /// <param name="a_event">It holds the event args.</param>
        private void CourseTile_Click(object a_sender, EventArgs a_event)
        {
            CourseModification addCourse = new CourseModification(m_emailID);
            addCourse.ShowDialog();
        }

        /// <summary>
        /// This function handles updating the user info when update
        /// button is pressed.
        /// </summary>
        /// <param name="a_sender">It holds the sender.</param>
        /// <param name="a_event">It holds the event args.</param>
        private void UpdateInfoTile_Click(object a_sender, EventArgs a_event)
        {
            /// Starts the new form to get the information.
            FacultyProfile profile = FacultyProfile.getInstance(m_emailID);

            UpdateInfo update = new UpdateInfo(profile.m_faculty, false);
            update.ShowDialog();

            FacultyProfile.getInstance(m_emailID).GetFacultyInfo();
        }

        /// <summary>
        /// This function handles going online feature.
        /// </summary>
        /// <param name="a_sender">It holds the sender.</param>
        /// <param name="a_event">It holds the event args.</param>
        private void GoOnlineTile_Click(object a_sender, EventArgs a_event)
        {
            OnlineChat chat = new OnlineChat(m_emailID);
            chat.ShowDialog();
        }
    }
}
