using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekaH_Windows.Model
{
    public class Course
    {
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

        public virtual ICollection<Assignment> assignments { get; set; }
        public virtual FacultyInfo professor_info { get; set; }

        public string[] convertToArray()
        {
            string[] tableReadable = new string[COLUMNS];
            tableReadable[0] = CourseName;
            tableReadable[1] = Year.ToString();
            tableReadable[2] = Semester == "F" ? "Fall" : "Spring";
            tableReadable[3] = Days;

            string start = "";
            if (StartTime.Hours > 12)
            {
                start += (StartTime.Hours - 12) + ":"+ StartTime.Minutes+" PM ";
            }
            else
            {
                start += StartTime.Hours + ":" + StartTime.Minutes + " AM";
            }

            string end = "";
            if (EndTime.Hours > 12)
            {
                end += (EndTime.Hours - 12) + ":" + EndTime.Minutes + " PM ";
            }
            else
            {
                end += EndTime.Hours + ":" + EndTime.Minutes + " AM";
            }

            tableReadable[4] = start;
            tableReadable[5] = end;

            return tableReadable;
        }

    }
}
