using Microsoft.AspNetCore.Mvc;
using RainFramework.AspNetCore.Core.Auth;
using RainFramework.Common.Configurer;
using RainFramework.Common.Moudel.VO;
using static RainFramework.Common.Moudel.VO.ResultTool;

namespace RainFramework.AspNetCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = nameof(ApiGroup.BASE))]
    public class LoginController : ControllerBase
    {
        private readonly IUserAuthService userAuthServices;

        public LoginController(IUserAuthService userAuthServices)
        {
            this.userAuthServices = userAuthServices;
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userVO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultVO<string>> Login(UserVO userVO)
        {
            var requestIp = Request.HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString();
            var token = await userAuthServices.LoginService(userVO);
            return ResultTool.Ok(token);
        }
    }
}