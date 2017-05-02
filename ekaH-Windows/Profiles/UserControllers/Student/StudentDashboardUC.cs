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
using ekaH_Windows.Profiles.Forms.Student;

namespace ekaH_Windows.Profiles.UserControllers.Student
{
    /// <summary>
    /// This class is a controller for student's dashboard.
    /// </summary>
    public partial class StudentDashboardUC : MetroFramework.Controls.MetroUserControl
    {
        /// <summary>
        /// It holds the parent's profile.
        /// </summary>
        private StudentProfile m_parent;

        /// <summary>
        /// This is a constructor.
        /// </summary>
        /// <param name="a_profile">It holds the parent profile.</param>
        public StudentDashboardUC(StudentProfile a_profile)
        {
            InitializeComponent();
            m_parent = a_profile;
        }

        /// <summary>
        /// This function is triggered when update tile is clicked.
        /// </summary>
        /// <param name="a_sender">It holds the sender.</param>
        /// <param name="a_event">It holds the event.</param>
        private void UpdateInfoTile_Click(object a_sender, EventArgs a_event)
        {
            UpdateInfo update = new UpdateInfo(m_parent.m_currentStudent, true);
            update.ShowDialog();

            m_parent.GetStudentInfo();
        }

        /// <summary>
        /// This function is triggered when enrolling in a course.
        /// </summary>
        /// <param name="a_sender">It holds the sender.</param>
        /// <param name="a_event">It holds the event.</param>
        private void EnrollCourseTile_Click(object a_sender, EventArgs a_event)
        {
            CourseAdd addCourse = new CourseAdd(m_parent.m_userEmail);
            addCourse.ShowDialog();
        }

        /// <summary>
        /// This function is triggered when going online.
        /// </summary>
        /// <param name="a_sender">It holds the sender.</param>
        /// <param name="a_event">It holds the event.</param>
        private void GoOnlineTile_Click(object a_sender, EventArgs a_event)
        {
            OnlineChat chat = new OnlineChat(m_parent.m_userEmail);
            chat.ShowDialog();
        }
    }
}
