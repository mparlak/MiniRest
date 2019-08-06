using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MiniRest
{
    public class HttpFactory : IHttpFactory
    {
        private readonly IRestRequest _restRequest;
        public HttpFactory(IRestRequest restRequest)
        {
            _restRequest = restRequest;
        }

        public IHttpResponse Execute()
        {
            IHttpResponse response = new HttpResponse();
            try
            {
                var webRequest = WebRequest.Create(_restRequest.BaseUrl + _restRequest.Path) as HttpWebRequest;
                if (webRequest == null) return null;
                webRequest.Headers = _restRequest.Headers;
                webRequest.Method = _restRequest.Method.ToString();
                if (_restRequest.Timeout > default(int))
                {
                    webRequest.Timeout = _restRequest.Timeout;
                }

                if (_restRequest.ReadWriteTimeout > default(int))
                {
                    webRequest.ReadWriteTimeout = _restRequest.ReadWriteTimeout;
                }

                if (!string.IsNullOrEmpty(_restRequest.ContentType))
                {
                    webRequest.ContentType = _restRequest.ContentType;
                }
                if (_restRequest.Method == Method.POST || _restRequest.Method == Method.PUT || _restRequest.Method == Method.DELETE || _restRequest.Method == Method.PATCH)
                {
                    var output = _restRequest.DataFormat == DataFormat.None ? _restRequest.Body.ToString() : Parser.Serialize(_restRequest.DataFormat, _restRequest.Body);
                    var byteArray = Encoding.UTF8.GetBytes(output);
                    using (var stream = webRequest.GetRequestStream())
                    {
                        stream.Write(byteArray, 0, byteArray.Length);
                    }
                }
                using (var webResponse = webRequest.GetResponse())
                {
                    using (var streamReader = new StreamReader(webResponse.GetResponseStream()))
                    {
                        string result = streamReader.ReadToEnd();
                        response.Content = result;
                        response.StatusCode = ((HttpWebResponse)webResponse).StatusCode;
                        response.StatusDescription = ((HttpWebResponse)webResponse).StatusDescription;
                    }
                }
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    using (var streamReader = new StreamReader(ex.Response.GetResponseStream()))
                    {
                        string result = streamReader.ReadToEnd();
                        response.Content = result;
                    }
                }

                var statusCode = (ex.Response as HttpWebResponse)?.StatusCode ?? HttpStatusCode.InternalServerError;

                if (statusCode != null)
                {
                    response.StatusCode = (HttpStatusCode)statusCode;
                }

                var statusDescription = (ex.Response as HttpWebResponse)?.StatusDescription;

                if (!string.IsNullOrEmpty(statusDescription)) 
                {
                    response.StatusDescription = statusDescription;
                }
                
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        public async Task<IHttpResponse> ExecuteAsync()
        {
            IHttpResponse response = new HttpResponse();
            try
            {
                var webRequest = WebRequest.Create(_restRequest.BaseUrl + _restRequest.Path) as HttpWebRequest;
                if (webRequest == null) return null;
                webRequest.Headers = _restRequest.Headers;
                webRequest.Method = _restRequest.Method.ToString();
                if (_restRequest.Timeout > default(int))
                {
                    webRequest.Timeout = _restRequest.Timeout;
                }

                if (_restRequest.ReadWriteTimeout > default(int))
                {
                    webRequest.ReadWriteTimeout = _restRequest.ReadWriteTimeout;
                }

                if (!string.IsNullOrEmpty(_restRequest.ContentType))
                {
                    webRequest.ContentType = _restRequest.ContentType;
                }
                if (_restRequest.Method == Method.POST || _restRequest.Method == Method.PUT || _restRequest.Method == Method.DELETE || _restRequest.Method == Method.PATCH)
                {
                    var output = _restRequest.DataFormat == DataFormat.None ? _restRequest.Body.ToString() : Parser.Serialize(_restRequest.DataFormat, _restRequest.Body);
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
                        response.StatusCode = ((System.Net.HttpWebResponse)webResponse).StatusCode;
                        response.StatusDescription = ((System.Net.HttpWebResponse)webResponse).StatusDescription;
                    }
                }
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    using (var streamReader = new StreamReader(ex.Response.GetResponseStream()))
                    {
                        string result = streamReader.ReadToEnd();
                        response.Content = result;
                    }
                }

                var statusCode = (ex.Response as HttpWebResponse)?.StatusCode ?? HttpStatusCode.InternalServerError;

                if (statusCode != null)
                {
                    response.StatusCode = (HttpStatusCode)statusCode;
                }

                var statusDescription = (ex.Response as HttpWebResponse)?.StatusDescription;

                if (!string.IsNullOrEmpty(statusDescription))
                {
                    response.StatusDescription = statusDescription;
                }

                response.ErrorMessage = ex.Message;
            }
            return response;
        }
    }
}
