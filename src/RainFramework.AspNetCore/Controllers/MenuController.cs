﻿using Microsoft.AspNetCore.Mvc;
using RainFramework.AspNetCore.Base;
using RainFramework.AspNetCore.Core.Auth;
using RainFramework.AspNetCore.Moudel.VO;
using RainFramework.Common.Configurer;
using RainFramework.Common.Moudel.VO;
using RainFramework.Repository.Entity;

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
            return ResultVO<IEnumerable<SysMenu>>.Ok(menus);
        }

        /// <summary>
        /// 获取所有菜单
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("list")]
        public ResultVO<IEnumerable<MenuVO>> ListMenus()
        {
           return ResultVO<IEnumerable<MenuVO>>.Ok(menuService.FindMenus());
        }
    }
}