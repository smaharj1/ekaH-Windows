using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;

namespace ekaH_Windows.Profiles.Forms.Chat
{
    public partial class SingleChat : MetroFramework.Forms.MetroForm
    {
        private string Sender { get; set; }
        private string Receiver { get; set; }
        private Socket ClientSocket { get; set; }

        delegate void SetTextCallback(string text);


        public SingleChat(string user, string connectingUser)
        {
            Sender = user;
            Receiver = connectingUser;
            InitializeComponent();

            Text = "You are chatting with " + Receiver;
        }

        // Prints out the received data to the window.
        public void handleReceivedData(string receivedString)
        {
            string[] user = Receiver.Split('@');
            //messageBox.Select(0, user[0].Length);
            //messageBox.SelectionFont = new Font("Segoe UI", 12, FontStyle.Bold);
            string temp = user[0] + " : " + receivedString + "\r\n";

            SetText(temp);
        }
        
        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (messageBox.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                Invoke(d, new object[] { text });
            }
            else
            {
                messageBox.Text = text;
            }
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            handleSendText();
        }
        
        private void handleSendText()
        {
            string toSend = Receiver + OnlineChat.CONVO_LOGIC + messageTextBox.Text;

            if (ClientSocket == null)
            {
                MetroMessageBox.Show(this, "Weird error!", "The client is connected but at the same time not connected :/ Try again.",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                byte[] buff = Encoding.ASCII.GetBytes(toSend);
                ClientSocket.Send(buff);

                string temp = "You : " + messageTextBox.Text + "\r\n";
                SetText(temp);
            }
        }

        public void assignClient(Socket clientSoc)
        {
            ClientSocket = clientSoc;
        }

    }
}
