using System;
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
}
