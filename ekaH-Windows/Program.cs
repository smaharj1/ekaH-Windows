﻿using ekaH_Windows.Profiles;
using ekaH_Windows.Profiles.Forms;
using ekaH_Windows.Profiles.Forms.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ekaH_Windows
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new LogInWindow());
            //Application.Run(StudentProfile.getInstance("smaharj1@ramapo.edu"));

            //Application.Run(FacultyProfile.getInstance("amruth@ramapo.edu"));
            //Application.Run(new CourseModification());
            //Application.Run(new UpdateInfo);
            Application.Run(new CourseAdd());
        }
    }
}
