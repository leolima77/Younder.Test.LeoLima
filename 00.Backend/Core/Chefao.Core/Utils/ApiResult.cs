using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Chefao.Core.Utils
{
    public class ApiResult : HttpResponseMessage
    {
        string _message;
        object _result;
        HttpStatusCode _status;

        public ApiResult(HttpStatusCode status, string message, object result)
        {
            _message = message;
            _result = result;
            _status = status;
        }

        public Task<ApiResultModel> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new ApiResultModel()
            {
                message = _message,
                status = _status,
                result = _result
            };
            return Task.FromResult(response);
        }
    }

    public class ApiResultModel
    {
        public string message { get; set; }
        public HttpStatusCode status { get; set; }
        public object result { get; set; }
    }
}
