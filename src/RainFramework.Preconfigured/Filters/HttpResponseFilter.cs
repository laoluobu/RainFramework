using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using RainFramework.Common.Exceptions;
using RainFramework.Common.Moudels.VO;

namespace RainFramework.Preconfigured.Filters
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
                    NotFoundException notFoundException => new ObjectResult(HttpResult.NotFound(notFoundException.Message))
                    {
                        StatusCode = 404
                    },

                    _ => new ObjectResult(HttpResult.Fail(afer.Exception))
                    {
                        StatusCode = 500
                    },
                };
                logger.LogError(" response {DisplayName} {Message} ", afer.ActionDescriptor.DisplayName, afer.Exception.Message);
                afer.ExceptionHandled = true;
            }
        }
    }

    public static class HttpResponseFilterProvider
    {
        public static void AddHttpResponseFilter(this MvcOptions option)
        {
            option.Filters.Add<HttpResponseFilter>();
        }
    } 
}