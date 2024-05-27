using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RainFramework.Common.Exceptions;
using RainFramework.Model.VO;

namespace RainFramework.AspNetCore.Filters
{
    public class HttpResponseFilter : IAsyncActionFilter, IOrderedFilter
    {
        public int Order => int.MaxValue - 10;

        private ILogger<HttpResponseFilter> logger;

        public HttpResponseFilter(ILogger<HttpResponseFilter> logger)
        {
            this.logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var afer = await next();
            if (afer.Exception != null)
            {
                afer.Result = afer.Exception switch
                {
                    NotFoundException notFoundException => new ObjectResult(ResultTool.NotFound(notFoundException.Message))
                    {
                        StatusCode = 404
                    },
                    DbUpdateException dbUpdateException => new ObjectResult(ResultTool.Fail(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message))
                    {
                        StatusCode = 500
                    },
                    _ => new ObjectResult(ResultTool.Fail(afer.Exception))
                    {
                        StatusCode = 500
                    },
                };
                logger.LogError(" response {DisplayName} {Message} ", afer.ActionDescriptor.DisplayName, afer.Exception.Message);
                afer.ExceptionHandled = true;
            }
        }
    }
}