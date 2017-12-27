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
        Get,
        /// <summary>
        /// Http Method Post
        /// </summary>
        Post,
        /// <summary>
        /// Http Method Put
        /// </summary>
        Put,
        /// <summary>
        /// Http Method Delete
        /// </summary>
        Delete,
        /// <summary>
        /// Http Method Head
        /// </summary>
        Head,
        /// <summary>
        /// Http Method Patch
        /// </summary>
        Patch,
        /// <summary>
        /// Http Method Options
        /// </summary>
        Options
    }

    /// <summary>
    /// HTTP contenttype to use when making requests
    /// </summary>
    public enum DataFormat
    {
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
