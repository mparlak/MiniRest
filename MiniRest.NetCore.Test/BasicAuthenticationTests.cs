using System;
using System.Net;
using NUnit.Framework;

namespace MiniRest.NetCore.Test
{
    [TestFixture]
    public class BasicAuthenticationTests
    {
        [Test]
        public void Get()
        {
            try
            {
                IRestRequest request = new RestRequest("http://localhost:3508");
                request.AddPath("/api/values");
                request.AddContentType("application/json");
                request.AddDataFormat(DataFormat.Json);
                request.AddMethod(Method.Get);
                request.AddBasicAuthentication("abc", "123");
                request.AddWebHeaderCollection("CustomerId", "1");
                IRestClient client = new RestClient(request);
                var response = client.Execute<object>();
                Assert.True(response.StatusCode == HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
