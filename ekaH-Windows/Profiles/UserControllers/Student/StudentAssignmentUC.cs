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
using System.Net;
using System.Net.Http;
using System.IO;
using MetroFramework;
using ekaH_Windows.Profiles.Forms;

namespace ekaH_Windows.Profiles.UserControllers.Student
{
    /// <summary>
    /// This class allows the students to upload files for the given assignment.
    /// </summary>
    public partial class StudentAssignmentUC : MetroFramework.Controls.MetroUserControl
    {
        /// <summary>
        /// It holds all the assignments that are open currently.
        /// </summary>
        private List<Assignment> m_openAssignments;

        /// <summary>
        /// It holds the current open assignment.
        /// </summary>
        private Assignment m_currentAssgn;

        /// <summary>
        /// It holds the submission of current assignment.
        /// </summary>
        private bool m_currentAssgnSubmitted;

        /// <summary>
        /// It holds student's email.
        /// </summary>
        private string m_studentEmail;

        /// <summary>
        /// It holds the file submitted by the user.
        /// </summary>
        private Submission m_submitted;
        
        /// <summary>
        /// This is a constructor that initializes the email.
        /// </summary>
        /// <param name="a_stdEmail">It holds the email of the student.</param>
        public StudentAssignmentUC(string a_stdEmail)
        {
            m_studentEmail = a_stdEmail;
            m_openAssignments = new List<Assignment>();
            InitializeComponent();
        }

        /// <summary>
        /// This function opens an assignment.
        /// </summary>
        /// <param name="a_assgn">It holds the assignment that needs to be opened.</param>
        public void Open (Assignment a_assgn)
        {
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

            m_submitted = GetSubmittedSolution();

            /// Updates the view of the UI.
            UpdateTaskView();
            UpdateSubmissionView();
        }

        /// <summary>
        /// This funciton updates the rich text box by first decoding it.
        /// </summary>
        private void UpdateTaskView()
        {
            projectName.Text = m_currentAssgn.projectTitle;
            weightTextBox.Text = m_currentAssgn.weight >0 ?m_currentAssgn.weight.ToString() + "%" : "TBD";
            deadlineBox.Value = m_currentAssgn.deadline;
            assignmentRTB.Clear();

            string decodedString = WebUtility.UrlDecode(m_currentAssgn.content);
            
            /// Decodes the rich text box content and puts it on the screen.
            try
            {
                assignmentRTB.Rtf = decodedString;
            }
            catch (Exception)
            {
                assignmentRTB.Text = m_currentAssgn.content;
            }
        }

        /// <summary>
        /// This function updates the submission view and indicates if the user can
        /// submit the assignment or not.
        /// </summary>
        private void UpdateSubmissionView()
        {
            if (m_submitted != null)
            {
                /// Gives the detail on when the assignment was last submitted.
                m_currentAssgnSubmitted = true;
                if (m_currentAssgn.deadline > DateTime.Today) statusLabel.Text = "Open";
                else statusLabel.Text = "Closed";

                submittedLabel.Text = "Submitted it on " + m_submitted.submissionDateTime.ToString();

                gradeView.Text = m_submitted.grade == -1 ? "TBD" : m_submitted.grade + "/100";      
            }
            else
            {
                m_currentAssgnSubmitted = false;
                statusLabel.Text = "Willie Wonka. Nothing submitted yet!";
                gradeView.Text = "TBD";
                submittedLabel.Text = "None";
            }
        }

