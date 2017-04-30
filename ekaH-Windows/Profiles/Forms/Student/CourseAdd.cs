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
    /// <summary>
    /// This class helps the students to add the course to their schedule.
    /// </summary>
    public partial class CourseAdd : MetroFramework.Forms.MetroForm
    {
        /// <summary>
        /// It holds the email address of the student.
        /// </summary>
        private string emailID;

        /// <summary>
        /// This is a constructor that initializes the email.
        /// </summary>
        /// <param name="a_email">It holds user's email.</param>
        public CourseAdd(string a_email)
        {
            emailID = a_email;
            InitializeComponent();
        }

        /// <summary>
        /// This function is triggered if the available courses tiles are clicked. It enrolls
        /// the students to the clicked tiles.
        /// </summary>
        /// <param name="a_sender">It holds the sender.</param>
        /// <param name="a_event">It holds the event.</param>
        public void CourseTileClicked(object a_sender, EventArgs a_event)
        {
            /// Gets the metro tile.
            MetroTile tile = (MetroTile)a_sender;
            Course course = (Course)tile.Tag;

            HttpClient client = NetworkClient.getInstance().getHttpClient();
            string requestURI = BaseConnection.g_studentString + "/" + emailID + "/" + BaseConnection.g_coursesString + "/" + course.CourseID;

            /// Student enrolls in the course selected.
            try
            {
                var response = client.PostAsync(requestURI, null).Result;

                if (response.IsSuccessStatusCode)
                {
                    this.Dispose();
                }
                else if (response.StatusCode == HttpStatusCode.Conflict)
                {
                    MetroMessageBox.Show(this, "You have already added this course.", 
                        "Course already added!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        /// <summary>
        /// This function makes a metro tile to display.
        /// </summary>
        /// <param name="a_course">It holds the course.</param>
        /// <param name="a_xAxis">It holds the x-coordinate.</param>
        /// <param name="a_yAxis">It holds the y-coordinate.</param>
        /// <returns></returns>
        private MetroTile MakeTile(Course a_course, int a_xAxis, int a_yAxis)
        {
            /// Creates a new tile object and fills the properties.
            MetroTile newTile = new MetroTile();
            string display = a_course.CourseName + "        " + a_course.Days + "        " + a_course.ProfessorID;
            newTile.Text = display;
            newTile.Location = new Point(a_xAxis, a_yAxis);
            newTile.Tag = a_course;
            newTile.Click += new EventHandler(CourseTileClicked);
            newTile.Size = new Size(resultPanel.Width - 20, 80);
            newTile.Cursor = Cursors.Hand;

            return newTile;
        }

        
        private void courseIDText_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void searchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
        }

        // This is the search tile
        /// <summary>
        /// This function enrolls the student to the course selected.
        /// </summary>
        /// <param name="a_sender">It holds the sender.</param>
        /// <param name="a_event">It holds the event.</param>
        private void MetroTile1_Click(object a_sender, EventArgs a_event)
        {
            /// It holds the list of courses available and then displays the list.
            List<Course> coursesReceived = new List<Course>();
            resultPanel.Controls.Clear();
            int x = 10, y = 10;

            /// Gets all the courses for the mentioned professor.
            if (!string.IsNullOrEmpty(courseIDText.Text))
            {
                Course course = ExecuteGetCourseWithID(courseIDText.Text);
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
            
            /// Make tiles and adds it to the display.
            foreach(var c in coursesReceived)
            {
                Course cour = (Course)c;
                MetroTile tile = MakeTile(cour, x, y);
                resultPanel.Controls.Add(tile);
                y += 90;
            }
        }

        /// <summary>
        /// This function gets the courses according to the course ID.
        /// </summary>
        /// <param name="a_courseID">It holds the course ID.</param>
        /// <returns>Returns the course received from the given course ID.</returns>
        private Course ExecuteGetCourseWithID(string a_courseID)
        {
            HttpClient client = NetworkClient.getInstance().getHttpClient();
            string requestURI = BaseConnection.g_coursesString + "/" + a_courseID + "/" + BaseConnection.g_singleString;

            Course course = null;
            try
            {
                /// List data response. This is the blocking call.
                var response = client.GetAsync(requestURI).Result;

                if (response.IsSuccessStatusCode)
                {
                    /// Stores the course if successfully received.
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
                Worker.printServerError(this);
            }

            return course;
        }

        /// <summary>
        /// This function gets the courses with the provided email id.
        /// </summary>
        /// <param name="a_email">It holds the email address.</param>
        /// <returns>Returns the list of courses according to the email.</returns>
        private List<Course> executeGetCoursesWithEmail(string a_email)
        {
            HttpClient client = NetworkClient.getInstance().getHttpClient();
            string requestURI = BaseConnection.g_coursesString + "/" + a_email + "/" + BaseConnection.g_singularFaculty;

            List<Course> list = null;
            try
            {
                /// List data response. This is the blocking call.
                var response = client.GetAsync(requestURI).Result;

                if (response.IsSuccessStatusCode)
                {
                    list = response.Content.ReadAsAsync<List<Course>>().Result;
                }
                else if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    /// Do not do anything.
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

            return list;
        }
    }
}
