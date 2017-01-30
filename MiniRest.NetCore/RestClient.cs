using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MiniRest.NetCore.Mapping;

namespace MiniRest.NetCore
{
    public sealed class RestClient : IRestClient
    {
        public IRestRequest RestRequest { get; set; }
        public Uri BaseUrl { get; set; }

        public RestClient(string baseUrl)
        {
            if (string.IsNullOrEmpty(baseUrl))
            {
                throw new ArgumentNullException(nameof(baseUrl));
            }
            this.BaseUrl = new Uri(baseUrl);
        }

        public IRestResponse ExecuteAsync(IRestRequest request)
        {
            IHttpResponse response = Execute(request).Result;
            return ResponseMapper.ToResponse(response);
        }

        public IRestResponse<T> ExecuteAsync<T>(IRestRequest request) where T : new()
        {
            IHttpResponse httpResponse = Execute(request).Result;
            IRestResponse<T> restResponse;
            try
            {
                restResponse = ResponseMapper.ToAsyncResponse<T>(httpResponse);
                restResponse.Data = Parser.Deserialize<T>(request.DataFormat, httpResponse.Content);
            }
            catch (Exception ex)
            {
                restResponse = new RestResponse<T>
                {
                    StatusCode = httpResponse.StatusCode,
                    StatusDescription = httpResponse.StatusDescription,
                    ErrorMessage = ex.Message
                };
            };
            return restResponse;
        }

        private async Task<IHttpResponse> Execute(IRestRequest request)
        {
            RestRequest = request;
            IHttpResponse response = new HttpResponse();
            try
            {
                var webRequest = WebRequest.Create(BaseUrl + RestRequest.Resource) as HttpWebRequest;
                if (webRequest == null) return null;
                webRequest.Headers = request.Headers;
                webRequest.Method = RestRequest.Method.ToString();
                if (!string.IsNullOrEmpty(RestRequest.ContentType))
                    webRequest.ContentType = RestRequest.ContentType;
                if (RestRequest.Method == Method.Post || RestRequest.Method == Method.Put ||
                    RestRequest.Method == Method.Delete)
                {
                    var output = Parser.Serialize(RestRequest.DataFormat, RestRequest.Body);
                    var byteArray = Encoding.UTF8.GetBytes(output);
                    using (var stream = await webRequest.GetRequestStreamAsync())
                    {
                        stream.Write(byteArray, 0, byteArray.Length);
                    }
                }
                using (var webResponse = await webRequest.GetResponseAsync())
                {
                    using (var streamReader = new StreamReader(webResponse.GetResponseStream()))
                    {
                        string result = streamReader.ReadToEnd();
                        response.Content = result;
                        switch (RestRequest.Method)
                        {
                            case Method.Post:
                                response.StatusCode = HttpStatusCode.Created;
                                break;
                            case Method.Put:
                            case Method.Delete:
                                response.StatusCode = HttpStatusCode.NoContent;
                                break;
                            case Method.Get:
                                response.StatusCode = HttpStatusCode.OK;
                                break;
                            default:
                                response.StatusCode = HttpStatusCode.OK;
                                break;
                        }

                    }
                }
            }
            catch (WebException ex)
            {
                response.StatusCode = ((HttpWebResponse)ex.Response).StatusCode;
                response.StatusDescription = ((HttpWebResponse)ex.Response).StatusDescription;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }
    }
}
