using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekaH_Windows.Model
{
    /// <summary>
    /// This class holds the data structure for details about a course.
    /// </summary>
    public class Course
    {
        /// <summary>
        /// It holds the total number of columns that is being displayed in UI for courses.
        /// </summary>
        private const int COLUMNS = 6;
        
        public string CourseID { get; set; }
        public int Year { get; set; }
        public string Semester { get; set; }
        public string ProfessorID { get; set; }
        public string Days { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; }
        public virtual FacultyInfo Professor_info { get; set; }

        /// <summary>
        /// This function converts the current course object's information into a string array for the display.
        /// It only keeps certain information such as year, semester, days, course name, start time and end time.
        /// </summary>
        /// <returns>Returns the string array of the course object.</returns>
        public string[] ConvertToArray()
        {
            // Puts the necessary values into the string array.
            string[] tableReadable = new string[COLUMNS];
            tableReadable[0] = CourseName;
            tableReadable[1] = Year.ToString();
            tableReadable[2] = Semester == "F" ? "Fall" : "Spring";
            tableReadable[3] = Days;

            // Puts the string representation of start and end dates.
            DateTime tempDate = DateTime.Today + StartTime;
            string start = tempDate.ToString("hh:mm tt");
            tempDate = DateTime.Today + EndTime;
            string end = tempDate.ToString("hh:mm tt");

            tableReadable[4] = start;
            tableReadable[5] = end;

            return tableReadable;
        }

    }
}
