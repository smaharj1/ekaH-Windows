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
    public partial class DiscussionForm : MetroFramework.Forms.MetroForm
    {
        private string senderEmail;
        private Assignment currentAssgn;
        private Discussion currentDisc;

        public DiscussionForm(Assignment assgn, string em)
        {
            currentAssgn = assgn;
            senderEmail = em;

            
            
            InitializeComponent();
        }

        private void DiscussionForm_Load(object sender, EventArgs e)
        {
            currentDisc = GetDiscussionRequest(currentAssgn.id);

            if (currentDisc == null) Close();

            discussionRTF.Clear();

            string decodedString = WebUtility.UrlDecode(currentDisc.content);

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

        private void sendTile_Click(object sender, EventArgs e)
        {
            string toAdd = textBox.Text;
            string requester = senderEmail.Split('@')[0];

            discussionRTF.SelectionStart = discussionRTF.TextLength;
            discussionRTF.SelectionLength = 0;
            discussionRTF.SelectionFont = new Font(discussionRTF.Font, FontStyle.Bold);
            discussionRTF.AppendText(requester + " : ");

            discussionRTF.SelectionStart = discussionRTF.TextLength;
            discussionRTF.SelectionFont = new Font(discussionRTF.Font, FontStyle.Regular);
            discussionRTF.AppendText(toAdd);

            string encoded = WebUtility.UrlEncode(discussionRTF.Rtf);

            currentDisc.content = encoded;

            PutDiscussion(currentDisc);

            textBox.Text = "";

        }

        private Discussion GetDiscussionRequest(long id)
        {
            HttpClient client = NetworkClient.getInstance().getHttpClient();

            string uri = BaseConnection.discussion + "/" + BaseConnection.threadString + "/" + id;

            try
            {
                var res = client.GetAsync(uri).Result;

                if (res.IsSuccessStatusCode)
                {
                    Discussion disc = res.Content.ReadAsAsync<Discussion>().Result;

                    return disc;
                }
                else if (res.StatusCode == HttpStatusCode.NotFound)
                {
                    // Makes a post call to discussion here.
                    Discussion disc = new Discussion();
                    disc.assignmentID = currentAssgn.id;
                    disc.content = "";
                    
                    if (PutDiscussion(disc))
                    {
                        return GetDiscussionRequest(currentAssgn.id);
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

        private bool PutDiscussion(Discussion disc)
        {
            HttpClient client = NetworkClient.getInstance().getHttpClient();

            string uri = BaseConnection.discussion + "/" + BaseConnection.threadString + "/" + disc.id;

            try
            {
                var res = client.PutAsJsonAsync<Discussion>(uri, disc).Result;

                if (res.IsSuccessStatusCode)
                {
                    return true;
                }

            }
            catch (Exception)
            {
                Worker.printServerError(this);
            }

            return false;
        }
    }
}
