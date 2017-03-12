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
    public partial class StudentDashboardUC : MetroFramework.Controls.MetroUserControl
    {
        private StudentProfile parent;

        public StudentDashboardUC(StudentProfile profile)
        {
            InitializeComponent();
            parent = profile;
        }

        private void updateInfoTile_Click(object sender, EventArgs e)
        {
            UpdateInfo update = new UpdateInfo(parent.CurrentStudent, true);
            update.ShowDialog();

            parent.getStudentInfo();
        }

        private void enrollCourseTile_Click(object sender, EventArgs e)
        {
            CourseAdd addCourse = new CourseAdd(parent.UserEmail);
            addCourse.ShowDialog();
        }
    }
}
