using OChat.Core.Communication.ClientSide;
using System;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        private static IList<string> _sentences = new List<string>
            {
                "Guten Tag, liebe Freunde!",
                "Heute ist ein wundervoller Tag!",
                "Donald Trump ist der Präsident der USA",
                "Dieses Programm wurde mit C# in Visual Studio 2017 entwickelt",
                "Langsam wird es Zeit für mich zu gehen",
                "Auf Wiedersehn!"
            };
        static void Main(string[] args)
        {
            var usernames = new List<string>
            {
                "Matthes",
                "Tobias",
                "Joris",
                "Alex",
                "Julia",
                "Hildegard",
                "Tscharly",
                "Martin",
                "Paul",
                "Jonas"
            };

            for (int i = 0; i < usernames.Count; i++)
            {
                Thread.Sleep(new Random().Next(2000, 5000));
                ConnectNewClient(usernames[i]);
            }
        }

        static void ConnectNewClient(string username)
        {
            new Thread(() =>
            {
                while (true)
                {
                    var clientMiddleman = new ClientServerMiddleman();
                    clientMiddleman.ConnectToServer(8931, "localhost");
                    clientMiddleman.ConnectToChat(username);

                    for (int j = 0; j < _sentences.Count; j++)
                    {
                        Thread.Sleep(new Random().Next(2000, 5000));
                        clientMiddleman.SendNewChatMessage(new OChat.Core.ClientSide.Models.ChatMessage { Username = username, Content = _sentences[j] });
                    }

                    clientMiddleman.DisconnectFromChatAndServer(username);

                    Thread.Sleep(new Random().Next(2000, 5000));
                }
            }).Start();
        }
    }
}
