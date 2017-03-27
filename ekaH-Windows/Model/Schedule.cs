using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekaH_Windows.Model
{
    public class Schedule
    {
        public string ProfessorID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DayInfo[] Days { get; set; }
    }

    public class FullAppointmentInfo
    {
        public FacultyInfo Faculty { get; set; }
        public StudentInfo Student { get; set; }
        public Appointment Appointment { get; set; }
    }

    public class SingleSchedule
    {
        public int ScheduleID { get; set; }
        public string ProfessorID { get; set; }
        public DateTime StartDTime { get; set; }
        public DateTime EndDTime { get; set; }
    }

    public class Appointment
    {
        public int AppointmentID { get; set; }
        public int ScheduleID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string AttendeeID { get; set; }
        public bool Confirmed { get; set; }
    }

    public class DayInfo
    {
        public DayOfWeek Day { get; set; }
        public TimeSpan startTime { get; set; }
        public TimeSpan endTime { get; set; }

    }
}
