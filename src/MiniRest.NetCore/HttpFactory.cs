using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MiniRest.NetCore
{
    public class HttpFactory : IHttpFactory
    {
        private readonly IRestRequest _restRequest;
        private readonly Uri _baseUri;
        public HttpFactory(IRestRequest restRequest)
        {
            _restRequest = restRequest;
            _baseUri = new Uri(restRequest.BaseUrl);
        }
        /// <summary>
        /// Http Request
        /// </summary>
        /// <returns></returns>
        public async Task<IHttpResponse> Execute()
        {
            IHttpResponse response = new HttpResponse();
            try
            {
                var webRequest = WebRequest.Create(_baseUri + _restRequest.Path) as HttpWebRequest;
                if (webRequest == null) return null;
                webRequest.Headers = _restRequest.Headers;
                webRequest.Method = _restRequest.Method.ToString();
                if (!string.IsNullOrEmpty(_restRequest.ContentType))
                    webRequest.ContentType = _restRequest.ContentType;
                if (_restRequest.Method == Method.Post || _restRequest.Method == Method.Put || _restRequest.Method == Method.Delete)
                {
                    var output = Parser.Serialize(_restRequest.DataFormat, _restRequest.Body);
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
                        switch (_restRequest.Method)
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
