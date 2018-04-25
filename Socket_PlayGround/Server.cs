using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace Socket_PlayGround
{
    class Server
    {
        public void OpenServerForConnection(int port)
        {
            var listener = new TcpListener(port);
            listener.Start();
            var client = listener.AcceptTcpClient();

            new Thread(() => ReadFromStream(client)).Start();
        }

        public void ReadFromStream(TcpClient client)
        {
            while (true)
            {
                var reader = new BinaryReader(client.GetStream());
                var receivedMessage = reader.ReadString(); //does he instantly read it??
                Console.WriteLine("Server has Received: " + receivedMessage);
            }
        }

        public void WriteToStream(TcpClient client)
        {

        }
    }
}
