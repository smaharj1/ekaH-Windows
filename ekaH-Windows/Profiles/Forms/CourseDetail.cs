using ekaH_Windows.Model;
using ekaH_Windows.Profiles.UserControllers.Faculty;
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
        Course course;
        bool isStudent = false;

        FacultyAssignmentUC ucFacAssignment;

        public CourseDetail(Course givenCourse, bool isStd)
        {
            course = givenCourse;
            isStudent = isStd;

            InitializeComponent();
        }

        private void CourseDetail_Load(object sender, EventArgs e)
        {
            Text = course.CourseName;

            if (isStudent)
            {

            }
            else
            {
                if (ucFacAssignment == null)
                {
                    ucFacAssignment = new FacultyAssignmentUC();
                    ucFacAssignment.Dock = DockStyle.Fill;

                    courseDetailPanel.Controls.Add(ucFacAssignment);
                }
                courseDetailPanel.BringToFront();
            }

            // Gets all the projects in the course.
            List<Assignment> assignments = getAssignmentsByCourseID();

            // Populate the list
            populateList(assignments);
        }

        private void assignmentList_OnMouseHover(object sender, EventArgs e)
        {
        }

        private void assignmentList_Click(object sender, MouseEventArgs e)
        {
            Assignment clickedAssignment = (Assignment) assignmentList.SelectedItems[0].Tag;
            
            if (!isStudent)
            {
                ucFacAssignment.open(clickedAssignment);
            }
            else
            {

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
                    MetroMessageBox.Show(this, "No assignments exist in this course. Please Add the assignment.",
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

    }
}
