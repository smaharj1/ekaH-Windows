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
using System.Net;

namespace ekaH_Windows.Profiles.UserControllers.Student
{
    public partial class StudentAssignmentUC : MetroFramework.Controls.MetroUserControl
    {
        private List<Assignment> openAssignments;
        private Assignment currentAssgn;


        public StudentAssignmentUC()
        {
            openAssignments = new List<Assignment>();
            InitializeComponent();
        }

        public void open (Assignment assgn)
        {
            // Checks if the assignment was previously open to reduce the number of UC objects being formed.
            if (openAssignments.Contains(assgn))
            {
                int index = openAssignments.IndexOf(assgn);
                currentAssgn = openAssignments[index];
            }
            else
            {
                openAssignments.Add(assgn);
                currentAssgn = assgn;
            }

            updateView();
            
        }

        private void updateView()
        {
            projectName.Text = currentAssgn.projectTitle;
            weightTextBox.Text = currentAssgn.weight >0 ?currentAssgn.weight.ToString() + "%" : "TBD";
            deadlineBox.Value = currentAssgn.deadline;
            assignmentRTB.Clear();

            string decodedString = WebUtility.UrlDecode(currentAssgn.content);
            // For now, just do the content.
            try
            {
                assignmentRTB.Rtf = decodedString;
            }
            catch (Exception)
            {
                assignmentRTB.Text = currentAssgn.content;
            }
        }
    }
}
