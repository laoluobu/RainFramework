using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using RainFramework.AspNetCore.Base;
using RainFramework.AspNetCore.CoreService.Auth;
using RainFramework.Common.Configurer;
using RainFramework.Repository.Entity;
using static RainFramework.Common.Moudel.VO.ResultTool;

namespace RainFramework.AspNetCore.Controllers
{
    [ApiExplorerSettings(GroupName = nameof(ApiGroup.BASE))]
    public class RoleController : CrudControllerBase<Role>
    {
        private readonly IRoleService roleService;

        public RoleController(IRoleService roleService) : base(roleService)
        {
            this.roleService= roleService;
        }


        /// <summary>
        /// 根据ID删除菜单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}"), Authorize(Roles = "Administrator")]
        public async Task<ResultVO> DeleteRoles(int id)
        {
            await roleService.DeleteRoleById(id);
            return Success();
        }


    }
}
