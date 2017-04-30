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
    /// <summary>
    /// This class gives the functionalities to chat with single user.
    /// </summary>
    public partial class SingleChat : MetroFramework.Forms.MetroForm
    {
        /// <summary>
        /// It holds the sender's email.
        /// </summary>
        private string Sender { get; set; }

        /// <summary>
        /// It holds the receiver's email.
        /// </summary>
        private string Receiver { get; set; }

        /// <summary>
        /// It holds the client socket.
        /// </summary>
        private Socket ClientSocket { get; set; }

        /// <summary>
        /// It is a delegate method for cross-thread communication.
        /// </summary>
        /// <param name="a_text">It holds the text to be printed in the textbox.</param>
        delegate void SetTextCallback(string a_text);

        /// <summary>
        /// This is a constructor that initializes the sender and receiver.
        /// </summary>
        /// <param name="a_user">It holds the sender email.</param>
        /// <param name="a_connectingUser">It holds the receiver email.</param>
        public SingleChat(string a_user, string a_connectingUser)
        {
            Sender = a_user;
            Receiver = a_connectingUser;
            InitializeComponent();

            Text = "You are chatting with " + Receiver;
        }

        /// <summary>
        /// This function prints out the received data to the window.
        /// </summary>
        /// <param name="a_receivedString">It holds the received string unparsed.</param>
        public void HandleReceivedData(string a_receivedString)
        {
            /// Parses the string and displays it accordingly.
            string[] user = Receiver.Split('@');
            string temp = user[0] + " : " + a_receivedString + "\r\n";

            SetText(temp);
        }
        
        /// <summary>
        /// This function sets the text into the screen.
        /// </summary>
        /// <param name="a_text">It holds the string to be displayed.</param>
        private void SetText(string a_text)
        {
            /// InvokeRequired required compares the thread ID of the
            /// calling thread to the thread ID of the creating thread.
            /// If these threads are different, it returns true.
            if (messageBox.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                Invoke(d, new object[] { a_text });
            }
            else
            {
                messageBox.Text += a_text;
            }
        }

        /// <summary>
        /// This function is triggered when send button is clicked resulting in sending the text to 
        /// the user the current person is interacting with.
        /// </summary>
        /// <param name="a_sender">It holds the sender.</param>
        /// <param name="a_event">It holds the event arguments.</param>
        private void SendButton_Click(object a_sender, EventArgs a_event)
        {
            HandleSendText();
        }
        
        /// <summary>
        /// This function handles sending the text to the receiver.
        /// </summary>
        private void HandleSendText()
        {
            /// Encodes the string in a recognizable way to the server.
            string toSend = Receiver + OnlineChat.g_convoLogic + messageTextBox.Text;

            if (ClientSocket == null)
            {
                MetroMessageBox.Show(this, "Weird error!", "The client is connected but at the same time not connected :/ Try again.",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                byte[] buff = Encoding.ASCII.GetBytes(toSend);

                /// Sends the text.
                ClientSocket.Send(buff);

                string temp = "You : " + messageTextBox.Text + "\r\n";
                SetText(temp);
            }
        }

        /// <summary>
        /// This function assigns the client to this object. The client refers to the sender.
        /// </summary>
        /// <param name="a_client"></param>
        public void AssignClient(Socket a_client)
        {
            ClientSocket = a_client;
        }

    }
}
