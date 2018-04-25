using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Threading;

namespace Socket_PlayGround
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<string>
            {
                "A",
                "B"
            };

            var x = list.Where(z => z == "C").ToList();

            new Thread(() => new Server().OpenServerForConnection(8080)).Start();

            var client = new TcpClient();

            client.Connect("localhost", 8080);

            var reader = new BinaryReader(client.GetStream());
            var writer = new BinaryWriter(client.GetStream());

            Thread.Sleep(10000);
            writer.Write("Hello World");
            writer.Flush();
        }
    }
}
