using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.SPOT;

namespace SDKGadgeteer
{
    class ExampleData
    {
        public DateTime LastDate;


        public static void XmlSerialize(
             string filename, ExampleData data)
        {
            var x = new XmlSerializer(typeof(ExampleData));
            using (var Writer = new StreamWriter(filename, false))
            {
                x.Serialize(Writer.BaseStream,data);
            }
        }

        public static ExampleData XmlDeSerialize(string filename)
        {
            var x = new XmlSerializer(typeof(ExampleData));
            using (FileStream stream =
                     new FileStream(filename, FileMode.Open))
            {
                return (ExampleData) x.Deserialize(stream);
                //XmlReader reader = XmlReader.Create(stream);
                //XmlTextReader reader = new  XmlTextReader(stream);
                //var x = new XmlSerializer(typeof(ExampleData));
                //return (ExampleData)x.Deserialize(reader);
            }
        }

    }
}
