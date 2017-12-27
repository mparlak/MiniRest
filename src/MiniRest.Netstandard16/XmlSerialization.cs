using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MiniRest
{
    public class XmlSerialization
    {
        public string Serialize(object data)
        {
            string output;
            using (StringWriter textWriter = new Utf8StringWriter())
            {
                var serializer = new XmlSerializer(data.GetType());
                serializer.Serialize(textWriter, data);
                output = textWriter.ToString();
            }
            return output;
        }

        public T Deserialize<T>(string data)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (TextReader reader = new StringReader(data))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}
