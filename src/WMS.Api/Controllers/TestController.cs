using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WMS.Api.Configurer;
using WMS.Api.JWT;

namespace WMS.Api.Controllers
{
    /// <summary>
    /// sss
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = nameof(ApiGroup.test))]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;

        

        public TestController(ILogger<TestController> logger, IJWTService jWTService)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            return "2222";
        }
    }
}