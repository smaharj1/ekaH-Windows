using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekaH_Windows.Model
{
    /// <summary>
    /// This class represents the data structure for log in information required from the user.
    /// </summary>
    public class ClientUserLoginModel
    {
        public sbyte Member_type { get; set; }
        public string Email { get; set; }
        public string Pswd { get; set; }
    }

    /// <summary>
    /// This class represents the data structure for sign up information required from the user.
    /// </summary>
    public class ClientUserRegisterModel
    {
        public Boolean IsStudent { get; set; }
        public string UserEmail { get; set; }
        public string Pswd { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ExtraInfo { get; set; }
    }

    /// <summary>
    /// This class represents the general information of the faculty members.
    /// </summary>
    public class FacultyInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string Education { get; set; }
        public string StreetAdd1 { get; set; }
        public string StreetAdd2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string University { get; set; }
        public string Concentration { get; set; }
        public string Phone { get; set; }
    }

    /// <summary>
    /// This class represents the data structure for holding student's personal information.
    /// </summary>
    public class StudentInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Education { get; set; }
        public string StreetAdd1 { get; set; }
        public string StreetAdd2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Concentration { get; set; }
        public string Graduation { get; set; }
        public string Phone { get; set; }
    }

    
}
