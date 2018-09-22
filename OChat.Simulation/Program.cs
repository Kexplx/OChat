using OChat.Core.Communication.ClientSide;
using System.Collections.Generic;
using System.Threading;

namespace OChat.Simulation
{
    class Program
    {
        static void Main(string[] args)
        {
            var usernames = new List<string>
            {
                "Oscar",
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
            var sentences = new List<string>
            {
                "Guten Tag, mein Name ist ",
                "Heute ist ein wundervoller Tag!",
                "Donald Trump ist der Präsident der USA",
                "Dieses Programm wurde mit C# in Visual Studio 2017 entwickelt",
                "Langsam wird es Zeit für mich zu gehen",
                "Auf Wiedersehn!"
            };

            var clientMiddleman = new ClientServerMiddleman();

            for (int i = 0; i < usernames.Count; i++)
            {
                new Thread(() =>
               {
                   while (true)
                   {
                       clientMiddleman.ConnectToServer(8931, "localhost");
                       clientMiddleman.ConnectToChat(usernames[i]);

                       for (int j = 0; j < sentences.Count; j++)
                       {
                           clientMiddleman.SendNewChatMessage(new Core.ClientSide.Models.ChatMessage { Username = usernames[i], Content = sentences[j] });
                       }

                       clientMiddleman.DisconnectFromChatAndServer(usernames[i]);
                   }
               }).Start();
            }
        }
    }
}
