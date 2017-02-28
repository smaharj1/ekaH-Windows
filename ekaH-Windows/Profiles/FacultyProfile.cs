using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ekaH_Windows.Profiles
{
    public partial class FacultyProfile : Form
    {
        private string userEmail;

        public FacultyProfile(string email)
        {
            InitializeComponent();

            userEmail = email;
        }
    }
}
