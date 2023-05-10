using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RainFramework.AspNetCore.Configurer;
using RainFramework.AspNetCore.Core.Auth;
using RainFramework.Common.Moudel.VO;
using WMS.Repository.Entity;

namespace RainFramework.AspNetCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    [ApiExplorerSettings(GroupName = nameof(ApiGroup.USER))]
    public class UserController : AuthControllerBase
    {
        private IUserInfoService userInfoService;

        public UserController(IUserInfoService userInfoService)
        {
            this.userInfoService = userInfoService;
        }


        [HttpGet, Route("{Id}")]
        public async Task<ResultVO<UserInfo>> GetUserInfo(int Id)
        {
            var userInfo= await userInfoService.FindAsync(Id);
            return ResultVO<UserInfo>.Ok(userInfo);
        }

        /// <summary>
        /// 获取当前用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ResultVO<UserInfo>> GetUserInfo()
        {
            var s = User.Claims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value;
            await Console.Out.WriteLineAsync(RequestUser.ToString());

            var userInfo = await userInfoService.FindUserInfoByUserId(RequestUser.Id);
            return ResultVO<UserInfo>.Ok(userInfo);
        }

        [HttpPost]
        public void AddUserInfo(UserInfo userInfo)
        {
            
        }
    }
}