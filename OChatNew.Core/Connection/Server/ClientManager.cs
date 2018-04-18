using OChatNew.Core.Connection.Communication;
using OChatNew.Core.Connection.Server.Communication;
using System;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Threading;

namespace OChatNew.Core.Connection.Server
{
    public class ClientManager
    {
        public TcpClient TcpClient
        {
            get;
            set;
        }

        public string UserName
        {
            get;
            set;
        }

        public Server HostServer
        {
            get;
            set;
        }

        public void ReadClientStream()
        {
            var binReader = new BinaryReader(TcpClient.GetStream());
            while (true)
            {
                try
                {
                    var receivedMessage = binReader.ReadString();

                    if (receivedMessage != String.Empty)
                    {
                        EvaluateClientToServerMessage(new Message
                        {
                            Username = receivedMessage.Split(':')[1],
                            RawMessageContent = receivedMessage,
                            TimeStamp = DateTime.Now,
                        });
                    }
                }
                catch
                { }
            }
        }

        public void EvaluateClientToServerMessage(Message message)
        {
            switch (message.Type)
            {
                case MessageType.USERWENTOFFLINE:
                    SendMessageToClients(message.RawMessageContent);
                    TerminateObjectAndThread();
                    return;

                case MessageType.USERWENTONLINE: //first message that will be sent
                    SendMessageToClient("ONLINEUSERS:" + string.Join("|", HostServer.Clients.Select(x => x.UserName).ToArray()));
                    UserName = message.Username;
                    break;
            }

            SendMessageToClients(message.RawMessageContent);
        }

        /// <summary>
        /// Sends a message, sent from this client to all the other client managers
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
            HostServer.Clients.Remove(this);
            TcpClient.Close();
            TcpClient.Dispose();
            Thread.CurrentThread.Abort();
        }
    }
}