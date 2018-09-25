using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace OChat.Core.Communication.ServerSide
{
    public class ClientManager
    {
        private readonly BinaryReader _reader;
        private readonly BinaryWriter _writer;
        private readonly Server _server;

        public TcpClient TcpClient { get; }

        public string Username
        {
            get;
            set;
        }

        public ClientManager(TcpClient tcpClient, Server server)
        {
            TcpClient = tcpClient ?? throw new System.ArgumentNullException(nameof(tcpClient));

            _server = server;
            _reader = new BinaryReader(TcpClient.GetStream());
            _writer = new BinaryWriter(TcpClient.GetStream());
        }

        public void ReadAndEvaluateClientStream()
        {
            var message = _reader.ReadString();

            //to constantly keep reading the client stream, we immediatly start a new Thread 
            var readingThread = new Thread(ReadAndEvaluateClientStream);
            readingThread.Start();
            string response;

            switch (message.Substring(0, MessagePrefixes.PREFIX_LENGTH))
            {
                case MessagePrefixes.CLIENT_IS_USERNAME_AVAILABLE:

                    var desiredUsername = message.Substring(MessagePrefixes.PREFIX_LENGTH);
                    response = MessagePrefixes.SERVER_IS_USERNAME_AVAILABLE;

                    if (_server.CheckIfUsernameAvailable(desiredUsername))
                    {
                        response += "TRUE";
                    }
                    else
                    {
                        response += "FALSE";
                    }

                    SendMessageToOwnClient(response);
                    break;

                case MessagePrefixes.CLIENT_USER_CONNECTED_TO_CHAT:

                    response = MessagePrefixes.Server_USER_CONNECTED_TO_CHAT + message.Substring(MessagePrefixes.PREFIX_LENGTH);
                    Username = message.Substring(MessagePrefixes.PREFIX_LENGTH);
                    _server.SendMessageToAllClientManagers(response, this);
                    _server.AddClientManagerToList(this);
                    break;

                case MessagePrefixes.CLIENT_GET_CURRENT_USERS:

                    response = MessagePrefixes.SERVER_CURRENT_USERS;
                    _server.GetCurrentUsernames().ForEach(x => response += x.PadRight(10));
                    SendMessageToOwnClient(response);
                    break;

                case MessagePrefixes.CLIENT_NEW_CHAT_MESSAGE:

                    response = MessagePrefixes.SERVER_NEW_CHAT_MESSAGE + message.Substring(MessagePrefixes.PREFIX_LENGTH);
                    _server.SendMessageToAllClientManagers(response, this);
                    break;

                case MessagePrefixes.CLIENT_USER_DISCONNECTED_FROM_CHAT:

                    readingThread.Abort();
                    _server.RemoveClientManagerFromList(this);

                    response = MessagePrefixes.SERVER_USER_DISCONNECTED_FROM_CHAT + message.Substring(MessagePrefixes.PREFIX_LENGTH);
                    _server.SendMessageToAllClientManagers(response);
                    break;
            }
        }

        public void SendMessageToOwnClient(string message)
        {
            _writer.Write(message);
        }
    }
}
