using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.Text.RegularExpressions;
using System.Data.SQLite;

namespace ChatMessageApp
{
    public class ChatServer : ChatHelperClass
    {
        public Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public List<ClientSocket> clientSockets = new List<ClientSocket>();

        // create DB
        public string connectDB = "Data Source=ChatMessageApp.db";

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
            chatTextbox.Text += "Server being setup ..." + Environment.NewLine;

            // Bind Socket to listen on what port for incoming messages
            serverSocket.Bind(new IPEndPoint(IPAddress.Any, port));
            serverSocket.Listen(0);

            serverSocket.BeginAccept(AcceptCallback, this);
            chatTextbox.Text += "Server Setup Complete" + Environment.NewLine;


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
            catch (ObjectDisposedException)
            {
                return;
            }
            ClientSocket newClientSocket = new ClientSocket();
            newClientSocket.socket = joiningSocket;

            clientSockets.Add(newClientSocket);
            joiningSocket.BeginReceive(newClientSocket.buffer, 0, ClientSocket.BUFFER_SIZE, SocketFlags.None, ReceiveCallback, newClientSocket);
            AddToChat("Client Connected");
            // start next thread
            serverSocket.BeginAccept(AcceptCallback, this);
        }

        public void ReceiveCallback(IAsyncResult AR)
        {
            // Function called when data comes in from Client
            ClientSocket currentClientSocket = (ClientSocket)AR.AsyncState;
            string newUsername = currentClientSocket.username;

            int received;
            try
            {
                received = currentClientSocket.socket.EndReceive(AR);
            }
            catch(SocketException ex)
            {
                AddToChat("Error -> " + ex.Message);
                AddToChat("Error occurred, disconnecting client");
                currentClientSocket.socket.Close();
                clientSockets.Remove(currentClientSocket);
                return;
            }
            byte[] receivedBuffer = new byte[received];
            Array.Copy(currentClientSocket.buffer, receivedBuffer, received);

            string text = Encoding.ASCII.GetString(receivedBuffer);
            // AddToChat(text);

            //Kick Command
            if(currentClientSocket.toBeKicked == true)
            {
                AddToChat(newUsername + " has Disconnected");
                byte[] data = Encoding.ASCII.GetBytes("you have been kicked");
                currentClientSocket.socket.Send(data);
                currentClientSocket.socket.Shutdown(SocketShutdown.Both);
                currentClientSocket.socket.Close();
                clientSockets.Remove(currentClientSocket);
            }

            //
            // User commands
            if (text.ToLower() == "!commands")
            {
                string nl = System.Environment.NewLine; //Prevent Repeating self
                byte[] data = Encoding.ASCII.GetBytes("------ USER COMMANDS --------" + nl + "!username +> Allows user to choose Username when first Joined" + nl + "!user => Rename user's name" + nl + "!about => infomation about the Server" + nl + "!who => Check whos in the server" + nl + "!whisper => directly communicate to a other user only" + nl + "!exit => quit program" + nl + "CUSTOM COMMANDS" + nl + "!shout => message to upper cases to shout at other users directly " + nl +
                "------ FOR MODERATORS -------" + nl + "!mod => Designate user as mod" + nl + "!mods => check number of mods in server" + nl + "!kick => ONLY for MODS, kick cleints from servers");
                currentClientSocket.socket.Send(data);
                AddToChat("Commands sent to " + currentClientSocket.username);
            }
            // username command
            else if (text.Contains("!username") == true)
            {

                if (currentClientSocket.hasSetUsername == false)
                {
                    if (text.Length == 9)
                    {
                        byte[] data = Encoding.ASCII.GetBytes("Enter Username after command");
                        currentClientSocket.socket.Send(data);
                    }
                    else if (text.Length >= 10)
                    {
                        string[] commandNameSeparation = text.Split(" ");
                        string clientUsername = commandNameSeparation[1];

                        bool found = false;

                        foreach (ClientSocket clientsocket in clientSockets)
                        {
                            if (clientUsername == clientsocket.username)
                            {
                                found = true;
                                currentClientSocket.disconnecting = true;
                                currentClientSocket.socket.Shutdown(SocketShutdown.Both);
                                currentClientSocket.socket.Close();
                                clientSockets.Remove(currentClientSocket);
                                AddToChat("Username Already in Use");
                                break;
                            }
                        }
                        if (!found)
                        {
                            currentClientSocket.username = clientUsername;
                            currentClientSocket.hasSetUsername = true;
                            byte[] data = Encoding.ASCII.GetBytes("Username Good: " + currentClientSocket.username);
                            currentClientSocket.socket.Send(data);
                            SendToAll("Welcome " + currentClientSocket.username, currentClientSocket);
                        }
                    }
                }
                else if (currentClientSocket.hasSetUsername == true)
                {
                    byte[] data = Encoding.ASCII.GetBytes("use command [!user] to change Username");
                    currentClientSocket.socket.Send(data);
                }
            }

            // Login Command
            else if (text.Contains("!login") == true)
            {
                if (text.Length == 6)
                {
                    byte[] data = Encoding.ASCII.GetBytes("Enter as -> !login [username] [password]");
                    currentClientSocket.socket.Send(data);
                }
            }

            // user command
            else if (text.Contains("!user") == true)
            {
                if (text.Length == 5)
                {
                    byte[] data = Encoding.ASCII.GetBytes("Please enter username you would like to change to");
                    currentClientSocket.socket.Send(data);

                }
                else if (text.Length >= 6)
                {

                    //string commandNameSeparation = Regex.Replace(text.Split()[0], "@[^0-9a-zA-Z]+", ""); 
                    string[] commandNameSeparation = text.Split(" ");
                    string clientUsername = commandNameSeparation[1];

                    bool found = false;
                    foreach (ClientSocket clientsocket in clientSockets)
                    {
                        if (clientUsername == clientsocket.username)
                        {
                            byte[] data = Encoding.ASCII.GetBytes("Username Already in Use, try again");
                            currentClientSocket.socket.Send(data);
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        string oldClientUsername = currentClientSocket.username;
                        currentClientSocket.username = clientUsername;
                        SendToAll("Name Change " + oldClientUsername + " -> " + currentClientSocket.username, currentClientSocket);
                    }
                }

            }
            // who command
            else if (text.ToLower() == "!who")
            {
                byte[] dataHeader = Encoding.ASCII.GetBytes("Clients in Server: ");
                currentClientSocket.socket.Send(dataHeader);
                foreach (ClientSocket clientSocket in clientSockets)
                {
                    string currentClient = clientSocket.username;
                    byte[] data = Encoding.ASCII.GetBytes(currentClient + Environment.NewLine);
                    currentClientSocket.socket.Send(data);
                }
            }
            // about command
            else if (text.ToLower() == "!about")
            {
                byte[] data = Encoding.ASCII.GetBytes("This is ChatBox, Made by George");
                currentClientSocket.socket.Send(data);
            }
            // whisper command
            else if (text.Contains("!whisper") == true)
            {
                if (text.Length == 8)
                {
                    byte[] data = Encoding.ASCII.GetBytes("Enter Username after command");
                    currentClientSocket.socket.Send(data);
                }
                else if (text.Length >= 10)
                {
                    string[] commandSeparation = text.Split(" ");
                    string whisperToUser = commandSeparation[1];

                    bool found = false;
                    foreach (ClientSocket clientsocket in clientSockets)
                    {
                        if (whisperToUser == clientsocket.username)
                        {
                            found = true;
                            List<string> whisperMessage = new List<string>();
                            string whisperMessageTemplate = currentClientSocket.username + ": ";
                            for (int i = 2; i < commandSeparation.Length; i++)
                            {

                                whisperMessage.Add(commandSeparation[i]);
                                whisperMessageTemplate += commandSeparation[i] + " ";
                            }
                            string[] whisperMessageToArray = whisperMessage.ToArray();
                            byte[] data = Encoding.ASCII.GetBytes(whisperMessageTemplate);
                            clientsocket.socket.Send(data);

                        }
                    }
                    if (!found)
                    {
                        byte[] data = Encoding.ASCII.GetBytes("User Not found, try again");
                        currentClientSocket.socket.Send(data);
                    }
                }
            }
            // shout command
            else if (text.Contains("!shout") == true)
            {
                if (text.Length == 6)
                {
                    byte[] data = Encoding.ASCII.GetBytes("Enter Username after command");
                    currentClientSocket.socket.Send(data);
                }
                else if (text.Length >= 7)
                {
                    string[] commandSeparation = text.Split(" ");
                    string shoutToUser = commandSeparation[1];

                    bool found = false;
                    foreach (ClientSocket clientsocket in clientSockets)
                    {
                        if (shoutToUser == clientsocket.username)
                        {
                            found = true;
                            List<string> shoutMessage = new List<string>();
                            string shoutMessageTemplate = currentClientSocket.username + ": ";
                            for (int i = 2; i < commandSeparation.Length; i++)
                            {

                                shoutMessage.Add(commandSeparation[i]);
                                shoutMessageTemplate += commandSeparation[i].ToUpper() + " ";
                            }
                            string[] whisperMessageToArray = shoutMessage.ToArray();
                            byte[] data = Encoding.ASCII.GetBytes(shoutMessageTemplate);
                            clientsocket.socket.Send(data);

                        }
                    }
                    if (!found)
                    {
                        byte[] data = Encoding.ASCII.GetBytes("User Not found, try again");
                        currentClientSocket.socket.Send(data);
                    }
                }
            }
            // clear command
            else if (text.ToLower() == "!clear")
            {
                foreach (ClientSocket clientsocket in clientSockets)
                {
                    if (clientsocket == currentClientSocket)
                    {
                        SetChat("Clear");
                    }
                }
            }
            //
            // MODERATOR Commands Below
            // mods command
            else if (text.ToLower() == "!mods")
            {
                if (currentClientSocket.isModerator == true)
                {

                    foreach (ClientSocket clientsocket in clientSockets)
                    {
                        if (clientsocket.isModerator == true)
                        {
                            AddToChat(clientsocket.username);
                        }
                    }
                }
                else
                {
                    byte[] data = Encoding.ASCII.GetBytes("You do not have Mod priveledge");
                    currentClientSocket.socket.Send(data);
                }
            }
            // mod command
            else if (text.Contains("!mod") == true)
            {
                byte[] data = Encoding.ASCII.GetBytes("You do not have Server priveledges");
                currentClientSocket.socket.Send(data);
            }
            // kick command
            else if (text.Contains("!kick") == true)
            {
                if (text.Length == 5)
                {
                    byte[] data = Encoding.ASCII.GetBytes("Enter Username of user you would like to kick");
                    currentClientSocket.socket.Send(data);
                }
                else if (text.Length >= 6)
                {
                    if (currentClientSocket.isModerator == true)
                    {
                        string[] commandSeparation = text.Split(" ");
                        string userToKick = commandSeparation[1];

                        bool found = false;
                        foreach (ClientSocket clientsocket in clientSockets)
                        {
                            if (userToKick == clientsocket.username)
                            {
                                clientsocket.toBeKicked = true;
                                AddToChat(userToKick + "has been Kick");
                                return;
                            }
                        }
                        if (!found)
                        {
                            byte[] data = Encoding.ASCII.GetBytes("User Not found, try again");
                            currentClientSocket.socket.Send(data);
                        }
                    }
                    else if (currentClientSocket.isModerator == false)
                    {
                        byte[] data = Encoding.ASCII.GetBytes("You do not have Mod Priv");
                        currentClientSocket.socket.Send(data);
                    }
                }
            }


            else if (text.ToLower() == "!exit")
            {
                currentClientSocket.socket.Shutdown(SocketShutdown.Both);
                currentClientSocket.socket.Close();
                clientSockets.Remove(currentClientSocket);
                AddToChat("Client Disconnected");
                return;
            }


            // for any message that are not commands
            else
            {
                SendToAll(newUsername + ": " + text, currentClientSocket);
            }
            
            if (currentClientSocket.disconnecting == false)
            {
                currentClientSocket.socket.BeginReceive(currentClientSocket.buffer, 0, ClientSocket.BUFFER_SIZE, SocketFlags.None, ReceiveCallback, currentClientSocket);
            }
            else
            {
                return;
            }

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

            //
            //Server Commands + Moderator commands
            if (str.ToLower() == "!mods")
            {
                foreach (ClientSocket clientsocket in clientSockets)
                {
                    if (clientsocket.isModerator == true)
                    {
                        AddToChat(clientsocket.username);
                    }
                }
            }
            else if (str.Contains("!mod") == true)
            {
                string[] commandNameSeparation = str.Split(" ");
                string clientUsername = commandNameSeparation[1];

                foreach (ClientSocket clientsocket in clientSockets)
                {
                    if (clientUsername == clientsocket.username)
                    {

                        if (clientsocket.isModerator == false)
                        {
                            clientsocket.isModerator = true;
                            byte[] data = Encoding.ASCII.GetBytes(" +++ You are now a Mod");
                            clientsocket.socket.Send(data);
                        }
                        else if (clientsocket.isModerator == true)
                        {
                            clientsocket.isModerator = false;
                            byte[] data = Encoding.ASCII.GetBytes(" +++ You are not longer a Mod");
                            clientsocket.socket.Send(data);
                        }
                    }
                }
            }
            else if (str.Contains("!kick") == true)
            {
                if (str.Length == 5)
                {
                    AddToChat("Enter Username of user you would like to kick");

                }
                else if (str.Length >= 6)
                {
                    string[] commandSeparation = str.Split(" ");
                    string userToKick = commandSeparation[1];

                    bool found = false;
                    foreach (ClientSocket clientsocket in clientSockets)
                    {
                        if (userToKick == clientsocket.username)
                        {
                            clientsocket.disconnecting = true;
                            AddToChat(userToKick + " has been Kick");
                            return;

                        }
                    }
                    if (!found)
                    {
                        AddToChat("User Not found, try again");
                    }
                }

            }


        }
    }
}
