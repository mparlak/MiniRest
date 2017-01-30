using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MiniRest.NetCore
{
    /// <summary>
    /// 
    /// </summary>
    public class RestRequest : IRestRequest
    {
        /// <summary>
        /// 
        /// </summary>
        public WebHeaderCollection Headers { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Resource { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool AlwaysMultipartFormData { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DataFormat DataFormat { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Method Method { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public object Body { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ContentType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<Parameter> Parameters { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resource"></param>
        public RestRequest(string resource)
        {
            this.Resource = resource;
            this.Parameters = new List<Parameter>();
            this.Headers = new WebHeaderCollection();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public IRestRequest AddDataFormat(DataFormat format)
        {
            this.DataFormat = format;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        public IRestRequest AddMethod(Method method)
        {
            this.Method = method;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public IRestRequest AddBody(object data)
        {
            this.Body = data;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public IRestRequest AddContentType(string contentType)
        {
            this.ContentType = contentType;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public IRestRequest AddBasicAuthentication(string username, string password)
        {
            String encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password));
            this.Headers["Authorization"] = $"Basic {encoded}";
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public IRestRequest AddWebHeaderCollection(string key, string data)
        {
            this.Headers[key] = data;
            return this;
        }
    }
}

