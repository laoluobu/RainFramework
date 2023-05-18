using Microsoft.AspNetCore.Mvc;
using RainFramework.AspNetCore.CoreService.Auth;
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
            var token = await userAuthServices.LoginService(userVO);
            if(string.IsNullOrEmpty(token))
            {
                return TFail("User name or password error!");
            }
            return Success(token);
        }
    }
}