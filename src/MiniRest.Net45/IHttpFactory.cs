using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniRest
{
    public interface IHttpFactory
    {
        IHttpResponse Execute();
        Task<IHttpResponse> ExecuteAsync();
    }
}
