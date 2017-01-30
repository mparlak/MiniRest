using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MiniRest.NetCore.Test
{
    [TestFixture]
    public class RestRequestTests
    {
        [Test]
        public void Get()
        {
            IRestClient client = new RestClient("http://localhost:3508");
            IRestRequest request = new RestRequest("/api/test");
            request.AddContentType("application/json");
            request.AddDataFormat(DataFormat.Json);
            request.AddMethod(Method.Get);
            var response = client.ExecuteAsync<object>(request);
        }

        [Test]
        public void Post()
        {
            IRestClient client = new RestClient("http://localhost:3508");
            IRestRequest request = new RestRequest("/api/gateway");
            request.AddContentType("application/json");
            request.AddDataFormat(DataFormat.Json);
            request.AddMethod(Method.Post);
            request.AddBody("Request Post body data");
            var response = client.ExecuteAsync<object>(request);
        }
    }
}
