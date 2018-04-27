using OChatNew.ConsoleApplication.Configuration;
using OChatNew.Core.Connection.Server;
using OChatNew.Core.Utilities.Logging;

namespace OChatNew.ConsoleApplication
{
    internal class Program
    {
        private static readonly OLogger _logger = new OLogger("OChat_Server.log", typeof(Program), true);

        private static void Main(string[] args)
        {
            var configTuple = new XmlSerialization().DeserializeConfig();

            _logger.Info("OChat Server application started");
            _logger.Info("Using this config:");
            _logger.Info("\n" +configTuple.Item2);

            new Server(configTuple.Item1.Port).OpenServerForConnection();
        }
    }
}