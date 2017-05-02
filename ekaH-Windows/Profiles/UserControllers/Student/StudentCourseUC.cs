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
using System.Net.Http;
using MetroFramework;
using ekaH_Windows.Profiles.Forms.Student;
using ekaH_Windows.Profiles.Forms;

namespace ekaH_Windows.Profiles.UserControllers.Student
{
    /// <summary>
    /// This class is a controller to handle various student functionalities.
    /// </summary>
    public partial class StudentCourseUC : MetroFramework.Controls.MetroUserControl
    {
        /// <summary>
        /// It holds the parent's profile.
        /// </summary>
        private StudentProfile m_parentProfile { get; set; }

        /// <summary>
        /// It holds all the courses that the student is taking.
        /// </summary>
        private List<Course> m_courses;

        /// <summary>
        /// This is a constructor.
        /// </summary>
        /// <param name="a_profile">It holds the parent profile.</param>
        public StudentCourseUC(StudentProfile a_profile)
        {
            m_parentProfile = a_profile;
            m_courses = new List<Course>();

            InitializeComponent();
        }
        
        /// <summary>
        /// This function gets the student's basic information.
        /// </summary>
        public void ExecuteGetRequest()
        {
            if (m_courses != null)
            {
                m_courses.Clear();
                courseListView.Items.Clear();
            }

            /// Make a rest call to get all the courses info
            HttpClient client = NetworkClient.getInstance().getHttpClient();

            string requestURI = BaseConnection.g_studentString + "/" + m_parentProfile.m_userEmail + "/" + BaseConnection.g_coursesString;

            try
            {
                /// List data response. This is the blocking call.
                var response = client.GetAsync(requestURI).Result;

                if (response.IsSuccessStatusCode)
                {
                    m_courses = response.Content.ReadAsAsync<List<Course>>().Result;

                    foreach (Course singleCourse in m_courses)
                    {
                        ListViewItem item = new ListViewItem(singleCourse.ConvertToArray());
                        item.Tag = singleCourse;
                        courseListView.Items.Add(item);
                    }
                }
                else
                {
                    Worker.printServerError(this);
                }
            }
            catch(Exception ex)
            {
                Worker.printServerError(this);
            }
        }

        /// <summary>
        /// This function gets the user's information.
        /// </summary>
        /// <param name="a_sender">It holds the sender.</param>
        /// <param name="a_event">It holds the event.</param>
        private void StudentCourseUC_Load(object a_sender, EventArgs a_event)
        {
            ExecuteGetRequest();
        }

        /// <summary>
        /// This function is triggered while adding course button is clicked.
        /// </summary>
        /// <param name="a_sender">It holds the sender.</param>
        /// <param name="a_event">It holds the event.</param>
        private void AddCourse_Click(object a_sender, EventArgs a_event)
        {
            // Open the new form to get the info of the course.
            // The info would be the courseID.
            CourseAdd courseAdd = new CourseAdd(m_parentProfile.m_userEmail);
            courseAdd.ShowDialog();

            ExecuteGetRequest();
        }

        /// <summary>
        /// This function is triggered when dropping course button is clicked.
        /// </summary>
        /// <param name="a_sender">It holds the sender.</param>
        /// <param name="a_event">It holds the event.</param>
        private void DropCourse_Click(object a_sender, EventArgs a_event)
        {
            if (courseListView.SelectedItems.Count < 1)
            {
                MetroMessageBox.Show(this, "Please select an item below and then delete it here.",
                    "Select a course first", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (MetroMessageBox.Show(this, "Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                /// Only one itemSelected can be selected at a time.
                ListViewItem itemSelected = courseListView.SelectedItems[0];

                Course courseSelected = (Course)itemSelected.Tag;

                HttpClient client = NetworkClient.getInstance().getHttpClient();

                string requestURI = BaseConnection.g_studentString + "/" + m_parentProfile.m_userEmail +"/"+ 
                    BaseConnection.g_coursesString +"/"+ courseSelected.CourseID;

                try
                {
                    /// Deletes the course.
                    var response = client.DeleteAsync(requestURI).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        /// This means that the data has been successfully deleted.
                        courseListView.Items.Remove(itemSelected);
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    Worker.printServerError(this);
                }
            }
        }

        /// <summary>
        /// This function opens a new form that contains more data on the course.
        /// </summary>
        /// <param name="a_sender">It holds the sender.</param>
        /// <param name="a_event">It holds the event.</param>
        private void DetailsTile_Click(object a_sender, EventArgs a_event)
        {
            /// Checks if the course is selected first.
            if (courseListView.SelectedItems.Count < 1)
            {
                MetroMessageBox.Show(this, "Please select an item below and then click this button.", "Select Course first", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            /// Only one itemSelected can be selected at a time.
            ListViewItem itemSelected = courseListView.SelectedItems[0];

            Course selectedCourse = (Course)itemSelected.Tag;

            CourseDetail courseDetailForm = new CourseDetail(selectedCourse, true, m_parentProfile.m_userEmail);
            courseDetailForm.Show();
        }
    }
}
