using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ekaH_Windows.Profiles.UserControllers.InfoControllers
{
    public partial class NameInfoController : MetroFramework.Controls.MetroUserControl
    {
        public string FirstName
        {
            get
            {
                return firstNameText.Text;
            }
        }

        public string LastName
        {
            get
            {
                return lastNameText.Text;
            }
        }

        public string Phone
        {
            get
            {
                return phoneText.Text;
            }
        }


        public NameInfoController()
        {
            InitializeComponent();
        }

        public NameInfoController(string firstName, string lastName, string phone)
        {
            InitializeComponent();

            firstNameText.Text = firstName;
            lastNameText.Text = lastName;
            phoneText.Text = phone;
        }
    }
}
