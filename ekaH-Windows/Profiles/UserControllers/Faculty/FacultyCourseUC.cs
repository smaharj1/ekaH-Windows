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
using System.Collections;
using System.Web.Script.Serialization;
using MetroFramework;
using ekaH_Windows.Profiles.Forms;

namespace ekaH_Windows.Profiles.UserControllers
{
    /// <summary>
    /// This controller provides all the necessary features for faculty to manipulate the course.
    /// </summary>
    public partial class FacultyCourseUC : MetroFramework.Controls.MetroUserControl
    {
        /// <summary>
        /// It holds the email address of faculty.
        /// </summary>
        private string m_emailID;

        /// <summary>
        /// It holds all the courses that faculty is teaching.
        /// </summary>
        private List<Course> m_courses;
        
        /// <summary>
        /// This is a constructor. It initializes the email of the professor.
        /// </summary>
        /// <param name="a_emailID">It holds the email address.</param>
        public FacultyCourseUC(string a_emailID)
        {
            this.m_emailID = a_emailID;
            InitializeComponent();
        }
        
        /// <summary>
        /// This function gets all the courses taught by the professor once the form loads.
        /// </summary>
        /// <param name="a_sender">It holds the sender.</param>
        /// <param name="a_event">It holds the event args.</param>
        private void ViewCourseUC_Load(object a_sender, EventArgs a_event)
        {
            ExecuteGetRequest();
        }

        /// <summary>
        /// This function gets all the courses taught by the professor from the server.
        /// </summary>
        private void ExecuteGetRequest()
        {
            /// Removes the current values in course list if existing.
            if (m_courses != null)
            {
                m_courses.Clear();
                courseListView.Items.Clear();
            }

            /// Make a rest call to get all the courses info
            HttpClient client = NetworkClient.getInstance().getHttpClient();

            string requestURI = BaseConnection.g_coursesString + "/" + this.m_emailID + "/" + BaseConnection.g_singularFaculty;

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

        /// <summary>
        /// This function is triggered if the courses are clicked. 
        /// It should not do anything.
        /// </summary>
        /// <param name="a_sender">It holds the sender.</param>
        /// <param name="a_event">It holds the event args.</param>
        public void OnListItemClicked(object a_sender, EventArgs a_event)
        {
        }

        // It removes the selected course.
        /// <summary>
        /// This function removes the selected course.
        /// </summary>
        /// <param name="a_sender">It holds the sender.</param>
        /// <param name="a_event">It holds the event args.</param>
        private void RemoveCourse_Click(object a_sender, EventArgs a_event)
        {
            if (courseListView.SelectedItems.Count < 1)
            {
                MetroMessageBox.Show(this, "Please select an item below and then delete it here.",
                    "Select a course first", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            /// Asks the user before deleting it.
            if (MetroMessageBox.Show(this, "Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                /// Only one itemSelected can be selected at a time.
                ListViewItem itemSelected = courseListView.SelectedItems[0];

                Course courseSelected = (Course)itemSelected.Tag;

                HttpClient client = NetworkClient.getInstance().getHttpClient();

                string requestURI = BaseConnection.g_coursesString + "/" + courseSelected.CourseID;
                
                try
                {
                    /// Deletes the course from the server.
                    var response = client.DeleteAsync(requestURI).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        /// This means that the data has been successfully deleted.
                        DeleteItemFromView(itemSelected);
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch(Exception)
                {
                    Worker.printServerError(this);
                }
            }
        }

        /// <summary>
        /// This function deletes the selected course from the view.
        /// </summary>
        /// <param name="a_listItem">It holds the item that is selected.</param>
        private void DeleteItemFromView(ListViewItem a_listItem)
        {
            courseListView.Items.Remove(a_listItem);
        }

        /// <summary>
        /// This function opens the new form to view the details of the course selected and handle the assignments feature.
        /// </summary>
        /// <param name="a_sender">It holds the sender.</param>
        /// <param name="a_event">It holds the event args.</param>
        public void ViewDetails_Click(object a_sender, EventArgs a_event)
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

            CourseDetail courseDetailForm = new CourseDetail(selectedCourse, false);
            courseDetailForm.Show();
        }

        /// <summary>
        /// This function modifies the info once it is clicked. Only few of the details of the course can be modified.
        /// </summary>
        /// <param name="a_sender">It holds the sender.</param>
        /// <param name="a_event">It holds the event args.</param>
        private void ModifyCourse_Click(object a_sender, EventArgs a_event)
        {
            if (courseListView.SelectedItems.Count < 1)
            {
                MetroMessageBox.Show(this, "Please select an item below and then click this button.", "Select Course first", MessageBoxButtons.OK, MessageBoxIcon.Question);
                
                return;
            }

            /// Only one itemSelected can be selected at a time.
            ListViewItem itemSelected = courseListView.SelectedItems[0];

            Course selectedCourse = (Course)itemSelected.Tag;

            CourseModification modifyCourseForm = new CourseModification(selectedCourse);
            modifyCourseForm.ShowDialog();

            ExecuteGetRequest();

        }

        /// <summary>
        /// This function adds the course to the system.
        /// </summary>
        /// <param name="a_sender">It holds the sender.</param>
        /// <param name="a_event">It holds the event args.</param>
        private void AddCourse_Click(object a_sender, EventArgs a_event)
        {
            CourseModification createCourse = new CourseModification(m_emailID);
            createCourse.ShowDialog();

            ExecuteGetRequest();
        }
    }
}
