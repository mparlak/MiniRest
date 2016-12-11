using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniRest.NetCore
{
    public interface IRestRequest
    {
        /// <summary>
        /// Query string value
        /// </summary>
        string Resource { get; set; }
        /// <summary>
        /// Supported multipartFormData
        /// </summary>
        bool AlwaysMultipartFormData { get; set; }
        /// <summary>
        /// This format for request body(Post,Put,Delete)
        /// </summary>
        /// <returns></returns>
        DataFormat DataFormat { get; set; }
        /// <summary>
        /// 
        /// </summary>
        Method Method { get; set; }
        /// <summary>
        /// Request Body
        /// </summary>
        object Body { get; set; }
        /// <summary>
        /// Request ContentType
        /// </summary>
        string ContentType { get; set; }
        /// <summary>
        /// This format for request body(Post,Put,Delete)
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        IRestRequest AddDataFormat(DataFormat format);
        IRestRequest AddMethod(Method method);
        IRestRequest AddBody(object data);
        IRestRequest AddContentType(string contentType);
    }
}
