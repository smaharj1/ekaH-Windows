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
    public partial class StudentAssignmentUC : MetroFramework.Controls.MetroUserControl
    {
        private List<Assignment> openAssignments;
        private Assignment currentAssgn;
        private bool currentAssgnSubmitted;
        private string studentEmail;

        private Submission submitted;
        
        public StudentAssignmentUC(string stdEmail)
        {
            studentEmail = stdEmail;
            openAssignments = new List<Assignment>();
            InitializeComponent();
        }

        public void open (Assignment assgn)
        {
            // Checks if the assignment was previously open to reduce the number of UC objects being formed.
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

            submitted = getSubmittedSolution();

            updateTaskView();
            updateSubmissionView();
        }

        private void updateTaskView()
        {
            projectName.Text = currentAssgn.projectTitle;
            weightTextBox.Text = currentAssgn.weight >0 ?currentAssgn.weight.ToString() + "%" : "TBD";
            deadlineBox.Value = currentAssgn.deadline;
            assignmentRTB.Clear();

            string decodedString = WebUtility.UrlDecode(currentAssgn.content);
            // For now, just do the content.
            try
            {
                assignmentRTB.Rtf = decodedString;
            }
            catch (Exception)
            {
                assignmentRTB.Text = currentAssgn.content;
            }
        }

        private void updateSubmissionView()
        {
            if (submitted != null)
            {
                currentAssgnSubmitted = true;
                if (currentAssgn.deadline > DateTime.Today) statusLabel.Text = "Open";
                else statusLabel.Text = "Closed";

                submittedLabel.Text = "Submitted it on " + submitted.submissionDateTime.ToString();

                gradeView.Text = submitted.grade == -1 ? "TBD" : submitted.grade + "/100";      
            }
            else
            {
                currentAssgnSubmitted = false;
                statusLabel.Text = "Willie Wonka. Nothing submitted yet!";
                gradeView.Text = "TBD";
                submittedLabel.Text = "None";
            }
        }

        /// <summary>
        /// Gets the solution provided by the user for the given assignment through assignment ID and student ID.
        /// </summary>
        /// <returns></returns>
        private Submission getSubmittedSolution()
        {
            HttpClient client = NetworkClient.getInstance().getHttpClient();

            string uri = BaseConnection.g_submissions + "/" + BaseConnection.g_submitAction + "/" +
                currentAssgn.id + "/" + studentEmail + "/";

            try
            {
                var response = client.GetAsync(uri).Result;

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
        /// Helps the user to upload the documents they want. It should be zip file if it is more than one file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void submissionIcon_Click(object sender, EventArgs e)
        {
            if (currentAssgn.deadline < DateTime.Today)
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

            /// Checks if the assignment open is already submitted. If it is already submitted, it resubmits the solution.
            if (currentAssgnSubmitted)
            {
                submitted.grade = -1;
                submitted.submissionDateTime = DateTime.Today;
                submitted.submissionContent = content;
                submitted.submissionFileName = fileDialog.SafeFileName;

                if (putSubmission(submitted)) updateSubmissionView();
            }
            else
            {
                Submission sub = new Submission();

                sub.assignmentID = currentAssgn.id;
                sub.studentID = studentEmail;
                sub.grade = -1;
                sub.submissionContent = content;
                sub.submissionDateTime = DateTime.Today;
                sub.submissionFileName = fileDialog.SafeFileName;

                /// Makes a POST call.
                if (postSubmission(sub)) updateSubmissionView();
                

            }
        }

        private bool putSubmission(Submission submission)
        {
            HttpClient client = NetworkClient.getInstance().getHttpClient();

            string uri = BaseConnection.g_submissions + "/" + BaseConnection.g_submitAction + "/"+ submission.id;

            try
            {
                var response = client.PutAsJsonAsync(uri, submission).Result;

                if (response.IsSuccessStatusCode)
                {
                    MetroMessageBox.Show(this, "Successfully submitted your solution for the assignment",
                        "Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    submitted = submission;
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
            return false;
        }

        private bool postSubmission(Submission submission)
        {
            HttpClient client = NetworkClient.getInstance().getHttpClient();

            string uri = BaseConnection.g_submissions + "/" + BaseConnection.g_submitAction + "/";

            try
            {
                var response = client.PostAsJsonAsync(uri, submission).Result;

                if (response.IsSuccessStatusCode)
                {
                    MetroMessageBox.Show(this, "Successfully submitted your solution for the assignment",
                        "Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    submitted = submission;
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

        private void downloadSubmission_Click(object sender, EventArgs e)
        {
            if (currentAssgnSubmitted)
            {
                if (submitted.submissionFileName != null)
                {
                    string[] split = submitted.submissionFileName.Split('.');
                    saveFileDialog.Filter = "Given format |*." + split[1];
                    saveFileDialog.Title = split[0];
                }
                DialogResult result = saveFileDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string filepath = saveFileDialog.FileName;
                    File.WriteAllBytes(filepath, submitted.submissionContent);
                }
            }
        }

        private void discussionTile_Click(object sender, EventArgs e)
        {
            DiscussionForm discForm = new DiscussionForm(currentAssgn ,studentEmail);
            discForm.ShowDialog();
        }
    }
}
