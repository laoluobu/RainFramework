using Microsoft.AspNetCore.Mvc;
using WMS.Api.JWT;

namespace WMS.Api.Controllers
{
    /// <summary>
    /// sss
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = "auth")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        private readonly IJWTService jWTService;


        public WeatherForecastController(ILogger<WeatherForecastController> logger, IJWTService jWTService)
        {
            _logger = logger;
            this.jWTService = jWTService;
        }

        [HttpGet]
        public string Get()
        {
           var ss= jWTService.CreateToken("1111");
            _logger.LogInformation(ss);
            return "2222";
        }
    }
}