using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekaH_Windows.Model
{
    public class ClientUserLoginModel
    {
        public sbyte member_type { get; set; }
        public string email { get; set; }
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
        public string StreetAdd1 { get; set; }
        public string StreetAdd2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
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
