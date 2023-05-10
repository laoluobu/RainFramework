using Microsoft.AspNetCore.Mvc;
using RainFramework.AspNetCore.Configurer;
using RainFramework.AspNetCore.Core.Auth;
using RainFramework.Common.Moudel.VO;

namespace RainFramework.AspNetCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = nameof(ApiGroup.AUTH))]
    public class LoginController : ControllerBase
    {
        private readonly IUserAuthService userAuthServices;

        public LoginController(IUserAuthService userAuthServices)
        {
            this.userAuthServices = userAuthServices;
        }

        [HttpPost]
        public async Task<ResultVO<string>> Login(UserVO userVO)
        {
            var token = await userAuthServices.LoginService(userVO);
            return ResultVO<string>.Ok(token);
        }
    }
}