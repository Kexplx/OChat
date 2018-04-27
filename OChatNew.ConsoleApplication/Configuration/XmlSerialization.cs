using System;
using System.IO;
using System.Xml.Serialization;

namespace OChatNew.ConsoleApplication.Configuration
{
    public class XmlSerialization
    {
        private string _file = "config.xml";
        private XmlSerializer _serializer;

        public XmlSerialization()
        {
            _serializer = new XmlSerializer(typeof(OChatConfiguration));
        }

        public void SerializeConfig(OChatConfiguration config)
        {
            _serializer.Serialize(File.Open(_file, FileMode.OpenOrCreate), config);
        }

        public Tuple<OChatConfiguration, string> DeserializeConfig()
        {
            OChatConfiguration config;
            using (var stream = File.OpenRead(_file))
            {
                config = (OChatConfiguration)_serializer.Deserialize(stream);
            }

            using (var stream = File.OpenRead(_file))
            {
                var xml = new StreamReader(stream).ReadToEnd();

                return Tuple.Create(config, xml);
            }
        }
    }
}
