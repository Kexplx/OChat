using OChat.Core.Communication.ServerSide;

namespace OChat.Server_Host
{
    internal class Program
    {
        private static readonly int _port = int.Parse(System.Configuration.ConfigurationManager.AppSettings["port"]);

        private static void Main()
        {
            new Server().StartListeningForIncomingTcpRequests(_port);
        }
    }
}
