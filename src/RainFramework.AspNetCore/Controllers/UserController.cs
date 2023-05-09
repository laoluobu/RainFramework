using Microsoft.AspNetCore.Mvc;
using RainFramework.AspNetCore.Configurer;
using WMS.Repository.Entity;

namespace RainFramework.AspNetCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = nameof(ApiGroup.USER))]
    public class UserController : ControllerBase
    {
        [HttpGet, Route("{Id}")]
        public async Task<UserInfo> GetUserInfo(int Id)
        {
            return new UserInfo();
        }

        /// <summary>
        /// 获取当前用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<UserInfo> GetUserInfo()
        {
            return new UserInfo();
        }
    }
}