using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;

namespace ChatMessageApp
{
    public class ClientSocket
    {
        // client data
        public Socket socket;
        public const int BUFFER_SIZE = 2048;
        public byte[] buffer = new byte[BUFFER_SIZE];

    }
}
