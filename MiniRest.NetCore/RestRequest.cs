using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniRest.NetCore
{
    public class RestRequest : IRestRequest
    {
        public string Resource { get; set; }

        public bool AlwaysMultipartFormData { get; set; }

        public DataFormat DataFormat { get; set; }

        public Method Method { get; set; }

        public object Body { get; set; }
        public string ContentType { get; set; }

        public RestRequest(string resource)
        {
            this.Resource = resource;
        }

        public IRestRequest AddDataFormat(DataFormat format)
        {
            this.DataFormat = format;
            return this;
        }

        public IRestRequest AddMethod(Method method)
        {
            this.Method = method;
            return this;
        }

        public IRestRequest AddBody(object data)
        {
            this.Body = data;
            return this;
        }

        public IRestRequest AddContentType(string contentType)
        {
            this.ContentType = contentType;
            return this;
        }
    }
}
