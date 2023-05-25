﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RainFramework.AspNetCore.Base;
using RainFramework.AspNetCore.CoreService.Auth;
using RainFramework.AspNetCore.Moudel.VO;
using RainFramework.Common.Configurer;
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
        [HttpGet("myself")]
        public async Task<ResultVO<IEnumerable<SysMenu>>> GetCurrentUserMenus()
        {
            return Success(await menuService.FindEenuByRoleNames(RequestUser.Roles));
        }

        /// <summary>
        /// 获取所有菜单
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("list")]
        public async Task<ResultVO<IEnumerable<MenuVO>>> ListMenus()
        {
            return Success(await menuService.ListMenus());
        }

        /// <summary>
        /// 根据ID删除菜单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete, Route("{id}"), Authorize(Roles = "Administrator")]
        public async Task<ResultVO> DeleteMenus(int id)
        {
            await menuService.DeleteMenuById(id);
            return Success();
        }

        /// <summary>
        /// 局部修改菜单
        /// </summary>
        /// <param name="id"></param>
        /// <param name="patchDoc"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public async Task<ResultVO> UpdateMenus(int id, [FromBody] JsonPatchDocument<SysMenu> patchDoc)
        {
            var sysMenu = await menuService.FindAsync(id);
            patchDoc.ApplyTo(sysMenu);
            await menuService.UpdatesAsync(sysMenu);
            return Success();
        }
    }
}