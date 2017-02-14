using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniRest.NetCore
{
    public interface IHttpFactory
    {
        /// <summary>
        /// Http Request
        /// </summary>
        /// <returns></returns>
        Task<IHttpResponse> Execute();
    }
}
