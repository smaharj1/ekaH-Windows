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

namespace ekaH_Windows.Profiles.UserControllers
{
    public partial class FacultyCourseUC : MetroFramework.Controls.MetroUserControl
    {
        private string emailID;
        private List<Course> courses;
        
        public FacultyCourseUC()
        {
            InitializeComponent();
        }

        public FacultyCourseUC(string emailID)
        {
            this.emailID = emailID;
            InitializeComponent();
            
        }
        

        private void ViewCourseUC_Load(object sender, EventArgs e)
        {
            executeGetRequest();
        }

        private void executeGetRequest()
        {
            if (courses != null)
            {
                courses.Clear();
                courseListView.Items.Clear();
            }

            // Make a rest call to get all the courses info
            HttpClient client = NetworkClient.getInstance().getHttpClient();

            string requestURI = BaseConnection.coursesString + "/" + this.emailID + "/" + BaseConnection.singularFaculty;

            // List data response. This is the blocking call.
            var response = client.GetAsync(requestURI).Result;

            if (response.IsSuccessStatusCode)
            {
                courses = response.Content.ReadAsAsync<List<Course>>().Result;

                foreach (Course singleCourse in courses)
                {
                    ListViewItem item = new ListViewItem(singleCourse.convertToArray());
                    item.Tag = singleCourse;
                    courseListView.Items.Add(item);
                }

            }
            else
            {
                MessageBox.Show("Could not get the courses information because of server acting up :)");
            }
        }

        public void onListItemClicked(object sender, EventArgs e)
        {
            //ListViewItem itemSelected = courseListView.SelectedItems[0];
            //MessageBox.Show(itemSelected.Text);
        }

        // It removes the selected course.
        private void removeCourse_Click(object sender, EventArgs e)
        {
            if (courseListView.SelectedItems.Count < 1)
            {
                MessageBox.Show("Please select an itemSelected below and then delete it here.");
                return;
            }

            if (MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Only one itemSelected can be selected at a time.
                ListViewItem itemSelected = courseListView.SelectedItems[0];

                Course courseSelected = (Course)itemSelected.Tag;

                HttpClient client = NetworkClient.getInstance().getHttpClient();

                string requestURI = BaseConnection.coursesString + "/" + courseSelected.CourseID;
                
                try
                {
                    
                    var response = client.DeleteAsync(requestURI).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        // This means that the data has been successfully deleted.
                        deleteItemFromView(itemSelected);
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch(Exception)
                {
                    MessageBox.Show("Server acted up.. ");
                }
            }
        }

        private void deleteItemFromView(ListViewItem listItem)
        {
            courseListView.Items.Remove(listItem);
        }

        // Modifies the info once it is clicked. Only few of the details of the course can be modified.
        private void modifyCourse_Click(object sender, EventArgs e)
        {
            if (courseListView.SelectedItems.Count < 1)
            {
                MessageBox.Show("Please select an item below and then click this button.");
                return;
            }

            // Only one itemSelected can be selected at a time.
            ListViewItem itemSelected = courseListView.SelectedItems[0];

            Course selectedCourse = (Course)itemSelected.Tag;

            CourseModification modifyCourseForm = new CourseModification(selectedCourse);
            modifyCourseForm.ShowDialog();

            executeGetRequest();

        }

        // Adds a course to the system.
        private void addCourse_Click(object sender, EventArgs e)
        {
            CourseModification createCourse = new CourseModification(emailID);
            createCourse.ShowDialog();

            executeGetRequest();
        }
    }
}