        /// <summary>
        /// The function gets the solution provided by the user for the given assignment 
        /// through assignment ID and student ID.
        /// </summary>
        /// <returns>Returns the submission made by the student.</returns>
        private Submission GetSubmittedSolution()
        {
            HttpClient client = NetworkClient.getInstance().getHttpClient();

            string uri = BaseConnection.g_submissions + "/" + BaseConnection.g_submitAction + "/" +
                m_currentAssgn.id + "/" + m_studentEmail + "/";

            try
            {
                var response = client.GetAsync(uri).Result;

                /// If response was successful, it returns the submitted file.
                if (response.IsSuccessStatusCode)
                {
                    List<Submission> submissions = response.Content.ReadAsAsync<List<Submission>>().Result;

                    if (submissions.Count == 0)
                    {
                        return null;
                    }
                    else if (submissions.Count == 1)
                    {
                        return submissions[0];
                    }

                    submissions.OrderBy(sub=> sub.submissionDateTime);

                    return submissions[submissions.Count - 1];

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

            return null;
        }

        /// <summary>
        /// This function helps the user to upload the documents they want. 
        /// It should be zip file if it is more than one file.
        /// </summary>
        /// <param name="a_sender">It holds the sender.</param>
        /// <param name="a_event">It holds the event args.</param>
        private void SubmissionIcon_Click(object a_sender, EventArgs a_event)
        {
            /// Checks if the deadline has already passed.
            if (m_currentAssgn.deadline < DateTime.Today)
            {
                MetroMessageBox.Show(this, "You cannot submit it anymore since the deadline has been passed.",
                        "Deadline passed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = fileDialog.ShowDialog();

            if (result != DialogResult.OK)
            {
                return;
            }

            string filepath = fileDialog.FileName;

            byte[] content = File.ReadAllBytes(filepath);

            /// Checks if the assignment open is already submitted. If it is 
            /// already submitted, it resubmits the solution.
            if (m_currentAssgnSubmitted)
            {
                m_submitted.grade = -1;
                m_submitted.submissionDateTime = DateTime.Today;
                m_submitted.submissionContent = content;
                m_submitted.submissionFileName = fileDialog.SafeFileName;

                if (PutSubmission(m_submitted)) UpdateSubmissionView();
            }
            else
            {
                Submission sub = new Submission();

                sub.assignmentID = m_currentAssgn.id;
                sub.studentID = m_studentEmail;
                sub.grade = -1;
                sub.submissionContent = content;
                sub.submissionDateTime = DateTime.Today;
                sub.submissionFileName = fileDialog.SafeFileName;

                /// Makes a POST call.
                if (PostSubmission(sub)) UpdateSubmissionView();
            }
        }

        /// <summary>
        /// This function modifies the already submitted assignment.
        /// </summary>
        /// <param name="a_submission">It holds the submission.</param>
        /// <returns>Returns true if the submission was successfully modified.</returns>
        private bool PutSubmission(Submission a_submission)
        {
            HttpClient client = NetworkClient.getInstance().getHttpClient();

            string uri = BaseConnection.g_submissions + "/" + BaseConnection.g_submitAction + "/"+ a_submission.id;

            try
            {
                var response = client.PutAsJsonAsync(uri, a_submission).Result;

                /// Verifies if the server successfully modified the file.
                if (response.IsSuccessStatusCode)
                {
                    MetroMessageBox.Show(this, "Successfully submitted your solution for the assignment",
                        "Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_submitted = a_submission;
                    return true;
                }
                else if (response.StatusCode == HttpStatusCode.Forbidden)
                {
                    MetroMessageBox.Show(this, "You cannot submit it anymore since the deadline has been passed.",
                        "Deadline passed", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            /// Returns false if modification unsuccessful.
            return false;
        }

        /// <summary>
        /// This function submits a new file to the server.
        /// </summary>
        /// <param name="a_submission">It holds the submission object.</param>
        /// <returns>Returns true if submission was successful.</returns>
        private bool PostSubmission(Submission a_submission)
        {
            HttpClient client = NetworkClient.getInstance().getHttpClient();

            string uri = BaseConnection.g_submissions + "/" + BaseConnection.g_submitAction + "/";

            try
            {
                var response = client.PostAsJsonAsync(uri, a_submission).Result;

                /// Checks if the submission was successful and returns true.
                if (response.IsSuccessStatusCode)
                {
                    MetroMessageBox.Show(this, "Successfully submitted your solution for the assignment",
                        "Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_submitted = a_submission;
                    return true;
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

            return false;
        }

        /// <summary>
        /// This function is triggered if download button is clicked for the submission.
        /// </summary>
        /// <param name="a_sender">It holds the sender.</param>
        /// <param name="a_event">It holds the event args.</param>
        private void DownloadSubmission_Click(object a_sender, EventArgs a_event)
        {
            if (m_currentAssgnSubmitted)
            {
                /// Allows the student to download whatever they submitted.
                if (m_submitted.submissionFileName != null)
                {
                    string[] split = m_submitted.submissionFileName.Split('.');
                    saveFileDialog.Filter = "Given format |*." + split[1];
                    saveFileDialog.Title = split[0];
                }
                DialogResult result = saveFileDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string filepath = saveFileDialog.FileName;
                    File.WriteAllBytes(filepath, m_submitted.submissionContent);
                }
            }
        }

        /// <summary>
        /// This function opens the discusison form for the assignment.
        /// </summary>
        /// <param name="a_sender">It holds the sender.</param>
        /// <param name="a_event">It holds the event args.</param>
        private void DiscussionTile_Click(object a_sender, EventArgs a_event)
        {
            DiscussionForm discForm = new DiscussionForm(m_currentAssgn ,m_studentEmail);
            discForm.ShowDialog();
        }
    }
}
