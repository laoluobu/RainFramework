using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RainFramework.AspNetCore.CoreService.Auth;
using RainFramework.Model.VO;
using RainFramework.Preconfigured.Configurer;
using static RainFramework.Common.Moudels.VO.HttpResult;

namespace RainFramework.AspNetCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = nameof(ApiGroup.BASICS))]
    public class LoginController : ControllerBase
    {
        private readonly IUserAuthService userAuthServices;
        private readonly ILogger<LoginController> logger;

        public LoginController(IUserAuthService userAuthServices, ILogger<LoginController> logger)
        {
            this.userAuthServices = userAuthServices;
            this.logger = logger;
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userVO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultVO> Login(UserVO userVO)
        {
            try
            {
                var token = await userAuthServices.LoginService(userVO);
                return Success(token);
            }
            catch (Exception e)
            {
                logger.LogError("Login Err: {Message}", e.Message);
                return Fail("User name or password error!");
            }
        }
    }
}