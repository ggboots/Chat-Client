using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Windows.Forms;

namespace ChatMessageApp
{
    public class ChatServer : ChatHelperClass
    {
        public Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        //connected Clients
        public List<ClientSocket> clientSockets = new List<ClientSocket>();

        public static ChatServer CreateInstance(int port, TextBox chatTextBox) 
        {
            ChatServer tcp = null;
            if(port > 0 && port < 65535 && chatTextBox != null)
            {
                tcp = new ChatServer();
                tcp.port = port;
                tcp.chatTextBox = chatTextBox;
            }
            return tcp;
        }

        public void SetupServer()
        {

        }
        public void CloseAllSockets()
        {
            foreach(ClientSocket clientSocket in clientSockets) 
            { 
                clientSocket.socket.Shutdown(SocketShutdown.Both);
                clientSocket.socket.Close();
            }
            clientSockets.Clear();
            serverSocket.Close();
        }

        // IAsyncResult is status of async operations
        public void AcceptCallback(IAsyncResult AR)
        {

        }

        public void ReceiveCallback(IAsyncResult AR)
        {

        }

        public void SendToAll(string str, ClientSocket from)
        {
            foreach(ClientSocket clientSocket in clientSockets)
            {
                if(from == null || from.socket.Equals(clientSocket))
                {
                    // ?? change to format which can be sent
                    byte[] data = Encoding.ASCII.GetBytes(str);
                    clientSocket.socket.Send(data);
                }
            }
        }
    }
}
