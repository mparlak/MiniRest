using System;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MiniRest.Net461.Test
{
    [TestClass]
    public class BasicAuthenticationTests
    {
        [TestMethod]
        public void Get()
        {
            IRestRequest request = new RestRequest("http://localhost:3508");
            request.AddPath("/api/values");
            request.AddContentType("application/json");
            request.AddDataFormat(DataFormat.Json);
            request.AddMethod(Method.GET);
            request.AddBasicAuthentication("abc", "123");
            request.AddWebHeaderCollection("CustomerId", "1");
            IRestClient client = new RestClient(request);
            var response = client.Execute<object>();
            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK);
        }
    }
}
