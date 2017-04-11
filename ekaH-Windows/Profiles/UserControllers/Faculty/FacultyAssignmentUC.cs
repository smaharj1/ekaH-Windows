using System;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ekaH_Windows.Model;
using System.IO;
using System.Net.Http;
using MetroFramework;
using ekaH_Windows.Profiles.Forms;

namespace ekaH_Windows.Profiles.UserControllers.Faculty
{
    public partial class FacultyAssignmentUC : MetroFramework.Controls.MetroUserControl
    {
        private Color BUTTON_PRESSED = ColorTranslator.FromHtml("#E8B71A");
        private Color BUTTON_RELEASED = ColorTranslator.FromHtml("#F7EAC8");

        private List<Assignment> openAssignments;
        private Assignment currentAssgn;
        private Font preferredFont;
        private Color preferredForeColor;

        private Font defaultFont;
        private Color defaultForeColor;

        private bool isNew = false;


        public FacultyAssignmentUC()
        {
            openAssignments = new List<Assignment>();
            InitializeComponent();

            preferredFont = assignmentRTB.Font;
            preferredForeColor = Color.Black;

            defaultFont = assignmentRTB.Font;
            defaultForeColor = Color.Black;
        }

        public void makeNew(Course course, int projectNum)
        {
            isNew = true;
            currentAssgn = new Assignment();
            currentAssgn.courseID = course.CourseID;
            currentAssgn.deadline = DateTime.Today;
            currentAssgn.weight = -1;
            currentAssgn.projectNum = projectNum;
            currentAssgn.projectTitle = "";
            currentAssgn.content = "";

            updateView();

        }

        /// <summary>
        /// Opens the assignment clicked by the professor and gives the details.
        /// </summary>
        /// <param name="assgn"></param>
        public void open(Assignment assgn)
        {
            isNew = false;
            /// Checks if the assignment was previously open to reduce the number of UC objects being formed.
            if (openAssignments.Contains(assgn))
            {
                int index = openAssignments.IndexOf(assgn);
                currentAssgn = openAssignments[index];

            }
            else
            {
                openAssignments.Add(assgn);
                currentAssgn = assgn;
            }

            updateView();
        }

        private void updateView()
        {
            projectName.Text = currentAssgn.projectTitle;
            weightTextBox.Text = currentAssgn.weight.ToString();
            deadlineBox.Value = currentAssgn.deadline;
            assignmentRTB.Clear();

            string decodedString = WebUtility.UrlDecode(currentAssgn.content);
            // For now, just do the content.
            try
            {
                assignmentRTB.Rtf = decodedString;
            }
            catch(Exception)
            {
                assignmentRTB.Text = currentAssgn.content;
            }
        }

        private void editBox_Click(object sender, EventArgs e)
        {
            setFieldsEnabled(true);
        }

        private void setFieldsEnabled(bool given)
        {
            assignmentRTB.Enabled = given;
            saveBox.Visible = given;
            fontBox.Visible = given;
            fontPanel.Visible = given;
            projectName.Enabled = given;
            weightTextBox.Enabled = given;
            deadlineBox.Enabled = given;
        }

        private void saveBox_Click(object sender, EventArgs e)
        {
            setFieldsEnabled(false);

            // Make put call to the database.
            string encodedString = WebUtility.UrlEncode(assignmentRTB.Rtf);

            currentAssgn.content = encodedString;

            DateTime givenDT = deadlineBox.Value;
            TimeSpan midnight = new TimeSpan(23, 59, 59);
            givenDT = givenDT.Date + midnight;

            currentAssgn.deadline = givenDT;
            try
            {
                currentAssgn.weight = int.Parse(weightTextBox.Text);
            }catch(Exception)
            {
                MetroMessageBox.Show(this, "Enter a valid number for weight", "Invalid type!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            currentAssgn.projectTitle = projectName.Text;

            if (isNew)
            {
                postAssignmentToDB(currentAssgn);
            }
            else
            {
                putAssignmentToDB(currentAssgn);
            }
        }

        private void postAssignmentToDB(Assignment assgn)
        {
            HttpClient client = NetworkClient.getInstance().getHttpClient();

            string uri = BaseConnection.assignments + "/" + BaseConnection.coursesString;

            try
            {
                var response = client.PostAsJsonAsync(uri, assgn).Result;

                if (response.IsSuccessStatusCode)
                {
                    MetroMessageBox.Show(this, "Done!", "Change successful!",
                        MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    MetroMessageBox.Show(this, "The assignment was not found. I know its weird",
                        "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                Worker.printServerError(this);
            }
        }

        private void putAssignmentToDB(Assignment assgn)
        {
            HttpClient client = NetworkClient.getInstance().getHttpClient();

            string uri = BaseConnection.assignments + "/" + BaseConnection.coursesString + "/" + assgn.id;

            try
            {
                var response = client.PutAsJsonAsync(uri, assgn).Result;

                if (response.IsSuccessStatusCode)
                {
                    MetroMessageBox.Show(this, "Done!", "Change successful!", 
                        MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    MetroMessageBox.Show(this, "The assignment was not found. I know its weird",
                        "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    throw new Exception();
                }
            }
            catch(Exception)
            {
                Worker.printServerError(this);
            }
        }


        /// <summary>
        /// Shows the dialog to change the font.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Show the dialog.
            DialogResult result = fontDialog1.ShowDialog();
            // See if OK was pressed.
            if (result == DialogResult.OK)
            {
                // Set the font
                setFont(fontDialog1.Font, preferredForeColor);
            }
        }

        private void fixFontUI(Font font, Color fore)
        {
            boldButton.BackColor = font.Bold ? BUTTON_PRESSED : BUTTON_RELEASED;
            italicButton.BackColor = font.Italic ? BUTTON_PRESSED : BUTTON_RELEASED;
            underlineButton.BackColor = font.Underline ? BUTTON_PRESSED : BUTTON_RELEASED;
            colorButton.BackColor = fore;
        }

        private void setFont(Font font, Color fore)
        {
            preferredFont = fontDialog1.Font;
            assignmentRTB.SelectionFont = preferredFont;

            preferredForeColor = fore;
            assignmentRTB.SelectionColor = fore;

            fixFontUI(preferredFont, preferredForeColor);
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog1.ShowDialog();

            // See if OK was pressed.
            if (result == DialogResult.OK)
            {
                setFont(preferredFont, colorDialog1.Color);
            }
        }

        
    }
}
