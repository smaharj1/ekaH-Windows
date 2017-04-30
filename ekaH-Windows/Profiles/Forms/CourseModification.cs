using ekaH_Windows.Model;
using ekaH_Windows.Profiles.UserControllers;
using MetroFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ekaH_Windows.Profiles
{
    /// <summary>
    /// This class modifies/creates the course.
    /// </summary>
    public partial class CourseModification : MetroFramework.Forms.MetroForm
    {
        /// <summary>
        /// It stores the course information in the course object.
        /// </summary>
        private Course m_course;

        /// <summary>
        /// It holds the email address of the modifier.
        /// </summary>
        private string m_emailID;

        /// <summary>
        /// It checks if this is modification request or not.
        /// </summary>
        private bool m_modify;
        
        /// <summary>
        /// This is a constructor that initializes the class variables and fills the data if course if provided.
        /// </summary>
        /// <param name="a_course">It holds the course object.</param>
        public CourseModification(Course a_course)
        {
            m_modify = true;
            this.m_course = a_course;
            InitializeComponent();

            /// Changes the text on the screen
            this.Text = "Modify your course";
            modifyButton.Text = "Modify";

            FillData();
        }

        /// <summary>
        /// This is a constructor for creating a new course.
        /// </summary>
        /// <param name="a_email">It is the email address of the faculty.</param>
        public CourseModification(string a_email)
        {
            m_modify = false;
            m_emailID = a_email;
            InitializeComponent();
            
            /// Changes the text.
            this.Text = "Create your course";
            modifyButton.Text = "Create";

        }

        /// <summary>
        /// This function fills the data in the input fields if it already consists those information of the course.
        /// </summary>
        private void FillData()
        {
            /// It changes the texts of input fields that asks the course information from the user.
            if (m_course != null)
            {
                courseNameText.Text = string.IsNullOrEmpty(m_course.CourseName) ? courseNameText.Text : m_course.CourseName ;
                descriptionText.Text = string.IsNullOrEmpty(m_course.CourseDescription) ? descriptionText.Text : m_course.CourseDescription;

                yearText.Text = m_course.Year.ToString();
                semesterText.Text = m_course.Semester == "F" ? "Fall" : "Spring";

                daysText.Text = m_course.Days;
                
                startTimeText.Value = new DateTime(2000, 1, 1, m_course.StartTime.Hours, m_course.StartTime.Minutes, 0);
                endTimeText.Value = new DateTime(2000, 1, 1, m_course.EndTime.Hours, m_course.EndTime.Minutes, 0);

            }
        }

        /// <summary>
        /// This function parses the data from the input fields on the screen and stores it in course object.
        /// </summary>
        /// <param name="a_course">It holds the course object.</param>
        private void ParseDataFromFields(ref Course a_course)
        {
            // Puts the desired values in the properties of Course object.
            a_course.CourseDescription = descriptionText.Text;
            a_course.Year = int.Parse(yearText.Text);
            a_course.CourseName = courseNameText.Text;

            // Semester values are converted into single characters.
            if (string.Equals(semesterText.Text, "fall", StringComparison.OrdinalIgnoreCase))
            {
                a_course.Semester = "F";
            }
            else
            {
                a_course.Semester = "S";
            }
            
            a_course.Days = daysText.Text;

            /// Puts the time information to the object.
            TimeSpan tempTime = startTimeText.Value.TimeOfDay;
            
            a_course.StartTime = new TimeSpan(tempTime.Hours, tempTime.Minutes, 0);

            tempTime = endTimeText.Value.TimeOfDay;

            a_course.EndTime = new TimeSpan(tempTime.Hours, tempTime.Minutes, 0);
        }

        /// <summary>
        /// This function modifies the course by modifying it in the server.
        /// </summary>
        /// <param name="a_sender">It holds the sender object.</param>
        /// <param name="a_event">It holds the event arguments.</param>
        private void ModifyButton_Click(object a_sender, EventArgs a_event)
        {
            // Verifies all the fields and then makes the call to the server.
            if (verifyFields())
            {
                HttpClient client = NetworkClient.getInstance().getHttpClient();
                
                /// Modifies if modifying current course. Else, it sends the creation request to the server.
                if (m_modify)
                {
                    string id = m_course.CourseID;
                    ParseDataFromFields(ref m_course);

                    /// Make a REST call to modification.
                    string requestURI = BaseConnection.g_coursesString  + "/" + id + "/";

                    var response = client.PutAsJsonAsync<Course>(requestURI, m_course).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        MetroMessageBox.Show(this, "Successfully modified", "Modified", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        
                    }
                    else
                    {
                        Worker.printServerError(this);
                    }
                }
                else
                {
                    // Make a REST call to creating the course.
                    m_course = new Course();
                    m_course.ProfessorID = m_emailID;

                    // Parses the data from the fields.
                    ParseDataFromFields(ref m_course);

                    string requestURI = BaseConnection.g_coursesString  + "/";

                    var response = client.PostAsJsonAsync<Course>(requestURI, m_course).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        MetroMessageBox.Show(this, "Successfully created", "Created",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        Worker.printServerError(this);
                    }
                }
            }
            else
            {
                MetroMessageBox.Show(this, "Incorrect values in the fields", "Incorrect entry",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        /// <summary>
        /// This function verifies all the input fields.
        /// </summary>
        /// <returns>Returns true if all the fields have required values.</returns>
        private bool verifyFields()
        {
            /// Checks if the course name is correctly set.
            if (string.IsNullOrEmpty(courseNameText.Text) || string.IsNullOrWhiteSpace(courseNameText.Text))
            {
                return false;
            }

            /// Checks if the year is correctly set.
            if (string.IsNullOrEmpty(yearText.Text) || string.IsNullOrWhiteSpace(yearText.Text))
            {
                return false;
            }

            /// Checks if the semester value is correctly set.
            if (!string.Equals(semesterText.Text, "fall", StringComparison.OrdinalIgnoreCase) && !string.Equals(semesterText.Text, "spring", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            /// Checks if the start time is correctly set.
            if (startTimeText.Value > endTimeText.Value)
            {
                return false;
            }

            /// Checks if the days text is correctly set.
            if (daysText.Text.Length >7 || daysText.Text.Length < 1)
            {
                return false;
            }

            return true;
        }
    }
}
