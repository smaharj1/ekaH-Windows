using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekaH_Windows.Model
{
    /// <summary>
    /// This class represents the data structure of a typical schedule for classes or appointments.
    /// </summary>
    public class Schedule
    {
        public string ProfessorID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DayInfo[] Days { get; set; }
    }

    /// <summary>
    /// This class represents the full information of an appointment.
    /// </summary>
    public class FullAppointmentInfo
    {
        public FacultyInfo Faculty { get; set; }
        public StudentInfo Student { get; set; }
        public Appointment Appointment { get; set; }
    }

    /// <summary>
    /// This class represents the data structure for single schedule information.
    /// </summary>
    public class SingleSchedule
    {
        public int ScheduleID { get; set; }
        public string ProfessorID { get; set; }
        public DateTime StartDTime { get; set; }
        public DateTime EndDTime { get; set; }
    }

    /// <summary>
    /// This class represents the data structure for appointments.
    /// </summary>
    public class Appointment
    {
        public int Id { get; set; }
        public int ScheduleID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string AttendeeID { get; set; }
        public bool Confirmed { get; set; }
    }

    /// <summary>
    /// This class represents the data structure for time of office hours in a day.
    /// </summary>
    public class DayInfo
    {
        public DayOfWeek Day { get; set; }
        public TimeSpan startTime { get; set; }
        public TimeSpan endTime { get; set; }
    }
}
