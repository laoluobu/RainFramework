using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using RainFramework.AspNetCore.Base;
using RainFramework.AspNetCore.CoreService.Auth;
using static RainFramework.Model.VO.ResultTool;
using Microsoft.AspNetCore.JsonPatch;
using RainFramework.Model.Entities;
using RainFramework.Preconfigured.Configurer;

namespace RainFramework.AspNetCore.Controllers
{
    [Route("api/[controller]/")]
    [ApiExplorerSettings(GroupName = nameof(ApiGroup.BASICS))]
    public class RoleController : CrudControllerBase<Role>
    {
        private readonly IRoleService roleService;

        public RoleController(IRoleService roleService) : base(roleService)
        {
            this.roleService= roleService;
        }


        /// <summary>
        /// 根据ID删除角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}"), Authorize(Roles = "Administrator")]
        public async Task<ResultVO> DeleteRoles(int id)
        {
            await roleService.DeleteRoleById(id);
            return Success();
        }

        /// <summary>
        /// 局部修改角色
        /// </summary>
        /// <param name="id"></param>
        /// <param name="patchDoc"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public async Task<ResultVO> UpdateRoles(int id, [FromBody] JsonPatchDocument<Role> patchDoc)
        {
            var role = await roleService.FindAsync(id);
            patchDoc.ApplyTo(role);
            await roleService.UpdatesAsync(role);
            return Success();
        }

        /// <summary>
        /// 根据角色名查询角色
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ResultVO<IEnumerable<Role>> FindRolesByRoleName(string rolename)
        {
            var roles = roleService.FindMutilRolesByRoleName(rolename);
            return Success(roles);
        }

        /// <summary>
        /// 获取所有角色
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("list")]
        public ResultVO<IEnumerable<Role>> ListRoles()
        {
            return Success(roleService.ListRoles());
        }

        /// <summary>
        /// 修改角色菜单
        /// </summary>
        /// <param name="id">角色id</param>
        /// <param name="menus">角色菜单数组</param>
        /// <returns></returns>
        [HttpPost("{id}/Menus"), Authorize(Roles = "Administrator")]
        public async Task<ResultVO> UpdateRoleMenus(int id, [FromBody] List<int> menus)
        {
            await roleService.UpadteMenusByRoleId(id, menus);
            return Success();
        }
    }
}
