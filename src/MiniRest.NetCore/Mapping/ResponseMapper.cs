using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniRest.NetCore.Mapping
{
    public class ResponseMapper
    {
        public static IRestResponse ToResponse(IHttpResponse response)
        {
            return new RestResponse
            {
                ContentEncoding = response.ContentEncoding,
                ContentLength = response.ContentLength,
                ContentType = response.ContentType,
                ErrorException = response.ErrorException,
                ErrorMessage = response.ErrorMessage,
                ResponseUri = response.ResponseUri,
                StatusCode = response.StatusCode,
                StatusDescription = response.StatusDescription,
                Content = response.Content
            };
        }

        public static IRestResponse<T> ToAsyncResponse<T>(IHttpResponse response)
        {
            return new RestResponse<T>
            {
                ContentEncoding = response.ContentEncoding,
                ContentLength = response.ContentLength,
                ContentType = response.ContentType,
                ErrorException = response.ErrorException,
                ErrorMessage = response.ErrorMessage,
                ResponseUri = response.ResponseUri,
                StatusCode = response.StatusCode,
                StatusDescription = response.StatusDescription,
                Content = response.Content
            };
        }
    }
}
