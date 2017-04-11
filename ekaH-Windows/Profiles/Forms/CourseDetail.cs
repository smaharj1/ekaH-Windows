using ekaH_Windows.Model;
using ekaH_Windows.Profiles.UserControllers.Faculty;
using ekaH_Windows.Profiles.UserControllers.Student;
using MetroFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ekaH_Windows.Profiles.Forms
{
    public partial class CourseDetail : MetroFramework.Forms.MetroForm
    {
        private Course course { get; set; }
        private bool isStudent = false;

        private FacultyAssignmentUC ucFacAssignment;
        private StudentAssignmentUC ucStdAssignment;

        public CourseDetail(Course givenCourse, bool isStd)
        {
            course = givenCourse;
            isStudent = isStd;

            InitializeComponent();
        }

        private void CourseDetail_Load(object sender, EventArgs e)
        {
            Text = course.CourseName;
            
            // Gets all the projects in the course.
            List<Assignment> assignments = getAssignmentsByCourseID();
            
            // Populate the list
            populateList(assignments);

            addAssignment.Visible = isStudent ? false : true;
        }

        private void assignmentList_OnMouseHover(object sender, EventArgs e)
        {
        }

        private void assignmentList_Click(object sender, MouseEventArgs e)
        {
            Assignment clickedAssignment = (Assignment) assignmentList.SelectedItems[0].Tag;
            
            if (!isStudent)
            {
                if (ucFacAssignment == null)
                {
                    ucFacAssignment = new FacultyAssignmentUC();
                    ucFacAssignment.Dock = DockStyle.Fill;

                    courseDetailPanel.Controls.Add(ucFacAssignment);
                }

                ucFacAssignment.open(clickedAssignment);
                ucFacAssignment.BringToFront();
                

            }
            else
            {
                if (ucStdAssignment == null)
                {
                    ucStdAssignment = new StudentAssignmentUC();
                    ucStdAssignment.Dock = DockStyle.Fill;

                    courseDetailPanel.Controls.Add(ucStdAssignment);
                }

                ucStdAssignment.open(clickedAssignment);
                ucStdAssignment.BringToFront();
            }
        }

        /// <summary>
        ///  Gets the list of assignments by the given course ID.
        /// </summary>
        /// <returns>List of assignments</returns>
        private List<Assignment> getAssignmentsByCourseID()
        {
            HttpClient client = NetworkClient.getInstance().getHttpClient();

            string uri = BaseConnection.assignments + "/" + BaseConnection.coursesString + "/" + course.CourseID;
            List<Assignment> assignments = new List<Assignment>();

            try
            {
                var response = client.GetAsync(uri).Result;

                if (response.StatusCode ==HttpStatusCode.NotFound)
                {
                    MetroMessageBox.Show(this, "No assignments exist in this course",
                        "No Assignments exists!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else if (response.IsSuccessStatusCode)
                {
                    assignments = response.Content.ReadAsAsync<List<Assignment>>().Result;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                return null;
            }

            return assignments;
        }

        /// Populates the assignment list
        private void populateList(List<Assignment> list)
        {
            assignmentList.Items.Clear();

            foreach(Assignment assignment in list)
            {
                ListViewItem item = new ListViewItem(assignment.projectNum + ": " + assignment.projectTitle);
                item.Tag = assignment;

                assignmentList.Items.Add(item);
            }
        }

        /// <summary>
        /// On Click listener for adding the assignment.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroTile1_Click(object sender, EventArgs e)
        {
            if (ucFacAssignment == null)
            {
                ucFacAssignment = new FacultyAssignmentUC();
                ucFacAssignment.Dock = DockStyle.Fill;

                courseDetailPanel.Controls.Add(ucFacAssignment);
            }

            ucFacAssignment.makeNew(course, assignmentList.Items.Count+1);
            ucFacAssignment.BringToFront();
        }
    }
}
