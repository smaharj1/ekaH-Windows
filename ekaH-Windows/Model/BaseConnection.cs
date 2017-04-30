using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekaH_Windows.Model
{
    /// <summary>
    /// This class holds the static URI strings for making connection with the server.
    /// </summary>
    class BaseConnection
    {
        // It holds the main URI of the server to connect to.
        public static string g_URI = "http://localhost:51147/ekah/";

        // It holds the value to register a user.
        public static string g_registerPostString = "auth/register";

        // It holds the value to log in the user.
        public static string g_loginPostString = "auth/login";

        // It represents the faculties string.
        public static string g_facultyString = "faculties";

        // It represents the courses string for the URI.
        public static string g_coursesString = "courses";

        // It represents the students string for the URI.
        public static string g_studentString = "students";

        // It represents the faculty string for the URI.
        public static string g_singularFaculty = "faculty";

        // It represents the single string for the URI.
        public static string g_singleString = "single";

        // It represents the appointments string for the URI.
        public static string g_appointments = "appointments";

        // It represents the single schedule string for the URI.
        public static string g_schedule = "schedule";

        // It represents the schedules for the URI.
        public static string g_schedules = "schedules";

        // It represents the faculty schedule for the URI.
        public static string g_facSchedule = "facultySchedule";

        // It represents the full info of the application for the URI.
        public static string g_fullInfo = "appFull";

        // It represents the app string for the URI.
        public static string g_app = "app";

        // It represents assignments string for the URI.
        public static string g_assignments = "assignments";

        // It represents submissions string for the URI.
        public static string g_submissions = "submissions";

        // It represents the submitting action for the URI.
        public static string g_submitAction = "submit";

        // It represents the duscussion forum action for the URI.
        public static string g_discussion = "discussion";

        // It represents the thread action for the URI.
        public static string g_threadString = "thread";
    }
}
