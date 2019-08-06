using System;
using MiniRest;

namespace BasicMiniRestApplication
{
    public class OrderPatchRequest
    {
        public int ProductId { get; set; }
        public int VariantId { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IRestRequest request = new RestRequest("http://localhost:5000");
            request.AddPath("/v1/orders/58f331d1-a48c-4910-bdd2-e87c6fd97feb");
            request.AddContentType("application/json");
            request.AddDataFormat(DataFormat.Json);
            request.AddMethod(Method.PATCH);
            request.AddBody(new OrderPatchRequest { ProductId = 1, VariantId = 2 });
            IRestClient client = new RestClient(request);
            var response = client.Execute<OrderPatchRequest>();
            Console.ReadKey();
        }
    }
}
