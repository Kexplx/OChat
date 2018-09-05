using OChatNew.Core.Connection.Models;
using OChatNew.Core.Utilities.Logging;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace OChatNew.Core.Connection
{
    public class ClientManager
    {
        private OLogger _logger;

        public TcpClient TcpClient { get; set; }

        public string UserName { get; set; }

        public Server HostServer { get; set; }

        public ClientManager(OLogger logger)
        {
            _logger = logger;
        }

        public void ReadClientStream()
        {
            var reader = new BinaryReader(TcpClient.GetStream());
            while (true)
            {
                try
                {
                    var receivedMessage = reader.ReadString();
                    EvaluateClientToServerMessage(new Message
                    {
                        Username = receivedMessage.Split(':')[1],
                        RawMessageContent = receivedMessage,
                        TimeStamp = DateTime.Now,
                    });
                }
                catch
                { }
            }
        }

        /// <summary>
        /// Evaluates the sent string from the client and acts accordingly
        /// </summary>
        /// <param name="message"></param>
        public void EvaluateClientToServerMessage(Message message)
        {
            switch (message.Type)
            {
                case MessageType.USERWENTOFFLINE:
                    SendMessageToClients(message.RawMessageContent);
                    TerminateObjectAndThread();
                    return;

                case MessageType.USERWENTONLINE:
                    SendMessageToClient("ONLINEUSERS:" + string.Join("|", HostServer.Clients.Select(x => x.UserName).ToArray()));
                    UserName = message.Username;
                    break;

                case MessageType.CHECKNAME:
                    var isUserNameAvailable = !(HostServer.Clients.Where(x => x.UserName == message.RawMessageContent.Split(':')[1]).Count() == 1);
                    SendMessageToClient("CHECKNAME:" + isUserNameAvailable.ToString());
                    return;
            }

            SendMessageToClients(message.RawMessageContent);
        }

        /// <summary>
        /// Sends a message, sent from this client to the others
        /// </summary>
        /// <param name="message"></param>
        public void SendMessageToClients(string message)
        {
            foreach (var client in HostServer.Clients)
            {
                if (client == this)
                {
                    continue;
                }
                client.SendMessageToClient(message);
            }
        }

        /// <summary>
        /// Sends a message, coming from another ClientManager or the Server itself to the client
        /// </summary>
        /// <param name="message"></param>
        public void SendMessageToClient(string message)
        {
            var binWriter = new BinaryWriter(TcpClient.GetStream());
            binWriter.Write(message);
            binWriter.Flush();
        }

        public void TerminateObjectAndThread()
        {
            _logger.Info(("TCP client: " + ((IPEndPoint)TcpClient.Client.RemoteEndPoint).Address.ToString()) + " has disconnected", GetType());

            HostServer.Clients.Remove(this);
            TcpClient.Close();
            TcpClient.Dispose();
            Thread.CurrentThread.Abort();
        }
    }
}