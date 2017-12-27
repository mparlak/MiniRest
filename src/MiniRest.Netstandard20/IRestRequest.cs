using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MiniRest
{
    /// <summary>
    /// RestRequest
    /// </summary>
    public interface IRestRequest
    {
        /// <summary>
        /// 
        /// </summary>
        WebHeaderCollection Headers { get; set; }
        /// <summary>
        /// Query string value
        /// </summary>
        string Path { get; set; }
        /// <summary>
        /// Base Uri Http Request
        /// </summary>
        string BaseUrl { get; set; }
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
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        IRestRequest AddPath(string path);
        /// <summary>
        /// This format for request body(Post,Put,Delete)
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        IRestRequest AddDataFormat(DataFormat format);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        IRestRequest AddMethod(Method method);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        IRestRequest AddBody(object data);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contentType"></param>
        /// <returns></returns>
        IRestRequest AddContentType(string contentType);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        IRestRequest AddBasicAuthentication(string username, string password);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        IRestRequest AddWebHeaderCollection(string key, string data);
    }
}
