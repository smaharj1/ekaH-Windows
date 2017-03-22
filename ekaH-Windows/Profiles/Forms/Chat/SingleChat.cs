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

        public SingleChat(string user, string connectingUser)
        {
            Sender = user;
            Receiver = connectingUser;
            InitializeComponent();

            this.Text = "You are chatting with " + Receiver;
        }

        // Prints out the received data to the window.
        public void handleReceivedData(string receivedString)
        {
            messageBox.Text += receivedString + "\r\n";
        }

        private void sendButton_Click(object sender, EventArgs e)
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
            }
            
        }

        public void assignClient(Socket clientSoc)
        {
            ClientSocket = clientSoc;
        }

    }
}
