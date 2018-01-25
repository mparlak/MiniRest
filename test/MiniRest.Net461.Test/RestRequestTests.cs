using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MiniRest.Net461.Test
{
    [TestClass]
    public class RestRequestTests
    {
        [TestMethod]
        public void Get()
        {
            IRestRequest request = new RestRequest("http://localhost:3508");
            request.AddPath("/api/test");
            request.AddContentType("application/json");
            request.AddDataFormat(DataFormat.Json);
            request.AddMethod(Method.GET);
            IRestClient client = new RestClient(request);
            var response = client.Execute<object>();
            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK);
        }

        [TestMethod]
        public void Post()
        {
            IRestRequest request = new RestRequest("http://localhost:3508");
            request.AddPath("/api/gateway");
            request.AddContentType("application/json");
            request.AddDataFormat(DataFormat.Json);
            request.AddMethod(Method.POST);
            request.AddBody("Request Post body data");
            IRestClient client = new RestClient(request);
            var response = client.Execute<object>();
        }
    }
}
