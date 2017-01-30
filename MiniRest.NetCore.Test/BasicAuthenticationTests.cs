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
            IRestClient client = new RestClient("http://localhost:3508");
            IRestRequest request = new RestRequest("/api/tes");
            request.AddContentType("application/json");
            request.AddDataFormat(DataFormat.Json);
            request.AddMethod(Method.Get);
            request.AddBasicAuthentication("admin", "admin");
            request.AddWebHeaderCollection("x-platform", "agent");
            var response = client.ExecuteAsync<object>(request);
            Assert.True(response.StatusCode == HttpStatusCode.OK);
        }
    }
}
