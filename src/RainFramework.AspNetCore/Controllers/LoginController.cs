using Microsoft.AspNetCore.Mvc;
using RainFramework.AspNetCore.Configurer;
using RainFramework.AspNetCore.Core.Auth;
using WMS.Models.VO;

namespace RainFramework.AspNetCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = nameof(ApiGroup.AUTH))]
    public class LoginController : ControllerBase
    {
        private readonly IUserAuthServices userAuthServices;

        public LoginController(IUserAuthServices userAuthServices)
        {
            this.userAuthServices = userAuthServices;
        }

        [HttpPost]
        public async Task<string> Login(UserVO userVO)
        {
            return await userAuthServices.LoginService(userVO);
        }
    }
}