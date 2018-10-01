using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using OChat.Core.Logging;

namespace OChat.Core.Communication.ServerSide
{
    public class Server
    {
        private readonly object _monitor = new object();
        private readonly OLogger _logger = new OLogger("OChat.log", true);
        private readonly IList<ClientHandler> _clientHandlers = new List<ClientHandler>();

        public void StartListeningForIncomingTcpRequests(int port)
        {

            var tcpListener = new TcpListener(IPAddress.Any, port);
            tcpListener.Start();

            _logger.Info("Host of OChat Started. Listening for connections on port " + port + "...", typeof(Server));

            while (true)
            {
                var client = tcpListener.AcceptTcpClient();
                _logger.Info("Client connected with IPv4 Adress: " + ((IPEndPoint)client.Client.RemoteEndPoint).Address, typeof(Server));

                var clientManager = new ClientHandler(client, this);

                new Thread(clientManager.ReadAndEvaluateClientStream).Start();
            }
        }

        public void SendMessageToAllClients(string message, ClientHandler exludetClientManager = null)
        {
            lock (_monitor)
            {
                foreach (var clientManager in _clientHandlers)
                {
                    if (clientManager != exludetClientManager)
                    {
                        clientManager.SendMessageToOwnClient(message);
                    }
                }
            }
        }

        public void AddClientHandlerToList(ClientHandler clientManager)
        {
            lock (_monitor)
            {
                _clientHandlers.Add(clientManager);
            }
        }

        public void RemoveClientHandlerFromList(ClientHandler clientManager)
        {
            lock (_monitor)
            {
                _clientHandlers.Remove(clientManager);

                _logger.Info("Client disconnected with IPv4 Adress: " + ((IPEndPoint)clientManager.TcpClient.Client.RemoteEndPoint).Address, typeof(Server));

            }
        }

        public List<string> GetCurrentUsernames()
        {
            lock (_monitor)
            {
                return _clientHandlers.Select(x => x.Username).ToList();
            }
        }

        public bool CheckIfUsernameAvailable(string username)
        {
            lock (_monitor)
            {
                foreach (var item in _clientHandlers)
                {
                    if (item.Username == username)
                    {
                        return false;
                    }
                }

                return true;
            }
        }
    }
}
