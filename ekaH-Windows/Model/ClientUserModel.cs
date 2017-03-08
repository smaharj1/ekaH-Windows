﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekaH_Windows.Model
{
    public class ClientUserLoginModel
    {
        public Boolean isStudent { get; set; }
        public string userEmail { get; set; }
        public string pswd { get; set; }
    }

    public class ClientUserRegisterModel
    {
        public Boolean isStudent { get; set; }
        public string userEmail { get; set; }
        public string pswd { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string extraInfo { get; set; }
    }

    public class FacultyInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string Education { get; set; }
        public Address Address { get; set; }
        public string University { get; set; }
        public string Concentration { get; set; }
        public string Phone { get; set; }
    }

    public class StudentInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Education { get; set; }
        public Address Address { get; set; }
        public string Concentration { get; set; }
        public string Graduation { get; set; }
        public string Phone { get; set; }
    }

    
}