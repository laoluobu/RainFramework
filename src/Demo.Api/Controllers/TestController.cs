using Microsoft.AspNetCore.Mvc;

namespace Demo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController:ControllerBase
    {
        [HttpGet]
        public string Hello()
        {
            return "Hello";
        }
    }
}
