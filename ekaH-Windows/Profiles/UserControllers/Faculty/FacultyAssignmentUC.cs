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

namespace ekaH_Windows.Profiles.UserControllers.Faculty
{
    public partial class FacultyAssignmentUC : MetroFramework.Controls.MetroUserControl
    {
        List<Assignment> openAssignments;

        public FacultyAssignmentUC()
        {
            openAssignments = new List<Assignment>();
            InitializeComponent();
        }

        /// <summary>
        /// Opens the assignment clicked by the professor and gives the details.
        /// </summary>
        /// <param name="assgn"></param>
        public void open(Assignment assgn)
        {
            /// Checks if the assignment was previously open to reduce the number of UC objects being formed.
            if (openAssignments.Contains(assgn))
            {
                int index = openAssignments.IndexOf(assgn);
                Assignment currentAssgn = openAssignments[index];

            }
            else
            {
                openAssignments.Add(assgn);
            }
        }
    }
}
