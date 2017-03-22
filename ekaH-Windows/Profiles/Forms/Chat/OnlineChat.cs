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
    public partial class OnlineChat : MetroFramework.Forms.MetroForm
    {
        public const string CONVO_LOGIC = ":@:";
        private Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        byte[] globalBuffer = new byte[1024];

        private string CurrentUser { get; set; }

        private List<string> allUsers;
        private Dictionary<string, SingleChat> conversations;

        public OnlineChat()
        {
            InitializeComponent();
            allUsers = new List<string>();

        }

        public OnlineChat(string email)
        {
            CurrentUser = email;
            InitializeComponent();

            allUsers = new List<string>();
            conversations = new Dictionary<string, SingleChat>();

        }

        private void OnlineChat_Load(object sender, EventArgs e)
        {
            //connectUser();
            //populate();
        }

        // Connects the user to the TCP server.
        private void connectUser(string email)
        {
            LoopConnect();

            clientSocket.BeginReceive(globalBuffer, 0, globalBuffer.Length, SocketFlags.None, new AsyncCallback(ReceiveData), clientSocket);
            byte[] buff = Encoding.ASCII.GetBytes("@@@" + email);
            clientSocket.Send(buff);

        }

        // It receives the data from the server.
        private void ReceiveData(IAsyncResult ar)
        {
            Socket socket = (Socket)ar.AsyncState;
            int received = socket.EndReceive(ar);

            byte[] dataBuf = new byte[received];

            Array.Copy(globalBuffer, dataBuf, received);

            string receivedString = Encoding.ASCII.GetString(dataBuf);

            if (receivedString.StartsWith("$clients$"))
            {
                // This means that user is receiving the list of clients.
                receivedString = receivedString.Substring(9);
                writeToList(receivedString);
            }
            else
            {
                string[] splitted = receivedString.Split(new string[] { CONVO_LOGIC }, 2, StringSplitOptions.None);
                string email = splitted[0];
                
                if (conversations.ContainsKey(email))
                {
                    conversations[email].handleReceivedData(splitted[1]);
                    conversations[email].BringToFront();
                }
                else
                {
                    conversations[email] = new SingleChat(CurrentUser, email);
                    conversations[email].Show();
                    
                }

                conversations[email].handleReceivedData(splitted[1]);
            }
            
            clientSocket.BeginReceive(globalBuffer, 0, globalBuffer.Length, SocketFlags.None, new AsyncCallback(ReceiveData), clientSocket);
        }

        public void ListDoubleClicked(Object sender, EventArgs e)
        {
            string selected = userListView.SelectedItems[0].Text;
            
            if (!conversations.ContainsKey(selected))
            {
                conversations[selected] = new SingleChat(CurrentUser, selected);
                conversations[selected].assignClient(clientSocket);
                conversations[selected].Show();
            }
            else
            {
                conversations[selected].BringToFront();
            }
        }

        // Prints the list of online users.
        private void writeToList(string unparsedList)
        {
            // Populates the list.
            string[] users = unparsedList.Split('|');

            if (userListView.InvokeRequired)
            {
                userListView.Invoke(new MethodInvoker(delegate
                {
                    // Clears the list first.
                    userListView.Items.Clear();

                    foreach (string user in users)
                    {
                        if (!String.Equals(user, CurrentUser))
                        {
                            userListView.Items.Add(user);
                        }
                    }
                }));

            }
        }

        private void KeyPressed_Enter(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                CurrentUser = clientBox.Text;
                connectUser(clientBox.Text);
            }
        }
        



        private void LoopConnect()
        {
            int attempts = 0;
            while (!clientSocket.Connected)
            {
                try
                {
                    attempts++;
                    clientSocket.Connect(IPAddress.Loopback, 4050);
                }
                catch (SocketException)
                {
                    //Console.Clear();
                    MetroMessageBox.Show(this, "Could not connect to the server!");
                }
            }
        }

    }
}
