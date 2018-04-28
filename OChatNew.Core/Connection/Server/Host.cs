using OChatNew.Core.Utilities.Logging;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace OChatNew.Core.Connection.Server
{
    public class Host
    {
        private readonly int _port;
        private OLogger _logger;
        public List<ClientManager> Clients { get; set; }

        public Host(int port, OLogger logger)
        {
            _logger = logger;

            _port = port;
            Clients = new List<ClientManager>();
        }

        /// <summary>
        /// Creates a tcp listener to accept connections from <see cref="Tcpclient"/>
        /// </summary>
        public void OpenServerForConnection()
        {
            var tcpListener = new TcpListener(IPAddress.Any, _port);
            tcpListener.Start();
            _logger.Info("Started listening to new connections on port: " + _port, GetType());

            while (true)
            {
                var tcpClient = tcpListener.AcceptTcpClient();
                var clientIPv4Adress = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString();

                _logger.Info($"TCP client: {clientIPv4Adress} has connected", GetType());

                var client = new ClientManager(_logger)
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