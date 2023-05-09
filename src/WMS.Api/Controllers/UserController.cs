using Microsoft.AspNetCore.Mvc;
using WMS.Api.Configurer;
using WMS.Repository.Entity;

namespace WMS.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = nameof(ApiGroup.auth))]
    public class UserController
    {
        [HttpGet, Route("/{userId}")]
        public async Task<UserInfo> GetUserInfo(string userId)
        {
            return new UserInfo();
        }
    }
}
