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
            using (var stream = File.Open(_file, FileMode.OpenOrCreate))
            {
                _serializer.Serialize(stream, config);
            }
        }

        public Tuple<OChatConfiguration, string> DeserializeConfig()
        {
            OChatConfiguration config;

            if (!File.Exists(_file))
            {
                SerializeConfig(new OChatConfiguration { Port = 8080 });
            }

            using (var stream = File.Open(_file, FileMode.OpenOrCreate))
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