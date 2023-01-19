using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Net;

namespace ChatMessageApp
{
    public class ChatServer : ChatHelperClass
    {
        public Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        //connected Clients
        public List<ClientSocket> clientSockets = new List<ClientSocket>();

        public static ChatServer CreateInstance(int port, TextBox chatTextbox) 
        {
            ChatServer tcp = null;
            if(port > 0 && port < 65535 && chatTextbox != null)
            {
                tcp = new ChatServer();
                tcp.port = port;
                tcp.chatTextbox = chatTextbox;
            }
            return tcp;
        }

        public void SetupServer()
        {
            chatTextbox.Text += "Server being setup ...\n";

            // Bind Socket to listen on what port for incoming messages
            serverSocket.Bind(new IPEndPoint(IPAddress.Any, port));
            serverSocket.Listen(0);

            // BeginAccept creates thread for connecting to
            // AacceptCallback for when connection happens
            serverSocket.BeginAccept(AcceptCallback, this);
            chatTextbox.Text += "Server is Setup\n";

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
            // callback function for when client joins server
            Socket joiningSocket;
            try
            {
                joiningSocket = serverSocket.EndAccept(AR);
            }
            catch (Exception)
            {
                // Will catch all issue
                return;
            }
            ClientSocket newClientSocket = new ClientSocket();
            newClientSocket.socket = joiningSocket;

            clientSockets.Add(newClientSocket);
            joiningSocket.BeginReceive(newClientSocket.buffer, 0, ClientSocket.BUFFER_SIZE, SocketFlags.None, ReceiveCallback, newClientSocket);
            AddToChat("Client Connected");

            // Allows more than one client to join
            serverSocket.BeginAccept(AcceptCallback, this);
        }

        public void ReceiveCallback(IAsyncResult AR)
        {
            // Function called when data comes in from Client
            ClientSocket currentClientSocket = (ClientSocket)AR.AsyncState;

            int received;
            try
            {
                received = currentClientSocket.socket.EndReceive(AR);
            }
            catch(SocketException ex)
            {
                AddToChat("Error -> " + ex.Message);
                currentClientSocket.socket.Close();
                clientSockets.Remove(currentClientSocket);
                AddToChat("disconnecting client");
                return;
            }
            byte[] receivedBuffer = new byte[received];
            Array.Copy(currentClientSocket.buffer, receivedBuffer, received);

            string text = Encoding.ASCII.GetString(receivedBuffer);
            AddToChat(text);

            if(text.ToLower() == "!commands")
            {
                byte[] data = Encoding.ASCII.GetBytes("Commands in program");
                // list of all commands

                currentClientSocket.socket.Send(data);
            }
            else if(text.ToLower() == "!exit")
            {
                currentClientSocket.socket.Shutdown(SocketShutdown.Both);
                currentClientSocket.socket.Close();
                clientSockets.Remove(currentClientSocket);
                AddToChat("Client Disconnected");
                return;
            }
            else
            {
                // for any message that are not commands
                SendToAll(text, currentClientSocket);
            }
            currentClientSocket.socket.BeginReceive(currentClientSocket.buffer, 0, ClientSocket.BUFFER_SIZE, SocketFlags.None, ReceiveCallback, currentClientSocket);

        }

        public void SendToAll(string str, ClientSocket from)
        {
            // send message to all users
            foreach(ClientSocket clientSocket in clientSockets)
            {
                if(from == null || !from.socket.Equals(clientSocket))
                {
                    // ?? change to format which can be sent
                    byte[] data = Encoding.ASCII.GetBytes(str);
                    clientSocket.socket.Send(data);
                }
            }
        }
    }
}
