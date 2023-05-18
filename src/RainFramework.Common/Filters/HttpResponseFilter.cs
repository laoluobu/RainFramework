using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RainFramework.Common.CoreException;
using RainFramework.Common.Moudel.VO;

namespace RainFramework.Common.Filters
{
    public class HttpResponseFilter : IAsyncActionFilter, IOrderedFilter
    {
        public int Order => int.MaxValue - 10;

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var afer = await next();
            if (afer.Exception != null)
            {
                if (afer.Exception is NotFoundException notFoundException)
                {
                    afer.Result = new ObjectResult(ResultTool.NotFound(notFoundException.Message))
                    {
                        StatusCode = 404
                    };
                    afer.ExceptionHandled = true;
                    return;
                }
            }
        }
    }
}