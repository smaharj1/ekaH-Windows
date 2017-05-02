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
        /// <summary>
        /// It holds the first name.
        /// </summary>
        public string m_firstName {
            get { return firstNameText.Text; }

        }

        /// <summary>
        /// It holds the last name.
        /// </summary>
        public string m_lastName
        {
            get
            {
                return lastNameText.Text;
            }
        }

        /// <summary>
        /// It holds the phone number as string.
        /// </summary>
        public string m_phone
        {
            get { return phoneText.Text; }
        }

        /// <summary>
        /// This is a constructor that initializes the class variables.
        /// </summary>
        /// <param name="a_firstName">It holds the first name.</param>
        /// <param name="a_lastName">It holds the last name.</param>
        /// <param name="a_phone">It holds the phone number.</param>
        public NameInfoController(string a_firstName, string a_lastName, string a_phone)
        {
            InitializeComponent();

            firstNameText.Text = a_firstName;
            lastNameText.Text = a_lastName;
            phoneText.Text = a_phone;
        }
    }
}
