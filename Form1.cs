using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatMessageApp
{
    public partial class Form1 : Form
    {
        ChatServer server = null;
        ChatClient client = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void CreateServerButton_Click(object sender, EventArgs e)
        {
            if (CanHostOrJoin())
            {
                try
                {
                    int port = int.Parse(CreateServerTextbox.Text);
                    server = ChatServer.CreateInstance(port, ChatTextbox);
                    if(server == null)
                    {
                        throw new Exception("issue with port");
                    }
                    server.SetupServer();
                }
                catch(Exception ex)
                {
                    ChatTextbox.Text += "Error: " + ex.Message + "\n";
                }
            }
        }

        private void JoinServerButton_Click(object sender, EventArgs e)
        {
            if (CanHostOrJoin())
            {
                try
                {
                    int port = int.Parse(CreateServerTextbox.Text);
                    int serverPort = int.Parse(JoinServerTextbox.Text);
                    client = ChatClient.CreateInstance(port, serverPort, ServerIPTextbox.Text, ChatTextbox);
                    if(client == null)
                    {
                        throw new Exception("Port issue");
                    }
                    client.ConnectToServer();
                }
                catch(Exception ex)
                {
                    client = null;
                    ChatTextbox.Text += "Error: " + ex.Message + "\n";
                }
            }
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            if(client != null)
            {
                client.SendString(TypeTextbox.Text);
            }
            else if(server != null)
            {
                server.SendToAll(TypeTextbox.Text, null);
            }
        }
        public bool CanHostOrJoin()
        {
            if(server == null && client == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void UsernameButton_Click(object sender, EventArgs e)
        {

        }

        private void PasswordButton_Click(object sender, EventArgs e)
        {

        }
    }
}
