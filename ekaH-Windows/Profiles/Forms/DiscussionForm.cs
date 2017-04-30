using ekaH_Windows.Model;
using MetroFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ekaH_Windows.Profiles.Forms
{
    /// <summary>
    /// This class shows the discussion form for the particular assignment.
    /// </summary>
    public partial class DiscussionForm : MetroFramework.Forms.MetroForm
    {
        /// <summary>
        /// It holds the email of the sender.
        /// </summary>
        private string m_senderEmail;

        /// <summary>
        /// It holds the current assignment.
        /// </summary>
        private Assignment m_currentAssgn;

        /// <summary>
        /// It holds the current discussion thread.
        /// </summary>
        private Discussion m_currentDisc;

        /// <summary>
        /// This is a constructor that initiates the discussion form.
        /// </summary>
        /// <param name="a_assgn">It holds the current assignment.</param>
        /// <param name="a_em">It holds the current user's email.</param>
        public DiscussionForm(Assignment a_assgn, string a_em)
        {
            m_currentAssgn = a_assgn;
            m_senderEmail = a_em;
            
            InitializeComponent();
        }

        /// <summary>
        /// This function gets the discussion if it already exists. If not, then it creates a new discussion
        /// giving the user interactive experience.
        /// </summary>
        /// <param name="a_sender">It holds the sender.</param>
        /// <param name="a_event">It holds the event arguments.</param>
        private void DiscussionForm_Load(object a_sender, EventArgs a_event)
        {
            /// Gets the discussion content for current assignment.
            m_currentDisc = GetDiscussionRequest(m_currentAssgn.id);

            if (m_currentDisc == null) Close();

            discussionRTF.Clear();

            /// Decodes the content received from the server and then puts it on the screen.
            string decodedString = WebUtility.UrlDecode(m_currentDisc.Content);

            try
            {
                discussionRTF.Rtf = decodedString;
            }
            catch(Exception)
            {
                MetroMessageBox.Show(this, "Cannot display format for some reason. Try again later.", "Cannot display", 
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        /// <summary>
        /// This function encodes the user's content and then appends it to the discussion thread.
        /// </summary>
        /// <param name="a_sender">It is the sender.</param>
        /// <param name="a_event">It is the event arguments.</param>
        private void SendTile_Click(object a_sender, EventArgs a_event)
        {
            string toAdd = textBox.Text + "\r\n";
            string requester = m_senderEmail.Split('@')[0];

            /// Displays the string according to the format.
            discussionRTF.SelectionStart = discussionRTF.TextLength;
            discussionRTF.SelectionLength = 0;
            discussionRTF.SelectionFont = new Font(discussionRTF.Font, FontStyle.Bold);
            discussionRTF.AppendText(requester + " : ");

            discussionRTF.SelectionStart = discussionRTF.TextLength;
            discussionRTF.SelectionFont = new Font(discussionRTF.Font, FontStyle.Regular);
            discussionRTF.AppendText(toAdd);

            /// Encodes the string and puts it in the database.
            string encoded = WebUtility.UrlEncode(discussionRTF.Rtf);

            m_currentDisc.Content = encoded;

            PutDiscussion(m_currentDisc);

            textBox.Text = "";
        }

        /// <summary>
        /// This function returns the discussion object with all the content.
        /// </summary>
        /// <param name="a_id">It holds the assignment id.</param>
        /// <returns>Returns the discussion object that contains the thread's contents.</returns>
        private Discussion GetDiscussionRequest(long a_id)
        {
            HttpClient client = NetworkClient.getInstance().getHttpClient();

            string uri = BaseConnection.g_discussion + "/" + BaseConnection.g_threadString + "/" + a_id;

            try
            {
                var res = client.GetAsync(uri).Result;

                /// Tries to get the discussion content and if it has never been set, it makes a new discussion thread
                /// for the assignment.
                if (res.IsSuccessStatusCode)
                {
                    Discussion disc = res.Content.ReadAsAsync<Discussion>().Result;

                    return disc;
                }
                else if (res.StatusCode == HttpStatusCode.NotFound)
                {
                    /// Creates a discussion thread since it did not already exist.
                    Discussion disc = new Discussion();
                    disc.AssignmentID = m_currentAssgn.id;
                    disc.Content = "";
                    
                    if (PutDiscussion(disc))
                    {
                        return GetDiscussionRequest(m_currentAssgn.id);
                    }
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
        /// This function puts the changes in the discussion thread to the server.
        /// </summary>
        /// <param name="a_disc">It holds the modified discussion thread.</param>
        /// <returns>Returns true if it successfully made changes in the server.</returns>
        private bool PutDiscussion(Discussion a_disc)
        {
            // Gets the instance of the client.
            HttpClient client = NetworkClient.getInstance().getHttpClient();

            string uri = BaseConnection.g_discussion + "/" + BaseConnection.g_threadString + "/" + a_disc.Id;

            try
            {
                /// Puts the changed discussion thread to the server.
                var res = client.PutAsJsonAsync<Discussion>(uri, a_disc).Result;

                if (res.IsSuccessStatusCode)
                {
                    return true;
                }

            }
            catch (Exception)
            {
                Worker.printServerError(this);
            }

            /// Returns false if exceptions were found.
            return false;
        }
    }
}
