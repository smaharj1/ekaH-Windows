using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using ekaH_Windows.Model;
using System.Net.Sockets;
using System.Net;
using ekaH_Windows.Profiles.Forms.Chat;

namespace ekaH_Windows.Profiles.Forms
{
    /// <summary>
    /// This class features the client side for the online chat feature.
    /// </summary>
    public partial class OnlineChat : MetroFramework.Forms.MetroForm
    {
        /// <summary>
        /// This constant represents the logic used to separate username and the message from the user.
        /// </summary>
        public const string g_convoLogic = ":@:";

        /// <summary>
        /// It holds the client socket.
        /// </summary>
        private Socket m_clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        /// <summary>
        /// It holds the global buffer.
        /// </summary>
        byte[] m_globalBuffer = new byte[1024];

        /// <summary>
        /// It holds the current user's email.
        /// </summary>
        private string m_currentUserEmail { get; set; }

        /// <summary>
        /// This is a call back function for inter thread communication of the UI thread.
        /// </summary>
        /// <param name="a_text">It holds the text to be printed that was given from different thread.</param>
        delegate void SetCallback(string a_text);

        /// <summary>
        /// It holds the list of all users who are online.
        /// </summary>
        private List<string> m_allUsers;

        /// <summary>
        /// It holds the conversation of current user with other users.
        /// </summary>
        private Dictionary<string, SingleChat> m_conversations;
        
        /// <summary>
        /// This is a constructor that stores the email and initiates the lists of user.
        /// </summary>
        /// <param name="email"></param>
        public OnlineChat(string email)
        {
            m_currentUserEmail = email;
            InitializeComponent();

            m_allUsers = new List<string>();
            m_conversations = new Dictionary<string, SingleChat>();
        }

        /// <summary>
        /// This function connects the user to the chat server.
        /// </summary>
        /// <param name="a_sender">It holds the sender.</param>
        /// <param name="a_event">It holds the event arguments.</param>
        private void OnlineChat_Load(object a_sender, EventArgs a_event)
        {
            ConnectUser(m_currentUserEmail);
        }

        /// <summary>
        /// This function connects the user to the TCP server.
        /// </summary>
        /// <param name="a_email">It holds the email of the user.</param>
        private void ConnectUser(string a_email)
        {
            // Continuously loops to connect to the server.
            LoopConnect();

            // Starts listening to the socket and then connects the user initially to the server.
            m_clientSocket.BeginReceive(m_globalBuffer, 0, m_globalBuffer.Length, SocketFlags.None, new AsyncCallback(ReceiveData), m_clientSocket);
            byte[] buff = Encoding.ASCII.GetBytes("@@@" + a_email);
            m_clientSocket.Send(buff);
        }

        /// <summary>
        /// This function handles the received data. It primarily prints the data into the conversation board.
        /// </summary>
        /// <param name="a_asyncRes"></param>
        // It receives the data from the server.
        private void ReceiveData(IAsyncResult a_asyncRes)
        {
            /// Gets the socket.
            Socket socket = (Socket)a_asyncRes.AsyncState;
            int received = socket.EndReceive(a_asyncRes);

            byte[] dataBuf = new byte[received];

            /// Copies the content into the data buffer and then converts it into the string.
            Array.Copy(m_globalBuffer, dataBuf, received);

            string receivedString = Encoding.ASCII.GetString(dataBuf);

            /// Checks what kind of information is received.
            /// If it is $client$, it consists of all the clients who are online at the moment. This is only received
            /// if people join/leave the online status.
            /// Otherwise, it is perceived as receiving conversation message. Then, it handles the received conversation
            /// message accordingly.
            if (receivedString.StartsWith("$clients$"))
            {
                /// This means that user is receiving the list of clients.
                receivedString = receivedString.Substring(9);
                writeToList(receivedString);
            }
            else
            {
                /// Parses the message to check who sent the message.
                string[] splitted = receivedString.Split(new string[] { g_convoLogic }, 2, StringSplitOptions.None);
                string email = splitted[0];
                
                /// If the conversation is co-existing, then update into the existing conversation. 
                /// Else, make a new conversation.
                if (m_conversations.ContainsKey(email))
                {
                    m_conversations[email].HandleReceivedData(splitted[1]);
                    if (m_conversations[email].InvokeRequired)
                    {
                        Invoke(new SetCallback(BringConversationToFront), new object[] { email});
                    }
                    else
                    {
                        BringConversationToFront(email);
                    }
                }
                else
                {
                    m_conversations[email] = new SingleChat(m_currentUserEmail, email);
                    m_conversations[email].HandleReceivedData(splitted[1]);
                    m_conversations[email].AssignClient(m_clientSocket);
                    m_conversations[email].ShowDialog();
                }
            }
            
            /// Begins listening to the socket again.
            m_clientSocket.BeginReceive(m_globalBuffer, 0, m_globalBuffer.Length, SocketFlags.None, new AsyncCallback(ReceiveData), m_clientSocket);
        }

        /// <summary>
        /// This function brings the conversation form to the front.
        /// </summary>
        /// <param name="a_email">It holds the user's email.</param>
        private void BringConversationToFront(string a_email)
        {
            m_conversations[a_email].BringToFront();
        }

        /// <summary>
        /// This function is triggered if an online user is double clicked resulting in opening new form to chat.
        /// </summary>
        /// <param name="a_sender">It holds the sender.</param>
        /// <param name="a_event">It holds the event arguments.</param>
        public void ListDoubleClicked(Object a_sender, EventArgs a_event)
        {
            /// Gets the selected user and opens up the conversation.
            string selected = userListView.SelectedItems[0].Text;
            
            if (!m_conversations.ContainsKey(selected))
            {
                m_conversations[selected] = new SingleChat(m_currentUserEmail, selected);
                m_conversations[selected].AssignClient(m_clientSocket);
                m_conversations[selected].Show();
            }
            else
            {
                m_conversations[selected].BringToFront();
            }
        }

        /// <summary>
        /// This function parses the received text of online users and puts it into the
        /// list.
        /// </summary>
        /// <param name="a_unparsedList">It holds the unparsed list in string representation.</param>
        private void writeToList(string a_unparsedList)
        {
            /// Populates the list.
            string[] users = a_unparsedList.Split('|');

            if (userListView.InvokeRequired)
            {
                userListView.Invoke(new MethodInvoker(delegate
                {
                    // Clears the list first.
                    userListView.Items.Clear();

                    foreach (string user in users)
                    {
                        if (!String.Equals(user, m_currentUserEmail))
                        {
                            userListView.Items.Add(user);
                        }
                    }
                }));

            }
        }

        /// <summary>
        /// This function tries to connect user to the server until it is connected.
        /// </summary>
        private void LoopConnect()
        {
            int attempts = 0;
            while (!m_clientSocket.Connected)
            {
                try
                {
                    /// Counts the attempts made to connect to the chat server.
                    attempts++;
                    m_clientSocket.Connect(IPAddress.Loopback, 4050);
                }
                catch (SocketException)
                {
                    MetroMessageBox.Show(this, "Could not connect to the server!");
                }
            }
        }

    }
}
