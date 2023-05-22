using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RainFramework.AspNetCore.Base;
using RainFramework.AspNetCore.CoreService.Auth;
using RainFramework.Common.Configurer;
using RainFramework.Common.Moudel.VO;
using RainFramework.Repository.Entity;
using System.Data;
using static RainFramework.Common.Moudel.VO.ResultTool;

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
        [HttpGet("myself")]
        public async Task<ResultVO<UserInfo>> GetCurrentUserInfo()
        {
            var userInfo = await userInfoService.FindUserInfoByUserId(RequestUser.Id);
            return Success(userInfo);
        }

        /// <summary>
        /// 根据ID删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}"), Authorize(Roles = "Administrator")]
        public async Task<ResultVO> DeleteUser(int id)
        {
            await userInfoService.DeleteUserById(id);
            return Success();
        }

        /// <summary>
        /// 局部修改用户
        /// </summary>
        /// <param name="id"></param>
        /// <param name="patchDoc"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public async Task<ResultVO> UpdateUser(int id, [FromBody] JsonPatchDocument<UserInfo> patchDoc)
        {
            var userInfo = await userInfoService.FindAsync(id);
            patchDoc.ApplyTo(userInfo);
            await userInfoService.UpdatesAsync(userInfo);
            return Success();
        }
    }
}