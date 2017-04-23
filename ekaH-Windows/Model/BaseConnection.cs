using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekaH_Windows.Model
{
    class BaseConnection
    {
        public static string URI = "http://localhost:51147/ekah/";

        public static string registerPostString = "auth/register";

        public static string loginPostString = "auth/login";

        public static string facultyString = "faculties";

        public static string coursesString = "courses";

        public static string studentString = "students";

        public static string singularFaculty = "faculty";

        public static string singleString = "single";

        public static string appointments = "appointments";

        public static string schedule = "schedule";
        public static string schedules = "schedules";
        public static string facSchedule = "facultySchedule";
        public static string fullInfo = "appFull";

        public static string app = "app";

        public static string assignments = "assignments";
        public static string submissions = "submissions";
        public static string submitAction = "submit";

        public static string discussion = "discussion";
        public static string threadString = "thread";


    }
}
