using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MiniRest.Mapping;

namespace MiniRest
{
    /// <summary>
    /// RestClient
    /// </summary>
    public sealed class RestClient : IRestClient
    {
        private readonly IRestRequest _restRequest;
        private readonly IHttpFactory _httpFactory;

        /// <summary>
        /// RestClient
        /// </summary>
        /// <param name="restRequest"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public RestClient(IRestRequest restRequest)
        {
            _restRequest = restRequest ?? throw new ArgumentNullException(nameof(restRequest));
            _httpFactory = new HttpFactory(_restRequest);
        }

        /// <summary>
        /// Execute Result
        /// </summary>
        /// <returns></returns>
        public IRestResponse Execute()
        {
            IHttpResponse response = _httpFactory.Execute().Result;
            return ResponseMapper.ToResponse(response);
        }

        /// <summary>
        /// Execute Result With Async
        /// </summary>
        /// <returns></returns>
        public async Task<IRestResponse> ExecuteAsync()
        {
            IHttpResponse response =  await _httpFactory.Execute();
            return ResponseMapper.ToResponse(response);
        }

        /// <summary>
        /// Execute Result
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IRestResponse<T> Execute<T>() where T : new()
        {
            IHttpResponse httpResponse = _httpFactory.Execute().Result;

            IRestResponse<T> restResponse = ResponseMapper.ToAsyncResponse<T>(httpResponse);

            if (!string.IsNullOrEmpty(httpResponse.Content))
            {
                restResponse.Data = Parser.Deserialize<T>(_restRequest.DataFormat, httpResponse.Content);
            }
            return restResponse;
        }

        /// <summary>
        /// Execute Result With Async
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public async Task<IRestResponse<T>> ExecuteAsync<T>() where T : new()
        {
            IHttpResponse httpResponse = await _httpFactory.Execute();

            IRestResponse<T> restResponse = ResponseMapper.ToAsyncResponse<T>(httpResponse);

            if (!string.IsNullOrEmpty(httpResponse.Content))
            {
                restResponse.Data = Parser.Deserialize<T>(_restRequest.DataFormat, httpResponse.Content);
            }

            return restResponse;
        }
    }
}
