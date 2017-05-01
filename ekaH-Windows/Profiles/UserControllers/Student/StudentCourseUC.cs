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
    public partial class StudentCourseUC : MetroFramework.Controls.MetroUserControl
    {
        private StudentProfile ParentProfile { get; set; }
        private List<Course> courses;

        public StudentCourseUC(StudentProfile profile)
        {
            ParentProfile = profile;
            courses = new List<Course>();

            InitializeComponent();

            
        }
        
        public void executeGetRequest()
        {
            if (courses != null)
            {
                courses.Clear();
                courseListView.Items.Clear();
            }

            // Make a rest call to get all the courses info
            HttpClient client = NetworkClient.getInstance().getHttpClient();

            string requestURI = BaseConnection.g_studentString + "/" + ParentProfile.m_userEmail + "/" + BaseConnection.g_coursesString;

            // List data response. This is the blocking call.
            var response = client.GetAsync(requestURI).Result;

            if (response.IsSuccessStatusCode)
            {
                courses = response.Content.ReadAsAsync<List<Course>>().Result;

                foreach (Course singleCourse in courses)
                {
                    ListViewItem item = new ListViewItem(singleCourse.ConvertToArray());
                    item.Tag = singleCourse;
                    courseListView.Items.Add(item);
                }

            }
            else
            {
                MetroMessageBox.Show(this, "Could not get the courses information because of server acting up :)",
                    "Server error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void StudentCourseUC_Load(object sender, EventArgs e)
        {
            try
            {
                executeGetRequest();
            }
            catch(Exception)
            {
                // This means that the server is not running
                MetroMessageBox.Show(this.Parent, "Server not running", "The server seems to be acting up. Please try again later",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addCourse_Click(object sender, EventArgs e)
        {
            // Open the new form to get the info of the course.
            // The info would be the courseID.
            CourseAdd courseAdd = new CourseAdd(ParentProfile.m_userEmail);
            courseAdd.ShowDialog();

            executeGetRequest();
        }

        private void dropCourse_Click(object sender, EventArgs e)
        {
            if (courseListView.SelectedItems.Count < 1)
            {
                MetroMessageBox.Show(this, "Please select an item below and then delete it here.",
                    "Select a course first", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (MetroMessageBox.Show(this, "Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Only one itemSelected can be selected at a time.
                ListViewItem itemSelected = courseListView.SelectedItems[0];

                Course courseSelected = (Course)itemSelected.Tag;

                HttpClient client = NetworkClient.getInstance().getHttpClient();

                string requestURI = BaseConnection.g_studentString + "/" + ParentProfile.m_userEmail +"/"+ 
                    BaseConnection.g_coursesString +"/"+ courseSelected.CourseID;

                try
                {

                    var response = client.DeleteAsync(requestURI).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        // This means that the data has been successfully deleted.
                        courseListView.Items.Remove(itemSelected);
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Server acted up.. ");
                }
            }
        }

        private void detailsTile_Click(object sender, EventArgs e)
        {
            // Checks if the course is selected first.
            if (courseListView.SelectedItems.Count < 1)
            {
                MetroMessageBox.Show(this, "Please select an item below and then click this button.", "Select Course first", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            // Only one itemSelected can be selected at a time.
            ListViewItem itemSelected = courseListView.SelectedItems[0];

            Course selectedCourse = (Course)itemSelected.Tag;

            CourseDetail courseDetailForm = new CourseDetail(selectedCourse, true, ParentProfile.m_userEmail);
            courseDetailForm.Show();
        }
    }
}
