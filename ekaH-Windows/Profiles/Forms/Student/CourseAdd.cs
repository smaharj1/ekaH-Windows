using ekaH_Windows.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
using MetroFramework;
using System.Net.Http;
using System.Collections;
using System.Net;

namespace ekaH_Windows.Profiles.Forms.Student
{
    public partial class CourseAdd : MetroFramework.Forms.MetroForm
    {
        private int tempX = 10;
        private int tempY = 10;
        private string  emailID;
        public CourseAdd(string email)
        {
            emailID = email;
            InitializeComponent();

        }

        public void courseTileClicked(object sender, EventArgs e)
        {
            MetroTile tile = (MetroTile)sender;
            Course course = (Course)tile.Tag;

            HttpClient client = NetworkClient.getInstance().getHttpClient();
            string requestURI = BaseConnection.studentString + "/" + emailID + "/" + BaseConnection.coursesString + "/" + course.CourseID;

            // Student enrolls in the course selected.
            try
            {
                var response = client.PostAsync(requestURI, null).Result;

                if (response.IsSuccessStatusCode)
                {
                    this.Dispose();
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                MetroMessageBox.Show(this, "Server went blerp!", "Server error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private MetroTile makeTile(Course course, int x, int y)
        {
            MetroTile newTile = new MetroTile();
            string display = course.CourseName + "        " + course.Days + "        " + course.ProfessorID;
            newTile.Text = display;
            newTile.Location = new Point(x, y);
            newTile.Tag = course;
            newTile.Click += new EventHandler(courseTileClicked);
            newTile.Size = new Size(resultPanel.Width - 20, 80);

            return newTile;

        }


        private void courseIDText_KeyDown(object sender, KeyEventArgs e)
        {
            //searchTextBox.Enabled = false;
        }

        private void searchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            //courseIDText.Enabled = false;
        }

        // This is the search tile
        private void metroTile1_Click(object sender, EventArgs e)
        {
            List<Course> coursesReceived = new List<Course>();
            resultPanel.Controls.Clear();
            int x = 10, y = 10;

            if (!string.IsNullOrEmpty(courseIDText.Text))
            {
                Course course = executeGetCourseWithID(courseIDText.Text);
                if (course != null)
                {
                    coursesReceived.Add(course);
                }
                else
                {
                    MetroMessageBox.Show(this, "There is no course with that id.", "Course not found!",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (!string.IsNullOrEmpty(searchTextBox.Text))
            {
                List<Course> courses = executeGetCoursesWithEmail(searchTextBox.Text);

                if (courses == null)
                {
                    MetroMessageBox.Show(this, "There is no course with that email provided.", "Course not found!",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    coursesReceived.AddRange(courses);
                }
            }
            else
            {
                MetroMessageBox.Show(this, "Please check the fields again.", "Incorrect fields!",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            foreach(var c in coursesReceived)
            {
                Course cour = (Course)c;
                MetroTile tile = makeTile(cour, x, y);
                resultPanel.Controls.Add(tile);
                y += 90;
            }
        }

        private Course executeGetCourseWithID(string courseID)
        {
            HttpClient client = NetworkClient.getInstance().getHttpClient();
            string requestURI = BaseConnection.coursesString + "/" + courseID + "/" + BaseConnection.singleString;

            Course course = null;
            try
            {
                // List data response. This is the blocking call.
                var response = client.GetAsync(requestURI).Result;

                if (response.IsSuccessStatusCode)
                {
                    course = response.Content.ReadAsAsync<Course>().Result;
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    course = null;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                MetroMessageBox.Show(this, "Server went blerp!", "Server error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return course;
        }

        private List<Course> executeGetCoursesWithEmail(string email)
        {
            HttpClient client = NetworkClient.getInstance().getHttpClient();
            string requestURI = BaseConnection.coursesString + "/" + email + "/" + BaseConnection.singularFaculty;

            List<Course> list = null;
            try
            {
                // List data response. This is the blocking call.
                var response = client.GetAsync(requestURI).Result;

                if (response.IsSuccessStatusCode)
                {
                    list = response.Content.ReadAsAsync<List<Course>>().Result;
                }
                else if (response.StatusCode == HttpStatusCode.BadRequest)
                {

                }
                else 
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                MetroMessageBox.Show(this, "Server went blerp!", "Server error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return list;
        }
    }
}
