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
    /// <summary>
    /// This class displays the details of the course such as assignments given and the submissions for the assignment.
    /// </summary>
    public partial class CourseDetail : MetroFramework.Forms.MetroForm
    {
        /// <summary>
        /// It holds the current course selected.
        /// </summary>
        private Course m_course { get; set; }

        /// <summary>
        /// It holds if student is signed in.
        /// </summary>
        private bool m_isStudent = false;

        /// <summary>
        /// It holds the faculty's email.
        /// </summary>
        private string m_facEmail;

        /// <summary>
        /// It holds the student's email.
        /// </summary>
        private string m_studentEmail;

        /// <summary>
        /// It holds the user controller for faculty's assignments giving various faculty functionalities.
        /// </summary>
        private FacultyAssignmentUC m_ucFacAssignment;

        /// <summary>
        /// It holds the user controller for stuent assignment giving student related functionalities.
        /// </summary>
        private StudentAssignmentUC m_ucStdAssignment;

        /// <summary>
        /// This is a constructor that initializes course and faculty emails.
        /// </summary>
        /// <param name="a_givenCourse">It holds the given course.</param>
        /// <param name="a_isStd">It holds if student is logged in.</param>
        /// <param name="a_email">It holds the faculty's email.</param>
        public CourseDetail(Course a_givenCourse, bool a_isStd, string a_email = null)
        {
            // Assigns the courses and emails accordingly.
            m_course = a_givenCourse;
            m_isStudent = a_isStd;
            if (m_isStudent) m_studentEmail = a_email;
            m_facEmail = m_course.ProfessorID;

            InitializeComponent();
        }

        /// <summary>
        /// This function populates the existing assignments in the course.
        /// </summary>
        /// <param name="a_sender">It holds the sender object.</param>
        /// <param name="a_eventArgs">It holds the event arguments.</param>
        private void CourseDetail_Load(object a_sender, EventArgs a_eventArgs)
        {
            Text = m_course.CourseName;
            
            /// Gets all the projects in the course.
            List<Assignment> assignments = GetAssignmentsByCourseID();
            
            /// Populate the list
            PopulateList(assignments);

            addAssignment.Visible = m_isStudent ? false : true;
        }

        private void assignmentList_OnMouseHover(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// This function displays details of the assignment that is assigned.
        /// </summary>
        /// <param name="a_sender">It holds the sender object.</param>
        /// <param name="a_eventArgs">It holds the event arguments.</param>
        private void AssignmentList_Click(object a_sender, MouseEventArgs a_eventArgs)
        {
            Assignment clickedAssignment = (Assignment) assignmentList.SelectedItems[0].Tag;
            
            /// Redirects the functionality to the respective user controller depending on if student or professor is logged in.
            if (!m_isStudent)
            {
                /// Adds the user controller if it has not been done yet. Otherwise, brings the controller to the front.
                if (m_ucFacAssignment == null)
                {
                    m_ucFacAssignment = new FacultyAssignmentUC(m_facEmail);
                    m_ucFacAssignment.Dock = DockStyle.Fill;

                    courseDetailPanel.Controls.Add(m_ucFacAssignment);
                }

                m_ucFacAssignment.Open(clickedAssignment);
                m_ucFacAssignment.BringToFront();
            }
            else
            {
                /// Adds the user controller if it has not been done yet. Otherwise, brings the controller to the front.
                if (m_ucStdAssignment == null)
                {
                    m_ucStdAssignment = new StudentAssignmentUC(m_studentEmail);
                    m_ucStdAssignment.Dock = DockStyle.Fill;

                    courseDetailPanel.Controls.Add(m_ucStdAssignment);
                }

                m_ucStdAssignment.Open(clickedAssignment);
                m_ucStdAssignment.BringToFront();
            }
        }

        /// <summary>
        ///  Gets the list of assignments by the given course ID.
        /// </summary>
        /// <returns>Returns the list of assignments for the given course ID.</returns>
        private List<Assignment> GetAssignmentsByCourseID()
        {
            /// Gets the instance of the client.
            HttpClient client = NetworkClient.getInstance().getHttpClient();

            string uri = BaseConnection.g_assignments + "/" + BaseConnection.g_coursesString + "/" + m_course.CourseID;

            /// It holds all the assignments of the given course.
            List<Assignment> assignments = new List<Assignment>();

            try
            {
                /// Makes the call to the server and finds out all the assignments.
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

        /// <summary>
        /// This function populates the list of assignments into the UI.
        /// </summary>
        /// <param name="a_list">It holds the information of all the assignments.</param>
        private void PopulateList(List<Assignment> a_list)
        {
            assignmentList.Items.Clear();

            /// Adds all the assignment names to the screen.
            foreach(Assignment assignment in a_list)
            {
                ListViewItem item = new ListViewItem(assignment.projectNum + ": " + assignment.projectTitle);
                item.Tag = assignment;

                assignmentList.Items.Add(item);
            }
        }

        /// <summary>
        /// This function is On Click listener for adding the assignment.
        /// </summary>
        /// <param name="a_sender">It holds the sender object.</param>
        /// <param name="a_event">It holds the event arguments.</param>
        private void metroTile1_Click(object a_sender, EventArgs a_event)
        {
            // Checks if user controller exists. If not, then creates a new one then opens a form to create an assignment.
            if (m_ucFacAssignment == null)
            {
                m_ucFacAssignment = new FacultyAssignmentUC(m_facEmail);
                m_ucFacAssignment.Dock = DockStyle.Fill;

                courseDetailPanel.Controls.Add(m_ucFacAssignment);
            }

            m_ucFacAssignment.MakeNew(m_course, assignmentList.Items.Count+1);
            m_ucFacAssignment.BringToFront();
        }
    }
}
