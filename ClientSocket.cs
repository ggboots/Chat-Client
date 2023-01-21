using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Windows.Forms;

namespace ChatMessageApp
{
    // Client Data
    public class ClientSocket
    {
        public string username;
        public bool isModerator;

        public Socket socket;
        public const int BUFFER_SIZE = 2048;
        public byte[] buffer = new byte[BUFFER_SIZE];

        public bool hasSetUsername = false;
        public bool toBeKicked = false;
        public bool disconnecting = false;

    }
}
