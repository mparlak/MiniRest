using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MiniRest.NetCore
{
    /// <summary>
    /// Parser
    /// </summary>
    public class Parser
    {
        /// <summary>
        /// Serialize Http Post,Put,Delete Body
        /// </summary>
        /// <param name="format"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string Serialize(DataFormat format, object data)
        {
            string result = string.Empty;
            switch (format)
            {
                case DataFormat.Xml:
                    result = SimpleXml.Serialize(data);
                    break;
                case DataFormat.Json:
                    result = SimpleJson.Serialize(data);
                    break;
            }
            return result;
        }

        /// <summary>
        /// Deserialize Http Post,Put,Delete Body
        /// </summary>
        /// <param name="format"></param>
        /// <param name="data"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Deserialize<T>(DataFormat format, string data) where T : new()
        {
            T result = default(T);
            switch (format)
            {
                case DataFormat.Xml:
                    result = SimpleXml.Deserialize<T>(data);
                    break;
                case DataFormat.Json:
                    result = SimpleJson.Deserialize<T>(data);
                    break;
            }
            return result;
        }
    }

    /// <summary>
    /// SimpleJson
    /// </summary>
    public class SimpleJson
    {
        /// <summary>
        /// Serialize By Newtonsoft
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string Serialize(object data)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        /// <summary>
        /// Deserialize By Newtonsoft
        /// </summary>
        /// <param name="data"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Deserialize<T>(string data) where T : new()
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(data);
        }
    }

    /// <summary>
    /// SimpleXml
    /// </summary>
    public class SimpleXml
    {
        /// <summary>
        /// Serialize By XmlSerialization
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string Serialize(object data)
        {
            var serializer = new XmlSerialization();
            return serializer.Serialize(data);
        }

        /// <summary>
        /// Deserialize By XmlSerialization
        /// </summary>
        /// <param name="data"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Deserialize<T>(string data) where T : new()
        {
            var serializer = new XmlSerialization();
            return serializer.Deserialize<T>(data);
        }
    }
}
