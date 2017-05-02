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
    /// <summary>
    /// This class helps the user to update their profile.
    /// </summary>
    public partial class UpdateInfo : MetroFramework.Forms.MetroForm
    {
        /// <summary>
        /// It holds if the student is logged in or professor.
        /// </summary>
        private bool m_isStudent;

        /// <summary>
        /// It holds the user's info object.
        /// </summary>
        private Object m_userInfo;

        /// <summary>
        /// It holds the readable index.
        /// </summary>
        private int readableIndex;

        /// <summary>
        /// It holds the name controller.
        /// </summary>
        private NameInfoController nameController;

        /// <summary>
        /// It holds the address controller.
        /// </summary>
        private AddressInfoController addressController;

        /// <summary>
        /// It holds the extra information controller.
        /// </summary>
        private ExtraInfoController extraInfoController;
               
        /// <summary>
        /// This is a constructor that sets the student property and the information object.
        /// </summary>
        /// <param name="m_info"></param>
        /// <param name="m_isStd"></param>
        public UpdateInfo(Object m_info, bool m_isStd)
        {
            m_isStudent = m_isStd;
            m_userInfo = m_info;
            
            InitializeComponent();

            InitiateControllers();
            StartInfoControl();
            submitButton.Visible = false;
        }

        /// <summary>
        /// This function starts all the controller where the information are modified.
        /// </summary>
        private void InitiateControllers()
        {
            /// Handles the student and faculty differently since the information needed are different.
            if (!m_isStudent)
            {
                /// Starts the desired controllers and adds it to the panel.
                FacultyInfo faculty = (FacultyInfo) m_userInfo;

                if (nameController == null)
                {
                    nameController = new NameInfoController(faculty.FirstName, faculty.LastName, faculty.Phone);
                    nameController.Dock = DockStyle.Fill;

                    updateInfoPanel.Controls.Add(nameController);
                }
                /// Starts the desired controllers and adds it to the panel.
                if (addressController == null)
                {
                    addressController = new AddressInfoController(faculty.StreetAdd1, faculty.StreetAdd2, faculty.City, faculty.State, faculty.Zip);
                    addressController.Dock = DockStyle.Fill;

                    updateInfoPanel.Controls.Add(addressController);
                }

                /// Starts the desired controllers and adds it to the panel.
                if (extraInfoController == null)
                {
                    extraInfoController = new ExtraInfoController(faculty.Education, faculty.University, faculty.Concentration, faculty.Department);
                    extraInfoController.Dock = DockStyle.Fill;

                    updateInfoPanel.Controls.Add(extraInfoController);
                }
            }
            else
            {
                StudentInfo student = (StudentInfo)m_userInfo;

                /// Starts the desired controllers and adds it to the panel.
                if (nameController == null)
                {
                    nameController = new NameInfoController(student.FirstName, student.LastName, student.Phone);
                    nameController.Dock = DockStyle.Fill;

                    updateInfoPanel.Controls.Add(nameController);
                }

                /// Starts the desired controllers and adds it to the panel.
                if (addressController == null)
                {
                    addressController = new AddressInfoController(student.StreetAdd1, student.StreetAdd2, student.City, student.State, student.Zip);
                    addressController.Dock = DockStyle.Fill;

                    updateInfoPanel.Controls.Add(addressController);
                }

                /// Starts the desired controllers and adds it to the panel.
                if (extraInfoController == null)
                {
                    extraInfoController = new ExtraInfoController(student.Education, student.Concentration, student.Graduation);
                    extraInfoController.Dock = DockStyle.Fill;

                    updateInfoPanel.Controls.Add(extraInfoController);
                }
            }
        }

        /// <summary>
        /// This function starts the info controller.
        /// </summary>
        private void StartInfoControl()
        {
            /// Sets up the UI for getting the information from the user.
            submitButton.Visible = false;
            infoLabel.Text = "Tell us a little bit about yourself";
            if (nameController == null || addressController == null || extraInfoController == null)
            {
                InitiateControllers();
            }

            nameController.BringToFront();
            readableIndex = 1;

            previousIcon.Visible = false;
            trackBar.Value = readableIndex * 33;
        }

        /// <summary>
        /// This class starts the address controller.
        /// </summary>
        private void StartAddressControl()
        {
            // Disable the view for submit button.
            submitButton.Visible = false;

            infoLabel.Text = "So, where do you live?";
            if (nameController == null || addressController == null || extraInfoController == null)
            {
                InitiateControllers();
            }

            /// Brings the controlle to the front.
            addressController.BringToFront();

            readableIndex = 2;

            trackBar.Value = readableIndex * 33;
        }

        /// <summary>
        /// This function starts the final controller that takes in the extra information from the user.
        /// </summary>
        private void StartFinalControl()
        {
            // Enable submit button
            submitButton.Visible = true;

            infoLabel.Text = "Tell us more about your background";
            if (nameController == null || addressController == null || extraInfoController == null)
            {
                InitiateControllers();
            }

            extraInfoController.BringToFront();

            readableIndex = 3;

            //previousIcon.Visible = false;
            trackBar.Value = 100;
        }

        /// <summary>
        /// This function takes the user to next page to gather more information.
        /// </summary>
        /// <param name="a_sender">It holds the sender.</param>
        /// <param name="a_event">It holds the event arguments.</param>
        private void NextIcon_Click(object a_sender, EventArgs a_event)
        {
            if (readableIndex == 1)
            {
                StartAddressControl();
            }
            else if (readableIndex == 2)
            {
                /// Start the third index for more information here.
                StartFinalControl();
                nextIcon.Visible = false;
            }

            previousIcon.Visible = true;
        }

        /// <summary>
        /// This function goes to the previous page when previous button is clicked.
        /// </summary>
        /// <param name="a_sender">It holds the sender.</param>
        /// <param name="a_event">It holds the event arguments.</param>
        private void PreviousIcon_Click(object a_sender, EventArgs a_event)
        {
            /// Tracks the current index and reduces as necessary to desired page.
            if(readableIndex == 2)
            {
                StartInfoControl();
            }
            else if (readableIndex == 3)
            {
                StartAddressControl();
            }

            nextIcon.Visible = true;
        }

        /// <summary>
        /// Makes a PUT REST call here for updating the information provided.
        /// </summary>
        /// <param name="a_sender">It holds the sender.</param>
        /// <param name="a_event">It holds the event arguments</param>
        private void submitButton_Click(object a_sender, EventArgs a_event)
        {
            /// Parses the information provided by the user to desired fields in FacultyInfo or StudentInfo object.
            /// Then, it sends it to the server to store the modification.
            if (!m_isStudent)
            {
                /// Put the info into the object.
                FacultyInfo putFaculty = (FacultyInfo)m_userInfo;
                putFaculty.FirstName = nameController.m_firstName;
                putFaculty.LastName = nameController.m_lastName;
                putFaculty.Phone = nameController.m_phone;
                putFaculty.StreetAdd1 = addressController.m_street1;
                putFaculty.StreetAdd2 = addressController.m_street2;
                putFaculty.City = addressController.m_city;
                putFaculty.State = addressController.m_state;
                putFaculty.Zip = addressController.m_zip;

                putFaculty.Education = extraInfoController.m_degree;
                putFaculty.University = extraInfoController.m_university;
                putFaculty.Concentration = extraInfoController.m_concentration;
                putFaculty.Department = extraInfoController.m_extraInfo;

                HttpClient client = NetworkClient.getInstance().getHttpClient();

                string requestURI = BaseConnection.g_facultyString + "/" + putFaculty.Email + "/";

                /// Sends the request to the server to save the changes.
                var response = client.PutAsJsonAsync<FacultyInfo>(requestURI, putFaculty).Result;

                if (response.IsSuccessStatusCode)
                {
                    MetroMessageBox.Show(this, "Amazing! The changes are saved!", "Saved!", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    this.Dispose();
                }
                else
                {
                    Worker.printServerError(this);
                }
            }
            else
            {
                /// Puts the info from input fields into StudentInfo object.
                StudentInfo putStudent = (StudentInfo)m_userInfo;
                putStudent.FirstName = nameController.m_firstName;
                putStudent.LastName = nameController.m_lastName;
                putStudent.Phone = nameController.m_phone;
                putStudent.StreetAdd1 = addressController.m_street1;
                putStudent.StreetAdd2 = addressController.m_street2;
                putStudent.City = addressController.m_city;
                putStudent.State = addressController.m_state;
                putStudent.Zip = addressController.m_zip;
                putStudent.Education = extraInfoController.m_degree;
                putStudent.Concentration = extraInfoController.m_concentration;
                putStudent.Graduation= extraInfoController.m_extraInfo;

                HttpClient client = NetworkClient.getInstance().getHttpClient();

                string requestURI = BaseConnection.g_studentString + "/" + putStudent.Email + "/";

                /// Sends the update to the server.
                var response = client.PutAsJsonAsync<StudentInfo>(requestURI, putStudent).Result;

                if (response.IsSuccessStatusCode)
                {
                    MetroMessageBox.Show(this, "Amazing! The changes are saved!", "Saved!",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    this.Dispose();
                }
                else
                {
                    Worker.printServerError(this);
                }
            }
        }
    }
}
