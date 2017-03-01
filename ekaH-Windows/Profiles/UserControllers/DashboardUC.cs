using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ekaH_Windows.Profiles.UserControllers
{
    public partial class DashboardUC : MetroFramework.Controls.MetroUserControl
    {
        public DashboardUC()
        {
            InitializeComponent();

            fillWelcome();
        }

        private void fillWelcome()
        {
            welcomeLabel.Text = "Your immediate options made easy! Please choose from the menu and go right into it.";
            
        }
    }
}
