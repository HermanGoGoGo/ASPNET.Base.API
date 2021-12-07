using System;
using Abp.Dependency;
using AI5yue.Base.API.Filter.ApiResult.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace AI5yue.Base.API.Filter
{
    public class CustomerExceptionFilter : Attribute, IExceptionFilter, ITransientDependency
    {
        private readonly ILogger<CustomerExceptionFilter> _logger;

        public CustomerExceptionFilter(ILogger<CustomerExceptionFilter> logger)
        {
            _logger = logger;
            //注入
        }

        public void OnException(ExceptionContext context)
        {
            if (context.ExceptionHandled == false)
            {
                var exp = context.Exception?.GetBaseException();
                context.Result = new JsonResult(ApiResultHelper.BadResult(exp?.Message ?? ""));
                _logger.LogError(exp?.Message ?? "");
                context.Exception = null; //Handled!
            }
        }
    }

}

