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
        /// Execute Result
        /// </summary>
        /// <returns></returns>
        IRestResponse Execute();
        /// <summary>
        /// Execute Result With Async
        /// </summary>
        /// <returns></returns>
        Task<IRestResponse> ExecuteAsync();
        /// <summary>
        /// Execute Result
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IRestResponse<T> Execute<T>() where T : new();
        /// <summary>
        /// Execute Result With Async
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Task<IRestResponse<T>> ExecuteAsync<T>() where T : new();
    }
}
