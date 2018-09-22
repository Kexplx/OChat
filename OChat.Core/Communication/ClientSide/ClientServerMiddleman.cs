using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using OChat.Core.ClientSide.Models;

namespace OChat.Core.Communication.ClientSide
{
    public class ClientServerMiddleman
    {
        private TcpClient _tcpClient;
        private BinaryReader _reader;
        private BinaryWriter _writer;
        private int _lastConnectedPort;
        private string _lastConnectedIpv4Adress = string.Empty;

        public delegate void ChatMessageReceiverDelegate(ChatMessage message);
        public delegate void UserConnectedToChatNotificationReceiverDelegate(string username);
        public delegate void UserDisconnectedFromChatNotificationReceiverDelegate(string username);

        public bool ConnectToServer(int port, string hostname)
        {
            if (_tcpClient == null)
            {
                try
                {
                    _tcpClient = new TcpClient(hostname, port);
                    _reader = new BinaryReader(_tcpClient.GetStream());
                    _writer = new BinaryWriter(_tcpClient.GetStream());

                    _lastConnectedIpv4Adress = hostname;
                    _lastConnectedPort = port;

                    return true;
                }
                catch
                {
                    return false;
                }
            }

            return _tcpClient.Connected && port == _lastConnectedPort && hostname == _lastConnectedIpv4Adress;
        }

        public void DisconnectFromServer()
        {
            _tcpClient.Close();
        }

        public void ConnectToChat(string username)
        {
            _writer.Write(MessagePrefixes.CLIENT_USER_CONNECTED_TO_CHAT + username);
        }

        public bool CheckIfUsernameAvailable(string desiredUsername)
        {
            try
            {
                _writer.Write(MessagePrefixes.CLIENT_IS_USERNAME_AVAILABLE + desiredUsername);
                var serverResponse = _reader.ReadString();

                return Convert.ToBoolean(serverResponse.Substring(MessagePrefixes.PREFIX_LENGTH));
            }
            catch
            {
                return false;
            }
        }

        public void GetNewMessagesAndCallbackOnSpecifiedDelegates(ChatMessageReceiverDelegate d, UserConnectedToChatNotificationReceiverDelegate d1, UserDisconnectedFromChatNotificationReceiverDelegate d2)
        {
            try
            {
                var serverResponse = _reader.ReadString();

                new Thread(() => { GetNewMessagesAndCallbackOnSpecifiedDelegates(d, d1, d2); }).Start();

                switch (serverResponse.Substring(0, MessagePrefixes.PREFIX_LENGTH))
                {
                    case MessagePrefixes.Server_USER_CONNECTED_TO_CHAT:
                        var connectedUser = serverResponse.Substring(MessagePrefixes.PREFIX_LENGTH).Trim();
                        d1(connectedUser);
                        break;

                    case MessagePrefixes.SERVER_USER_DISCONNECTED_FROM_CHAT:
                        var disconnectedUser = serverResponse.Substring(MessagePrefixes.PREFIX_LENGTH).Trim();
                        d2(disconnectedUser);
                        break;

                    case MessagePrefixes.SERVER_NEW_CHAT_MESSAGE:
                        var chatMessage = new ChatMessage
                        {
                            Username = serverResponse
                                .Substring(MessagePrefixes.PREFIX_LENGTH, MessagePrefixes.USERNAME_LENGTH).Trim(),
                            Content = serverResponse.Substring(
                                MessagePrefixes.PREFIX_LENGTH + MessagePrefixes.USERNAME_LENGTH),
                            Timestamp = DateTime.Now
                        };
                        d(chatMessage);
                        break;
                }
            }
            catch
            {
                // ignored
            }
        }

        public IList<string> GetCurrentUsers()
        {
            _writer.Write(MessagePrefixes.CLIENT_GET_CURRENT_USERS);

            var message = _reader.ReadString();
            var usernames = new List<string>();

            for (var i = MessagePrefixes.PREFIX_LENGTH; i < message.Length; i += MessagePrefixes.USERNAME_LENGTH)
            {
                usernames.Add(message.Substring(i, MessagePrefixes.USERNAME_LENGTH).Trim());
            }

            return usernames;
        }

        public void SendNewChatMessage(ChatMessage chatMessage)
        {
            _writer.Write(MessagePrefixes.CLIENT_NEW_CHAT_MESSAGE + chatMessage.Username.PadRight(10) + chatMessage.Content);
        }

        public void DisconnectFromChatAndServer(string username)
        {
            _writer.Write(MessagePrefixes.CLIENT_USER_DISCONNECTED_FROM_CHAT + username);
        }
    }
}
