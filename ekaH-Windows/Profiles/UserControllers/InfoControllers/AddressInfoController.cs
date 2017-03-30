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
        public string Street1
        {
            get
            {
                return address1Text.Text;
            }
            set
            {
                Street1 = value;
            }
        }

        public string Street2
        {
            get
            {
                return address2Text.Text;
            }
            set
            {
                Street2 = value;
            }
        }

        public string City
        {
            get
            {
                return cityText.Text;
            }
            set
            {
                City = value;
            }
        }

        public string State
        {
            get
            {
                return stateText.Text;
            }
            set
            {
                State = value;
            }
        }

        public string Zip
        {
            get
            {
                return zipCodeText.Text;
            }
            set
            {
                Zip = value;
            }
        }

        public AddressInfoController()
        {
            InitializeComponent();
        }

        public AddressInfoController(string street1, string street2, string city, string state, string zip)
        {
            InitializeComponent();

            address1Text.Text = street1;
            address2Text.Text = street2;
            cityText.Text = city;
            stateText.Text = state;
            zipCodeText.Text = zip;
        }
    }
}
