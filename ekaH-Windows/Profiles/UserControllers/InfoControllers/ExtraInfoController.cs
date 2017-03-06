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
    public partial class ExtraInfoController : MetroFramework.Controls.MetroUserControl
    {
        public string Degree
        {
            get
            {
                return degreeText.Text;
            }

            set
            {
                Degree = value;
            }
        }

        public string University
        {
            get
            {
                return universityText.Text;
            }

            set
            {
                University = value;
            }
        }

        public string Concentration
        {
            get
            {
                return concentrationText.Text;
            }

            set
            {
                Concentration = value;
            }
        }

        public string ExtraInfo
        {
            get
            {
                return extraInfoText.Text;
            }

            set
            {
                ExtraInfo = value;
            }
        }


        public ExtraInfoController()
        {
            InitializeComponent();

        }

        public ExtraInfoController(string degree, string unv, string conc, string extra)
        {
            InitializeComponent();

            degreeText.Text = degree;
            universityText.Text = unv;
            concentrationText.Text = conc;
            extraInfoText.Text = extra;
        }

    }
}
