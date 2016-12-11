using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MiniRest.NetCore
{
    public abstract class RestResponseBase
    {
        public string ContentType { get; set; }
        public long ContentLength { get; set; }
        public string ContentEncoding { get; set; }
        public string Content { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string StatusDescription { get; set; }
        public Uri ResponseUri { get; set; }
        public string ErrorMessage { get; set; }
        public Exception ErrorException { get; set; }
    }

    public class RestResponse<T> : RestResponseBase, IRestResponse<T>
    {
        /// <summary>
        /// Deserialized entity data
        /// </summary>
        public T Data { get; set; }

        public static explicit operator RestResponse<T>(RestResponse response)
        {
            return new RestResponse<T>
            {
                ContentEncoding = response.ContentEncoding,
                ContentLength = response.ContentLength,
                ContentType = response.ContentType,
                ErrorMessage = response.ErrorMessage,
                ErrorException = response.ErrorException,
                ResponseUri = response.ResponseUri,
                StatusCode = response.StatusCode,
                StatusDescription = response.StatusDescription
            };
        }
    }

    public class RestResponse : RestResponseBase, IRestResponse { }
}
