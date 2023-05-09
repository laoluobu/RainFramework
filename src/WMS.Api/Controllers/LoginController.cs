using Microsoft.AspNetCore.Mvc;
using WMS.Api.Configurer;
using WMS.Api.JWT;
using WMS.Models.VO;
using WMS.Services.Core.Auth;

namespace WMS.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = nameof(ApiGroup.auth))]
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
            return userAuthServices.LoginService(userVO);
            
        }
    }
}