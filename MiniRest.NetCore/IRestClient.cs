using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniRest.NetCore
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRestClient
    {
        /// <summary>
        /// 
        /// </summary>
        IRestRequest RestRequest { get; set; }
        /// <summary>
        /// 
        /// </summary>
        Uri BaseUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        IRestResponse ExecuteAsync(IRestRequest request);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IRestResponse<T> ExecuteAsync<T>(IRestRequest request) where T : new();
    }
}
