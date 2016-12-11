using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniRest.NetCore
{
    public interface IRestClient
    {
        IRestRequest RestRequest { get; set; }
        Uri BaseUrl { get; set; }
        IRestResponse ExecuteAsync(IRestRequest request);
        IRestResponse<T> ExecuteAsync<T>(IRestRequest request) where T : new();
    }
}
