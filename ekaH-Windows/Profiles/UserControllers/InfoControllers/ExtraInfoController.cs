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
        /// <summary>
        /// It holds the degree obtained.
        /// </summary>
        public string m_degree
        {
            get { return degreeText.Text; }
        }

        /// <summary>
        /// It holds the name of the university.
        /// </summary>
        public string m_university
        {
            get { return universityText.Text; }
        }

        /// <summary>
        /// It holds the concentration of major.
        /// </summary>
        public string m_concentration
        {
            get { return concentrationText.Text; }
        }

        /// <summary>
        /// It holds the extra information of the user.
        /// </summary>
        public string m_extraInfo
        {
            get { return extraInfoText.Text; }
        }

        /// <summary>
        /// This is a constructor that initializes all of the values.
        /// </summary>
        /// <param name="a_degree">It holds the degree.</param>
        /// <param name="a_unv">It holds the university attended.</param>
        /// <param name="a_conc">It holds the concentration.</param>
        /// <param name="a_extra">It holds the extra information.</param>
        public ExtraInfoController(string a_degree, string a_unv, string a_conc, string a_extra)
        {
            InitializeComponent();

            degreeText.Text = a_degree;
            universityText.Text = a_unv;
            concentrationText.Text = a_conc;
            extraInfoText.Text = a_extra;
        }

        /// <summary>
        /// This is a constructor that only satisfied certain parts of the values.
        /// </summary>
        /// <param name="a_degree">It holds the degree info.</param>
        /// <param name="a_conc">It holds the concentration info.</param>
        /// <param name="a_extra">It holds the extra info.</param>
        public ExtraInfoController(string a_degree, string a_conc, string a_extra)
        {
            InitializeComponent();

            degreeText.Text = a_degree;
            concentrationText.Text = a_conc;
            extraInfoText.Text = a_extra;
        }

    }
}
