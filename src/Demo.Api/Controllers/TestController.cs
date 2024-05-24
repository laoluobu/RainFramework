using Microsoft.AspNetCore.Mvc;
using RainFramework.Cahce;
using RainFramework.Common.Configurer;

namespace Demo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    [ApiExplorerSettings(GroupName = nameof(ApiGroup.TEST))]
    public class TestController : ControllerBase
    {
        private readonly RFMemoryCache rFMemoryCache;

        public TestController(RFMemoryCache rFMemoryCache)
        {
            this.rFMemoryCache = rFMemoryCache;
        }


        [HttpGet]
        public string Test()
        {
            rFMemoryCache.Set("ss", "ss",0);
            return "hello";
        }
    }
}
