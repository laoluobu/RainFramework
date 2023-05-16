using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RainFramework.AspNetCore.Base;
using RainFramework.AspNetCore.Core.Auth;
using RainFramework.Common.Base;
using RainFramework.Common.Configurer;
using RainFramework.Common.Moudel.VO;
using RainFramework.Repository.Entity;

namespace RainFramework.AspNetCore.Controllers
{
    [ApiExplorerSettings(GroupName = nameof(ApiGroup.BASE))]
    public class UserInfoController : CrudControllerBase<UserInfo>
    {
        private IUserInfoService userInfoService;

        public UserInfoController(IUserInfoService userInfoService): base(userInfoService)
        {
            this.userInfoService = userInfoService;
        }

        /// <summary>
        /// 获取当前用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ResultVO<UserInfo>> GetCurrentUserInfo()
        {
            var userInfo = await userInfoService.FindUserInfoByUserId(RequestUser.Id);
            return ResultVO<UserInfo>.Ok(userInfo);
        }

        [HttpPost]
        public void AddUserInfo(UserInfo userInfo)
        {
            
        }
    }
}