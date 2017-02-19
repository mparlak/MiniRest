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
        private readonly IRestRequest _restRequest;
        private readonly IHttpFactory _httpFactory;

        public RestClient(IRestRequest restRequest)
        {
            if (restRequest == null)
            {
                throw new ArgumentNullException(nameof(restRequest));
            }
            _restRequest = restRequest;
            _httpFactory = new HttpFactory(_restRequest);
        }

        public IRestResponse Execute()
        {
            IHttpResponse response = _httpFactory.Execute().Result;
            return ResponseMapper.ToResponse(response);
        }

        public IRestResponse ExecuteAsync()
        {
            IHttpResponse response = _httpFactory.Execute().Result;
            return ResponseMapper.ToResponse(response);
        }

        public IRestResponse<T> Execute<T>() where T : new()
        {
            IHttpResponse httpResponse = _httpFactory.Execute().Result;
            IRestResponse<T> restResponse;
            try
            {
                restResponse = ResponseMapper.ToAsyncResponse<T>(httpResponse);
                restResponse.Data = Parser.Deserialize<T>(_restRequest.DataFormat, httpResponse.Content);
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

        public async Task<IRestResponse<T>> ExecuteAsync<T>() where T : new()
        {
            IHttpResponse httpResponse = await _httpFactory.Execute();
            IRestResponse<T> restResponse;
            try
            {
                restResponse = ResponseMapper.ToAsyncResponse<T>(httpResponse);
                restResponse.Data = Parser.Deserialize<T>(_restRequest.DataFormat, httpResponse.Content);
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
    }
}
