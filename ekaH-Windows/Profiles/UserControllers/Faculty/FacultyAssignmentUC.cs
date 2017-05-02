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
    /// <summary>
    /// This class handles the assignment giving features by the professor which includes 
    /// editing the document and viewing the files.
    /// </summary>
    public partial class FacultyAssignmentUC : MetroFramework.Controls.MetroUserControl
    {
        /// <summary>
        /// It holds the color value when the button is pressed.
        /// </summary>
        private Color m_buttonPressed = ColorTranslator.FromHtml("#E8B71A");

        /// <summary>
        /// It holds the color value when the button is released.
        /// </summary>
        private Color m_buttonReleased = ColorTranslator.FromHtml("#F7EAC8");

        /// <summary>
        /// It holds all the loaded assignments. It is stored so that the app does not
        /// have to call the server multiple times.
        /// </summary>
        private List<Assignment> m_openAssignments;

        /// <summary>
        /// It holds the currently open assignment.
        /// </summary>
        private Assignment m_currentAssgn;

        /// <summary>
        /// It holds the email of the user.
        /// </summary>
        private string m_email;

        /// <summary>
        /// It holds the preferred font that the user selects.
        /// </summary>
        private Font m_preferredFont;

        /// <summary>
        /// It holds the preferred fore color of the text.
        /// </summary>
        private Color m_preferredForeColor;

        /// <summary>
        /// It holds the default font.
        /// </summary>
        private Font m_defaultFont;

        /// <summary>
        /// It holds the default fore color.
        /// </summary>
        private Color m_defaultForeColor;

        /// <summary>
        /// It indicates if the assignment is new or already existent.
        /// </summary>
        private bool m_isNew = false;

        /// <summary>
        /// It is a constructor which initializes the user's email.
        /// </summary>
        /// <param name="a_em">It holds the email of the professor.</param>
        public FacultyAssignmentUC(string a_em)
        {
            /// Sets the email and initializes all the class variables.
            m_email = a_em;
            m_openAssignments = new List<Assignment>();
            InitializeComponent();

            m_preferredFont = assignmentRTB.Font;
            m_preferredForeColor = Color.Black;

            m_defaultFont = assignmentRTB.Font;
            m_defaultForeColor = Color.Black;
        }

        /// <summary>
        /// This function handles the UI values of various text boxes while making
        /// a new assignment.
        /// </summary>
        /// <param name="a_course">It holds which course the assignment is for.</param>
        /// <param name="a_projectNum">It holds the project's number.</param>
        public void MakeNew(Course a_course, int a_projectNum)
        {
            m_isNew = true;

            /// Makes a new assignment and sets the values according to the parameter.
            m_currentAssgn = new Assignment();
            m_currentAssgn.courseID = a_course.CourseID;
            m_currentAssgn.deadline = DateTime.Today;
            m_currentAssgn.weight = -1;
            m_currentAssgn.projectNum = a_projectNum;
            m_currentAssgn.projectTitle = "";
            m_currentAssgn.content = "";

            /// Updates the view.
            UpdateAssgnView();
        }

        /// <summary>
        /// This funciton opens the assignment clicked by the professor and gives the details.
        /// </summary>
        /// <param name="a_assgn">It holds the assignment that needs to be opened and displayed.</param>
        public void Open(Assignment a_assgn)
        {
            m_isNew = false;

            /// Checks if the assignment was previously open to reduce the number of UC objects being formed.
            if (m_openAssignments.Contains(a_assgn))
            {
                int index = m_openAssignments.IndexOf(a_assgn);
                m_currentAssgn = m_openAssignments[index];

            }
            else
            {
                m_openAssignments.Add(a_assgn);
                m_currentAssgn = a_assgn;
            }

            /// Displays the context menu for grading or opening the submitted solution for the 
            /// project posted.
            ContextMenu cMenu = new ContextMenu();
            cMenu.MenuItems.Add("Open", OpenSubmission_onClick);
            cMenu.MenuItems.Add("Grade Submission");

            submissionsListView.ContextMenu = cMenu;

            UpdateAssgnView();
            UpdateSubmissions();

            SetFieldsEnabled(false);
        }

        /// <summary>
        /// This function is triggered when open submission is clicked in the context
        /// menu.
        /// </summary>
        /// <param name="a_sender">It holds the sender.</param>
        /// <param name="a_event">It holds the event.</param>
        private void OpenSubmission_onClick(object a_sender, EventArgs a_event)
        {
            /// Grabs the item selected and opens a dialog to save the file locally.
            ListViewItem item = submissionsListView.SelectedItems[0];

            Submission selected = (Submission)item.Tag;
            
            string[] split = selected.submissionFileName.Split('.');
            openFile.Filter = "Given format |*." + split[1];
            openFile.Title = split[0];
            
            DialogResult result = openFile.ShowDialog();

            /// Writes the file locally if the user hits ok.
            if (result == DialogResult.OK)
            {
                string filepath = openFile.FileName;
                File.WriteAllBytes(filepath, selected.submissionContent);
            }
        }

        /// <summary>
        /// This function updates the UI for all the submissions done.
        /// </summary>
        private void UpdateSubmissions()
        {
            submissionsListView.Items.Clear();

            /// Gets all the submissions for the mentioned assignment
            List<Submission> allSubs = GetSubmissions();

            if (allSubs != null)
            {
                foreach (Submission sub in allSubs)
                {
                    /// Adds the new submission by making it a list view item.
                    ListViewItem item = new ListViewItem(sub.student_info.FirstName + " " + sub.student_info.LastName);
                    item.SubItems.Add(sub.submissionFileName);
                    item.SubItems.Add(sub.grade == -1 ? "Not graded" : sub.grade+"");
                    item.SubItems.Add(sub.submissionDateTime.ToString());

                    item.Tag = sub;

                    submissionsListView.Items.Add(item);
                }
            }
        }

        /// <summary>
        /// This function gets all the submissions for the given project.
        /// </summary>
        /// <returns>Returns the list of all the submissions made for the project.</returns>
        private List<Submission> GetSubmissions()
        {
            HttpClient client = NetworkClient.getInstance().getHttpClient();

            string uri = BaseConnection.g_submissions + "/" + BaseConnection.g_assignments + "/" + m_currentAssgn.id;

            try
            {
                /// Gets the submissions from the server.
                var response = client.GetAsync(uri).Result;

                if (response.IsSuccessStatusCode)
                {
                    List<Submission> subs = response.Content.ReadAsAsync<List<Submission>>().Result;
                    return subs;
                }

            }
            catch(Exception)
            {
                Worker.printServerError(this);
            }

            return null;
        }

        /// <summary>
        /// This function updates the assignment's view. It views the assignment with the format
        /// that was provided by the professor. 
        /// </summary>
        private void UpdateAssgnView()
        {
            projectName.Text = m_currentAssgn.projectTitle;
            weightTextBox.Text = m_currentAssgn.weight.ToString();
            deadlineBox.Value = m_currentAssgn.deadline;
            assignmentRTB.Clear();

            string decodedString = WebUtility.UrlDecode(m_currentAssgn.content);

            /// Prints out the content by first decoding the rich text format.
            try
            {
                assignmentRTB.Rtf = decodedString;
            }
            catch(Exception)
            {
                assignmentRTB.Text = m_currentAssgn.content;
            }
        }

        /// <summary>
        /// This function enables the text box fields for edit when the button is pressed.
        /// </summary>
        /// <param name="a_sender">It holds the sender.</param>
        /// <param name="a_event">It holds the event.</param>
        private void EditBox_Click(object a_sender, EventArgs a_event)
        {
            SetFieldsEnabled(true);
        }

        /// <summary>
        /// This function enables all the required fields for editing purposes.
        /// </summary>
        /// <param name="a_given">It is the given boolean for setting the visibilities 
        /// and enabilities.</param>
        private void SetFieldsEnabled(bool a_given)
        {
            assignmentRTB.Enabled = a_given;
            saveBox.Visible = a_given;
            fontBox.Visible = a_given;
            fontPanel.Visible = a_given;
            projectName.Enabled = a_given;
            weightTextBox.Enabled = a_given;
            deadlineBox.Enabled = a_given;
            cancelBox.Visible = a_given;
        }

        /// <summary>
        /// This function saves the edits/creations while writing the assignment. It
        /// then sends the edit to the server.
        /// </summary>
        /// <param name="a_sender">It holds the sender.</param>
        /// <param name="a_event">It holds the event.</param>
        private void SaveBox_Click(object a_sender, EventArgs a_event)
        {
            SetFieldsEnabled(false);

            /// Make put call to the database.
            string encodedString = WebUtility.UrlEncode(assignmentRTB.Rtf);

            m_currentAssgn.content = encodedString;

            /// Assigns and validates all the values entered by the professor in the text
            /// fields.
            DateTime givenDT = deadlineBox.Value;
            TimeSpan midnight = new TimeSpan(23, 59, 59);
            givenDT = givenDT.Date + midnight;

            m_currentAssgn.deadline = givenDT;
            try
            {
                m_currentAssgn.weight = int.Parse(weightTextBox.Text);
            }catch(Exception)
            {
                MetroMessageBox.Show(this, "Enter a valid number for weight", "Invalid type!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            m_currentAssgn.projectTitle = projectName.Text;

            /// Makes a PUT or POST calls to the server according to the requested data.
            if (m_isNew)
            {
                PostAssignmentToDB(m_currentAssgn);
            }
            else
            {
                PutAssignmentToDB(m_currentAssgn);
            }
        }

        /// <summary>
        /// This function posts the newly filled values for the assignment.
        /// </summary>
        /// <param name="a_assgn">It holds the assignment that needs to be posted.</param>
        private void PostAssignmentToDB(Assignment a_assgn)
        {
            HttpClient client = NetworkClient.getInstance().getHttpClient();

            string uri = BaseConnection.g_assignments + "/" + BaseConnection.g_coursesString;

            try
            {
                /// Posts the request to the server.
                var response = client.PostAsJsonAsync(uri, a_assgn).Result;

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

        /// <summary>
        /// This function puts the edit to the assignment to the server.
        /// </summary>
        /// <param name="a_assgn">It holds the assignment to be put.</param>
        private void PutAssignmentToDB(Assignment a_assgn)
        {
            HttpClient client = NetworkClient.getInstance().getHttpClient();

            string uri = BaseConnection.g_assignments + "/" + BaseConnection.g_coursesString + "/" + a_assgn.id;

            try
            {
                /// Makes a PUT request to the server.
                var response = client.PutAsJsonAsync(uri, a_assgn).Result;

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
        /// This function shows the dialog to change the font.
        /// </summary>
        /// <param name="a_sender">It holds the sender.</param>
        /// <param name="a_event">It holds the event.</param>
        private void PictureBox1_Click(object a_sender, EventArgs a_event)
        {
            /// Shows the dialog.
            DialogResult result = fontDialog1.ShowDialog();

            /// Sees if OK was pressed.
            if (result == DialogResult.OK)
            {
                /// Sets the font
                SetFont(fontDialog1.Font, m_preferredForeColor);
            }
        }

        /// <summary>
        /// This function fixes the font according to the choices provided by the user.
        /// </summary>
        /// <param name="a_font">It holds the font value.</param>
        /// <param name="a_fore">It holds the fore color value.</param>
        private void FixFontUI(Font a_font, Color a_fore)
        {
            /// Sets the forecolor and font properties for the given text.
            boldButton.BackColor = a_font.Bold ? m_buttonPressed : m_buttonReleased;
            italicButton.BackColor = a_font.Italic ? m_buttonPressed : m_buttonReleased;
            underlineButton.BackColor = a_font.Underline ? m_buttonPressed : m_buttonReleased;
            colorButton.BackColor = a_fore;
        }

        /// <summary>
        /// This function sets the font in the rich text box according to user's choice.
        /// </summary>
        /// <param name="a_font">It holds the font value.</param>
        /// <param name="a_fore">It holds the fore color value.</param>
        private void SetFont(Font a_font, Color a_fore)
        {
            m_preferredFont = a_font;
            assignmentRTB.SelectionFont = m_preferredFont;

            m_preferredForeColor = a_fore;
            assignmentRTB.SelectionColor = a_fore;

            FixFontUI(m_preferredFont, m_preferredForeColor);
        }

        /// <summary>
        /// This function is triggered when color button is clicked.
        /// It brings up the color changing dialog.
        /// </summary>
        /// <param name="a_sender">It holds the sender.</param>
        /// <param name="a_event">It holds the event.</param>
        private void ColorButton_Click(object a_sender, EventArgs a_event)
        {
            DialogResult result = colorDialog1.ShowDialog();

            /// See if OK was pressed.
            if (result == DialogResult.OK)
            {
                SetFont(m_preferredFont, colorDialog1.Color);
            }
        }

        /// <summary>
        /// This function is triggered if the bold button is clicked.
        /// It then changes the font type as bold.
        /// </summary>
        /// <param name="a_sender">It holds the sender.</param>
        /// <param name="a_event">It holds the event args.</param>
        private void BoldButton_Click(object a_sender, EventArgs a_event)
        {
            Font newFont = m_preferredFont.Bold ? new Font(m_preferredFont, FontStyle.Regular) :
                new Font(m_preferredFont, FontStyle.Bold);
            
            /// Sets the font to bold or vice versa.
            SetFont(newFont, m_preferredForeColor);
        }

        /// <summary>
        /// This function is triggered if the user presses italic button 
        /// making the text italic.
        /// </summary>
        /// <param name="a_sender">It holds the sender.</param>
        /// <param name="a_event">It holds the event args.</param>
        private void ItalicButton_Click(object a_sender, EventArgs a_event)
        {
            Font newFont = m_preferredFont.Italic ? new Font(m_preferredFont, FontStyle.Regular) :
                new Font(m_preferredFont, FontStyle.Italic);

            SetFont(newFont, m_preferredForeColor);
        }

        /// <summary>
        /// This function is triggered when underline button is clicked and makes text 
        /// underline.
        /// </summary>
        /// <param name="a_sender">It holds the sender.</param>
        /// <param name="a_event">It holds the event args.</param>
        private void UnderlineButton_Click(object a_sender, EventArgs a_event)
        {
            Font newFont = m_preferredFont.Underline ? new Font(m_preferredFont, FontStyle.Regular) :
                new Font(m_preferredFont, FontStyle.Underline);

            SetFont(newFont, m_preferredForeColor);
        }

        /// <summary>
        /// This function is triggered when cancel button is clicked hence
        /// canceling whatever edit was made.
        /// </summary>
        /// <param name="a_sender">It holds the sender.</param>
        /// <param name="a_event">It holds the event args.</param>
        private void CancelBox_Click(object a_sender, EventArgs a_event)
        {
            /// Disables all the fields from editing and updates the assignment view
            /// with previous update.
            SetFieldsEnabled(false);
            UpdateAssgnView();
        }

        /// <summary>
        /// This function opens the discusison for the assignment if it is clicked.
        /// </summary>
        /// <param name="a_sender">It holds the sender.</param>
        /// <param name="a_event">It holds the event args.</param>
        private void DiscussionTile_Click(object a_sender, EventArgs a_event)
        {
            DiscussionForm form = new DiscussionForm(m_currentAssgn, m_email);
            form.ShowDialog();
        }

        
    }
}
