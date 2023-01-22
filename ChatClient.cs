using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Linq.Expressions;

namespace ChatMessageApp
{
    public class ChatClient : ChatHelperClass
    {
        public Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public ClientSocket clientSocket = new ClientSocket();

        public int serverPort;
        public string serverIP;

        public static ChatClient CreateInstance(int port, int serverPort, string serverIP, TextBox chatTextbox)
        {
            ChatClient tcp = null;
            if(port > 0 && port < 65535 && serverPort > 0 && serverPort < 65535 && serverIP.Length > 0 && chatTextbox != null)
            {
                tcp = new ChatClient();
                tcp.port = port;
                tcp.serverPort = serverPort;
                tcp.serverIP = serverIP;
                tcp.chatTextbox = chatTextbox;
                tcp.clientSocket.socket = tcp.socket;
            }
            return tcp;
        }
        public void ConnectToServer()
        {
            // connects client to server
            int attempts = 0;
            while (!socket.Connected)
            {
                try
                {
                    attempts++;
                    SetChat("Connection attempt " + attempts);
                    socket.Connect(serverIP, serverPort);
                }
                catch (Exception ex)
                {
                    chatTextbox.Text += "Error: " + ex.Message + "\n";
                }
            }
            SetChat("");
            AddToChat("Connected " + System.Environment.NewLine + " ||||||||||| WELCOME TO CHATBOX ||||||||||| \n");
            AddToChat(" +++ Type !username to choose name");
            AddToChat(" +++ Type !login if already made");
            clientSocket.socket.BeginReceive(clientSocket.buffer, 0, ClientSocket.BUFFER_SIZE, SocketFlags.None, ReceiveCallBack, clientSocket);
            
        }

        public void ReceiveCallBack(IAsyncResult AR)
        {
            ClientSocket currentClientSocket = (ClientSocket)AR.AsyncState;

            int received;
            try
            {
                received = currentClientSocket.socket.EndReceive(AR);
                Console.WriteLine(received);
            }
            catch(SocketException ex)
            {
                AddToChat("Error: " + ex.Message);
                AddToChat("Disconnecting ... ");
                currentClientSocket.socket.Close();
                return;
            }

            byte[] recBuf = new byte[received];
            Array.Copy(currentClientSocket.buffer, recBuf, received);

            string text = Encoding.ASCII.GetString(recBuf);
            AddToChat(text);

            clientSocket.socket.BeginReceive(currentClientSocket.buffer, 0, ClientSocket.BUFFER_SIZE, SocketFlags.None, ReceiveCallBack, currentClientSocket);

        }

        public void SendString(string text)
        {
            // send input text to server to be broadcasted
            byte[] buffer = Encoding.ASCII.GetBytes(text);
            socket.Send(buffer, 0, buffer.Length, SocketFlags.None);
        }

        public void Close()
        {
            // close socket from server
            socket.Close();
        }
    }
}
