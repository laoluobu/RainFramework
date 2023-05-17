using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using RainFramework.AspNetCore.Base;
using RainFramework.AspNetCore.Core.Auth;
using RainFramework.AspNetCore.Moudel.VO;
using RainFramework.Common.Configurer;
using RainFramework.Common.Moudel.VO;
using RainFramework.Repository.Entity;
using static RainFramework.Common.Moudel.VO.ResultTool;

namespace RainFramework.AspNetCore.Controllers
{
    [ApiExplorerSettings(GroupName = nameof(ApiGroup.BASE))]
    public class MenuController : CrudControllerBase<SysMenu>
    {
        private readonly IMenuService menuService;

        public MenuController(IMenuService menuService) : base(menuService)
        {
            this.menuService = menuService;
        }

        /// <summary>
        /// 获取当前用户可用菜单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ResultVO<IEnumerable<SysMenu>>> GetCurrentUserMenus()
        {
            var menus = await menuService.FindEenuByRoleNames(RequestUser.Roles);

            return ResultTool.Ok(menus);
        }

        /// <summary>
        /// 获取所有菜单
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("list")]
        public ResultVO<IEnumerable<MenuVO>> ListMenus()
        {
            return ResultTool.Ok(menuService.ListMenus());
        }

        /// <summary>
        /// 根据ID删除菜单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete, Route("{id}"), Authorize(Roles = "Administrator")]
        public async Task<ResultVO<bool>> DeleteMenus(int id)
        {
            return ResultTool.Ok(await menuService.DeleteMenuById(id));
        }
    }
}