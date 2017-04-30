using ekaH_Windows.Model;
using ekaH_Windows.Profiles.UserControllers.InfoControllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;

namespace ekaH_Windows.Profiles.Forms
{
    public partial class UpdateInfo : MetroFramework.Forms.MetroForm
    {
        private bool isStudent;
        private Object userInfo;

        private int readableIndex;

        // Name and address controllers are going to be same for students and faculty
        private NameInfoController nameController;
        private AddressInfoController addressController;
        private ExtraInfoController extraInfoController;

        //public static UpdateInfo Info;

        private UpdateInfo()
        {
            InitializeComponent();
        }

        public UpdateInfo(Object info, bool isStd)
        {
            isStudent = isStd;
            userInfo = info;
            
            InitializeComponent();

            initiateControllers();
            startInfoControl();
            submitButton.Visible = false;

        }


      

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
                    addressController = new AddressInfoController(faculty.StreetAdd1, faculty.StreetAdd2, faculty.City, faculty.State, faculty.Zip);
                    addressController.Dock = DockStyle.Fill;

                    updateInfoPanel.Controls.Add(addressController);
                }

                if (extraInfoController == null)
                {
                    extraInfoController = new ExtraInfoController(faculty.Education, faculty.University, faculty.Concentration, faculty.Department);
                    extraInfoController.Dock = DockStyle.Fill;

                    updateInfoPanel.Controls.Add(extraInfoController);
                }
            }
            else
            {
                // Do the same thing for Student. Only difference is that the object we have would be studentinfo
                StudentInfo student = (StudentInfo)userInfo;

                if (nameController == null)
                {
                    nameController = new NameInfoController(student.FirstName, student.LastName, student.Phone);
                    nameController.Dock = DockStyle.Fill;

                    updateInfoPanel.Controls.Add(nameController);
                }

                if (addressController == null)
                {
                    addressController = new AddressInfoController(student.StreetAdd1, student.StreetAdd2, student.City, student.State, student.Zip);
                    addressController.Dock = DockStyle.Fill;

                    updateInfoPanel.Controls.Add(addressController);
                }

                if (extraInfoController == null)
                {
                    extraInfoController = new ExtraInfoController(student.Education, student.Concentration, student.Graduation);
                    extraInfoController.Dock = DockStyle.Fill;

                    updateInfoPanel.Controls.Add(extraInfoController);
                }
            }
        }

        private void startInfoControl()
        {
            submitButton.Visible = false;
            infoLabel.Text = "Tell us a little bit about yourself";
            if (nameController == null || addressController == null || extraInfoController == null)
            {
                initiateControllers();
            }

            nameController.BringToFront();
            readableIndex = 1;

            previousIcon.Visible = false;
            trackBar.Value = readableIndex * 33;
        }

        private void startAddressControl()
        {
            // Disable the view for submit button
            submitButton.Visible = false;

            infoLabel.Text = "So, where do you live?";
            if (nameController == null || addressController == null || extraInfoController == null)
            {
                initiateControllers();
            }

            addressController.BringToFront();

            readableIndex = 2;

            //previousIcon.Visible = false;
            trackBar.Value = readableIndex * 33;
        }

        private void startFinalControl()
        {
            // Enable submit button
            submitButton.Visible = true;

            infoLabel.Text = "Tell us more about your background";
            if (nameController == null || addressController == null || extraInfoController == null)
            {
                initiateControllers();
            }

            extraInfoController.BringToFront();

            readableIndex = 3;

            //previousIcon.Visible = false;
            trackBar.Value = 100;
        }

        private void nextIcon_Click(object sender, EventArgs e)
        {
            if (readableIndex == 1)
            {
                startAddressControl();
            }
            else if (readableIndex == 2)
            {
                // Start the third index for more information here.
                startFinalControl();
                nextIcon.Visible = false;
            }

            previousIcon.Visible = true;
        }

        private void previousIcon_Click(object sender, EventArgs e)
        {
            if(readableIndex == 2)
            {
                startInfoControl();
            }
            else if (readableIndex == 3)
            {
                startAddressControl();
            }

            nextIcon.Visible = true;
        }

        // Makes a PUT REST call here for updating the information provided.
        private void submitButton_Click(object sender, EventArgs e)
        {
            if (!isStudent)
            {
                FacultyInfo putFaculty = (FacultyInfo)userInfo;
                putFaculty.FirstName = nameController.FirstName;
                putFaculty.LastName = nameController.LastName;
                putFaculty.Phone = nameController.Phone;
                putFaculty.StreetAdd1 = addressController.Street1;
                putFaculty.StreetAdd2 = addressController.Street2;
                putFaculty.City = addressController.City;
                putFaculty.State = addressController.State;
                putFaculty.Zip = addressController.Zip;

                putFaculty.Education = extraInfoController.Degree;
                putFaculty.University = extraInfoController.University;
                putFaculty.Concentration = extraInfoController.Concentration;
                putFaculty.Department = extraInfoController.ExtraInfo;

                HttpClient client = NetworkClient.getInstance().getHttpClient();

                string requestURI = BaseConnection.g_facultyString + "/" + putFaculty.Email + "/";

                var response = client.PutAsJsonAsync<FacultyInfo>(requestURI, putFaculty).Result;

                if (response.IsSuccessStatusCode)
                {
                    MetroMessageBox.Show(this, "Amazing! The changes are saved!", "Saved!", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    this.Dispose();
                }
                else
                {
                    MetroMessageBox.Show(this, "Hay wire in the server! Please try again after some time!", "Server Error!", MessageBoxButtons.OK, MessageBoxIcon.Question);

                }
            }
            else
            {
                StudentInfo putStudent = (StudentInfo)userInfo;
                putStudent.FirstName = nameController.FirstName;
                putStudent.LastName = nameController.LastName;
                putStudent.Phone = nameController.Phone;
                putStudent.StreetAdd1 = addressController.Street1;
                putStudent.StreetAdd2 = addressController.Street2;
                putStudent.City = addressController.City;
                putStudent.State = addressController.State;
                putStudent.Zip = addressController.Zip;
                putStudent.Education = extraInfoController.Degree;
                putStudent.Concentration = extraInfoController.Concentration;
                putStudent.Graduation= extraInfoController.ExtraInfo;

                HttpClient client = NetworkClient.getInstance().getHttpClient();

                string requestURI = BaseConnection.g_studentString + "/" + putStudent.Email + "/";

                var response = client.PutAsJsonAsync<StudentInfo>(requestURI, putStudent).Result;

                if (response.IsSuccessStatusCode)
                {
                    MetroMessageBox.Show(this, "Amazing! The changes are saved!", "Saved!",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    this.Dispose();
                }
                else
                {
                    MetroMessageBox.Show(this, "Hay wire in the server! Please try again after some time!", "Server Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }
    }
}
