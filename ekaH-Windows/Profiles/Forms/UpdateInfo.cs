using ekaH_Windows.Model;
using ekaH_Windows.Profiles.UserControllers.InfoControllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ekaH_Windows.Profiles.Forms
{
    public partial class UpdateInfo : MetroFramework.Forms.MetroForm
    {
        private bool isStudent;
        private Object userInfo;

        // Name and address controllers are going to be same for students and faculty
        private NameInfoController nameController;
        private AddressInfoController addressController;

        public UpdateInfo()
        {
            InitializeComponent();
        }

        public UpdateInfo(FacultyInfo info)
        {
            isStudent = false;
            userInfo = info;
            
            InitializeComponent();

            initiateControllers();
            startInfoControl();
        }

        /* This is for the student
        public UpdateInfo(StudentInfo info)
        {

        }
        */

        private void initiateControllers()
        {
            if (!isStudent)
            {
                FacultyInfo faculty = (FacultyInfo) userInfo;

                if (nameController == null)
                {
                    nameController = new NameInfoController(faculty.FirstName, faculty.LastName, faculty.Phone);
                    nameController.Dock = DockStyle.Fill;

                    updateInfoPanel.Controls.Add(nameController);
                }

                if (addressController == null)
                {
                    addressController = new AddressInfoController(faculty.Address);
                    addressController.Dock = DockStyle.Fill;

                    updateInfoPanel.Controls.Add(addressController);
                }
            }
            else
            {
                // Do the same thing for Student. Only difference is that the object we have would be studentinfo
            }
        }

        private void startInfoControl()
        {
            if (nameController == null || addressController == null)
            {
                initiateControllers();
            }

            nameController.BringToFront();
        }
    }
}
