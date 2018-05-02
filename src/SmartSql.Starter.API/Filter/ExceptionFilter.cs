using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using SmartSql.Starter.API.Exceptions;
using SmartSql.Starter.API.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SmartSql.Starter.API.Filter
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly IHostingEnvironment env;
        private readonly ILogger<ExceptionFilter> logger;

        public ExceptionFilter(IHostingEnvironment env, ILogger<ExceptionFilter> logger)
        {
            this.env = env;
            this.logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            context.ExceptionHandled = true;
            var exception = context.Exception;
            logger.LogError(
                new EventId(exception.HResult),
                exception,
                exception.Message);
            string errorCode = "0001";
            if (exception is StarterException) { errorCode = (exception as StarterException).ErrorCode; }
            var errorResp = new ResponseMessage
            {
                Message = exception.Message,
                ErrorCode = errorCode,
                IsSuccess = false
            };
            var result = new JsonResult(errorResp)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
            context.Result = result;

        }
    }
}
