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
        public Address inputAddress
        {
            get {
                return new Address(address1Text.Text, address2Text.Text, cityText.Text, stateText.Text, zipCodeText.Text);
            }

            set
            {
                inputAddress = value;
            }
        }

        public AddressInfoController()
        {
            InitializeComponent();
        }

        public AddressInfoController(Address addr)
        {
            InitializeComponent();

            address1Text.Text = addr.StreetAdd1;
            address2Text.Text = addr.StreetAdd2;
            cityText.Text = addr.City;
            stateText.Text = addr.State;
            zipCodeText.Text = addr.Zip;
        }
    }
}
