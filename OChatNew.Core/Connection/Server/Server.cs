using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace OChatNew.Core.Connection.Server
{
    public class Server
    {
        public List<ClientManager> Clients
        {
            get;
            set;
        }

        public int Port
        {
            get;
            set;
        }

        private bool _serverAcceptsConnections = true;

        public Server(int port)
        {
            Port = port;
            Clients = new List<ClientManager>();
        }

        /// <summary>
        /// Creates a tcp listener to accept connections from <see cref="Tcpclient"/>
        /// </summary>
        public void OpenServerForConnection()
        {
            var tcpListener = new TcpListener(IPAddress.Any, Port);
            tcpListener.Start();
            System.Console.WriteLine("Listening to new connections...");

            while (_serverAcceptsConnections)
            {
                var tcpClient = tcpListener.AcceptTcpClient();

                var clientIPv4 = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString();
                Console.WriteLine($"Client: {clientIPv4} has connected!");

                var client = new ClientManager
                {
                    TcpClient = tcpClient,
                    HostServer = this,
                };

                Clients.Add(client);
                new Thread(client.ReadClientStream).Start();
            }
        }
    }
}