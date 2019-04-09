using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniRest
{
    /// <summary>
    /// HTTP method to use when making requests
    /// </summary>
    public enum Method
    {
        /// <summary>
        /// Http Method Get
        /// </summary>
        GET,
        /// <summary>
        /// Http Method Post
        /// </summary>
        POST,
        /// <summary>
        /// Http Method Put
        /// </summary>
        PUT,
        /// <summary>
        /// Http Method Delete
        /// </summary>
        DELETE,
        /// <summary>
        /// Http Method Head
        /// </summary>
        HEAD,
        /// <summary>
        /// Http Method Patch
        /// </summary>
        PATCH,
        /// <summary>
        /// Http Method Options
        /// </summary>
        OPTIONS
    }

    /// <summary>
    /// HTTP contenttype to use when making requests
    /// </summary>
    public enum DataFormat
    {
        None,
        /// <summary>
        /// HTTP ContentType Xml
        /// </summary>
        Xml,
        /// <summary>
        /// HTTP ContentType Json
        /// </summary>
        Json
    }
}
