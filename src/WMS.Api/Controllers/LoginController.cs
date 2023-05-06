using Microsoft.AspNetCore.Mvc;
using WMS.Api.Configurer;
using WMS.Api.JWT;

namespace WMS.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = nameof(ApiGroup.auth))]
    public class LoginController : ControllerBase
    {
        private readonly IJWTService jWTService;

        public LoginController(IJWTService jWTService)
        {
            this.jWTService = jWTService;
        }

        [HttpPost]
        public string Login(string username, string password)
        {
            return jWTService.CreateToken(username);
        }
    }
}