using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using MyMessageQueue.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMessageQueue.API
{
    public class ExceptionFilter : IExceptionFilter
    {
        private IErrorLogLogic _errorLogLogic;

        public ExceptionFilter(IErrorLogLogic errorLogLogic)
        {
            _errorLogLogic = errorLogLogic;
        }
        public void OnException(ExceptionContext context)
        {
            _errorLogLogic.AddLogMessageAsync(new Model.LogMessage()
            {
                Message = context.Exception.Message,
                Time = DateTime.UtcNow
            }).GetAwaiter().GetResult();
        }
    }
}
