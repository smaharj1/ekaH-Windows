using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ekaH_Windows.Model;

namespace ekaH_Windows.Profiles.UserControllers.InfoControllers
{
    public partial class AddressInfoController : MetroFramework.Controls.MetroUserControl
    {
        /// <summary>
        /// It holds the street 1 address.
        /// </summary>
        public string m_street1
        {
            get { return address1Text.Text; }
        }

        /// <summary>
        /// It holds the street 2 address.
        /// </summary>
        public string m_street2
        {
            get { return address2Text.Text; }
        }

        /// <summary>
        /// It holds the city address.
        /// </summary>
        public string m_city
        {
            get { return cityText.Text; }
        }

        /// <summary>
        /// It holds the state address.
        /// </summary>
        public string m_state
        {
            get { return stateText.Text; }
        }

        /// <summary>
        /// It holds the zip of the address.
        /// </summary>
        public string m_zip
        {
            get { return zipCodeText.Text; }
        }

        /// <summary>
        /// This is a constructor that initiates the controller's addresses.
        /// </summary>
        /// <param name="a_street1">It holds the value of street 1.</param>
        /// <param name="a_street2">It holds the value of street 2.</param>
        /// <param name="a_city">It holds the value of city.</param>
        /// <param name="a_state">It holds the name of the state.</param>
        /// <param name="a_zip">It holds the zip code.</param>
        public AddressInfoController(string a_street1, string a_street2, string a_city, string a_state, string a_zip)
        {
            InitializeComponent();

            address1Text.Text = a_street1;
            address2Text.Text = a_street2;
            cityText.Text = a_city;
            stateText.Text = a_state;
            zipCodeText.Text = a_zip;
        }
    }
}
