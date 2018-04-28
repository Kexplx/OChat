using OChatNew.ConsoleApplication.Configuration;
using OChatNew.Core.Connection.Server;
using OChatNew.Core.Utilities.Logging;

namespace OChatNew.ConsoleApplication
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var logger = new OLogger("OChat_Server.log", true);
            var configTuple = new XmlSerialization().DeserializeConfig();

            logger.Info("OChat Server application started", typeof(Program));
            logger.Info("Using this config:", typeof(Program));
            logger.Info("\n" + configTuple.Item2, typeof(Program));

            new Host(configTuple.Item1.Port, logger).OpenServerForConnection();
        }
    }
}