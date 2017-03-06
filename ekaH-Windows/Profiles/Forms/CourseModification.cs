using ekaH_Windows.Model;
using ekaH_Windows.Profiles.UserControllers;
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
    public partial class CourseModification : MetroFramework.Forms.MetroForm
    {
        private Course course;
        private string emailID;
        private bool modify;
        
        public CourseModification(Course course)
        {
            modify = true;
            this.course = course;
            InitializeComponent();

            CourseModification.ActiveForm.Text = "Modify your course";
            modifyButton.Text = "Modify";

            fillData();
        }

        public CourseModification(string email)
        {
            modify = false;
            emailID = email;
            InitializeComponent();

            CourseModification.ActiveForm.Text = "Create your course";
            modifyButton.Text = "Create";

        }

        private void fillData()
        {
            if (course != null)
            {
                courseNameText.Text = string.IsNullOrEmpty(course.CourseName) ? courseNameText.Text : course.CourseName ;
                descriptionText.Text = string.IsNullOrEmpty(course.CourseDescription) ? descriptionText.Text : course.CourseDescription;

                yearText.Text = course.Year.ToString();
                semesterText.Text = course.Semester == "F" ? "Fall" : "Spring";

                daysText.Text = course.Days;
                
                startTimeText.Value = new DateTime(2000, 1, 1, course.StartTime.Hours, course.StartTime.Minutes, 0);
                endTimeText.Value = new DateTime(2000, 1, 1, course.EndTime.Hours, course.EndTime.Minutes, 0);

            }
        }

        private void parseDataFromFields(ref Course course)
        {
            course.CourseDescription = descriptionText.Text;
            course.Year = int.Parse(yearText.Text);
            course.CourseName = courseNameText.Text;

            if (string.Equals(semesterText.Text, "fall", StringComparison.OrdinalIgnoreCase))
            {
                course.Semester = "F";
            }
            else
            {
                course.Semester = "S";
            }


            course.Days = daysText.Text;
            course.StartTime = new TimeSpan(startTimeText.Value.Hour, startTimeText.Value.Minute, 0);
            course.EndTime = new TimeSpan(endTimeText.Value.Hour, endTimeText.Value.Minute, 0);
        }

        private void modifyButton_Click(object sender, EventArgs e)
        {
            if (verifyFields())
            {
                HttpClient client = NetworkClient.getInstance().getHttpClient();
                
                if (modify)
                {
                    parseDataFromFields(ref course);

                    // Make a REST call to modification.
                    string requestURI = BaseConnection.coursesString + "/" + course.ProfessorID + "/";

                    var response = client.PutAsJsonAsync<Course>(requestURI, course).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("The information has been modified.");
                        this.Close();
                        
                    }
                    else
                    {
                        MessageBox.Show("Something went blup in the server... Sorry!");
                    }
                }
                else
                {
                    // Make a REST call to creating the course.
                    course = new Course();
                    parseDataFromFields(ref course);

                    string requestURI = BaseConnection.coursesString + "/" + emailID + "/";

                    var response = client.PostAsJsonAsync<Course>(requestURI, course).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("The course has been created");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Something went blup in the server... Sorry!");
                    }
                }
            }
            
        }

        private bool verifyFields()
        {
            if (string.IsNullOrEmpty(courseNameText.Text) || string.IsNullOrWhiteSpace(courseNameText.Text))
            {
                MessageBox.Show("Not all the fields are right. Please look at the values");
                return false;
            }

            if (string.IsNullOrEmpty(yearText.Text) || string.IsNullOrWhiteSpace(yearText.Text))
            {
                MessageBox.Show("Please check your year value");
                return false;
            }

            if (!string.Equals(semesterText.Text, "fall", StringComparison.OrdinalIgnoreCase) && !string.Equals(semesterText.Text, "spring", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Please check your semester value");
                return false;
            }

            if (startTimeText.Value > endTimeText.Value)
            {
                MessageBox.Show("Start time cannot be greateer than end time.");
                return false;
            }

            if (daysText.Text.Length >7 || daysText.Text.Length < 1)
            {
                MessageBox.Show("Please enter valid days");
                return false;
            }

            return true;
        }
    }
}
