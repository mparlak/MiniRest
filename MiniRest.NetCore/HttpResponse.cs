using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MiniRest.NetCore
{
    public class HttpResponse : IHttpResponse
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public HttpResponse()
        {
            this.Headers = new List<HttpHeader>();
        }

        /// <summary>
        /// MIME content type of response
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Length in bytes of the response content
        /// </summary>
        public long ContentLength { get; set; }

        /// <summary>
        /// Encoding of the response content
        /// </summary>
        public string ContentEncoding { get; set; }

        /// <summary>
        /// response content
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// HTTP response status code
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Description of HTTP status returned
        /// </summary>
        public string StatusDescription { get; set; }

        /// <summary>
        /// Response content
        /// </summary>
        public byte[] RawBytes { get; set; }

        /// <summary>
        /// The URL that actually responded to the content (different from request if redirected)
        /// </summary>
        public Uri ResponseUri { get; set; }

        /// <summary>
        /// HttpWebResponse.Server
        /// </summary>
        public string Server { get; set; }

        /// <summary>
        /// Headers returned by server with the response
        /// </summary>
        public IList<HttpHeader> Headers { get; private set; }

        /// <summary>
        /// Transport or other non-HTTP error generated while attempting request
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Exception thrown when error is encountered.
        /// </summary>
        public Exception ErrorException { get; set; }

        /// <summary>
        /// The HTTP protocol version (1.0, 1.1, etc)
        /// </summary>
        /// <remarks>Only set when underlying framework supports it.</remarks>
        public Version ProtocolVersion { get; set; }

    }
}
