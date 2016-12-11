using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniRest.NetCore
{
    /// <summary>
    /// HTTP method to use when making requests
    /// </summary>
    public enum Method
    {
        Get,
        Put,
        Delete,
        Post,
        Head,
        Patch,
        Options
    }

    /// <summary>
    /// HTTP contenttype to use when making requests
    /// </summary>
    public enum DataFormat
    {
        Xml,
        Json
    }
}
