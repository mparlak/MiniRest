using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MiniRest
{
    /// <summary>
    /// RestResponse
    /// </summary>
    public interface IRestResponse
    {
        /// <summary>
        /// MIME content type of response
        /// </summary>
        string ContentType { get; set; }

        /// <summary>
        /// Length in bytes of the response content
        /// </summary>
        long ContentLength { get; set; }

        /// <summary>
        /// Encoding of the response content
        /// </summary>
        string ContentEncoding { get; set; }

        /// <summary>
        /// String representation of response content
        /// </summary>
        string Content { get; set; }

        /// <summary>
        /// HTTP response status code
        /// </summary>
        HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Description of HTTP status returned
        /// </summary>
        string StatusDescription { get; set; }

        /// <summary>
        /// Url
        /// </summary>
        Uri ResponseUri { get; set; }

        /// <summary>
        /// Transport or other non-HTTP error generated while attempting request
        /// </summary>
        string ErrorMessage { get; set; }

        /// <summary>
        /// Exceptions thrown during the request, if any.  
        /// </summary>
        Exception ErrorException { get; set; }

    }

    /// <summary>
    /// Container for data sent back from API including deserialized data
    /// </summary>
    /// <typeparam name="T">Type of data to deserialize to</typeparam>
    public interface IRestResponse<T> : IRestResponse
    {
        /// <summary>
        /// Deserialized entity data
        /// </summary>
        T Data { get; set; }
    }
}
