using Microsoft.AspNetCore.Mvc;
using RainFramework.Cahce;

namespace Demo.Api.Controllers
{
    [Route("api/[controller]/")]
    public class TestController : ControllerBase
    {
        private readonly RFMemoryCache rFMemoryCache;

        public TestController(RFMemoryCache rFMemoryCache)
        {
            this.rFMemoryCache = rFMemoryCache;
        }

        public string Test()
        {
            rFMemoryCache.Set("ss", "ss",0);
            return "hello";
        }
    }
}
