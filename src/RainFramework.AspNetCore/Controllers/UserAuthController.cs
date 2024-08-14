using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RainFramework.AspNetCore.Base;
using RainFramework.AspNetCore.CoreService.Auth;
using RainFramework.AspNetCore.Model.VO;
using RainFramework.Model.Entities;
using RainFramework.Preconfigured.Configurer;
using static RainFramework.Common.Moudels.VO.HttpResult;

namespace RainFramework.AspNetCore.Controllers
{
    [Route("api/[controller]/")]
    [ApiExplorerSettings(GroupName = nameof(ApiGroup.BASICS))]
    public class UserAuthController : CrudControllerBase<UserAuth>
    {
        private IUserAuthService userAuthService;

        public UserAuthController(IUserAuthService userAuthService) : base(userAuthService)
        {
            this.userAuthService = userAuthService;
        }

        /// <summary>
        /// 根据ID删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}"), Authorize(Roles = "Administrator")]
        public async Task<ResultVO> DeleteUser(int id)
        {
            await userAuthService.DeleteUserById(id);
            return Success();
        }

        /// <summary>
        /// 局部修改用户
        /// </summary>
        /// <param name="id"></param>
        /// <param name="patchDoc"></param>
        /// <returns></returns>
        [HttpPatch("{id}"), Authorize(Roles = "Administrator")]
        public async Task<ResultVO> UpdateUser(int id, [FromBody] JsonPatchDocument<UserAuth> patchDoc)
        {
            await userAuthService.PatchUserAuth(id, patchDoc);
            return Success();
        }

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("list")]
        public ResultVO<IEnumerable<UserAuth>> ListUsers()
        {
            return Success(userAuthService.ListUsers());
        }

        /// <summary>
        /// 修改用户角色
        /// </summary>
        /// <param name="id"></param>
        /// <param name="roles"></param>
        /// <returns></returns>
        [HttpPost("{id}/Roles"), Authorize(Roles = "Administrator")]
        public async Task<ResultVO> UpdateUserRole(int id, [FromBody] List<int> roles)
        {
            await userAuthService.UpadteRoleByUserId(id, roles);
            return Success();
        }

        /// <summary>
        /// 修改自己的密码
        /// </summary>
        /// <param name="userAuth"></param>
        /// <returns></returns>
        [HttpPatch("myself/password")]
        public async Task<ResultVO> UpdateMyelfAuth([FromBody] UserAuthVO userAuth)
        {
            await userAuthService.UpdatePasswordById(RequestUser.Id, userAuth.Password);
            return Success();
        }
    }
}