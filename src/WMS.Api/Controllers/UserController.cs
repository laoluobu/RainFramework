using Microsoft.AspNetCore.Mvc;
using WMS.Api.Configurer;
using WMS.Models.VO;
using WMS.Repository.Entity;

namespace WMS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = nameof(ApiGroup.user))]
    public class UserController : ControllerBase
    {
        [HttpGet, Route("{Id}")]
        public async Task<UserInfo> GetUserInfo(int Id)
        {
            if (Id == null)
            {
                await Console.Out.WriteLineAsync(Id + "");
            }
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