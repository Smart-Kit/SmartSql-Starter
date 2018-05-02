using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SmartSql.Starter.API.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSql.Starter.API.Filter
{
    public class ValidateModelFilter : IActionFilter
    {
        private readonly IHostingEnvironment _env;
        private readonly ILogger<ValidateModelFilter> _logger;

        public ValidateModelFilter(IHostingEnvironment env, ILogger<ValidateModelFilter> logger)
        {
            _env = env;
            _logger = logger;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                _logger.LogDebug("ModelState not valid:{0}", JsonConvert.SerializeObject(context.ModelState));
                StringBuilder errStr = new StringBuilder();

                foreach (var error in context.ModelState.Values)
                {
                    string errorMsg = error.Errors?.FirstOrDefault()?.ErrorMessage;
                    errStr.AppendFormat("{0} |", errorMsg);
                }

                var resp = new ResponseMessage
                {
                    ErrorCode = "0006",
                    Message = errStr.ToString().TrimEnd('|'),
                    IsSuccess = false
                };

                var result = new JsonResult(resp);
                context.Result = result;
            }
        }
    }
}
