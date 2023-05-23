using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RainFramework.AspNetCore.Base;
using RainFramework.AspNetCore.CoreService.Auth;
using RainFramework.Common.Configurer;
using RainFramework.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RainFramework.Common.Moudel.VO.ResultTool;

namespace RainFramework.AspNetCore.Controllers
{
    [ApiExplorerSettings(GroupName = nameof(ApiGroup.BASE))]
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
        [HttpPatch("{id}")]
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
    }
}
