using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniRest.NetCore
{
    /// <summary>
    /// RestClient
    /// </summary>
    public interface IRestClient
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IRestResponse Execute();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IRestResponse ExecuteAsync();
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IRestResponse<T> Execute<T>() where T : new();
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Task<IRestResponse<T>> ExecuteAsync<T>() where T : new();
    }
}
