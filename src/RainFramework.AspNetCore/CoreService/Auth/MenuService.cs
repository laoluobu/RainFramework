using System.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RainFramework.AspNetCore.Moudel.VO;
using RainFramework.Common.Base;
using RainFramework.Common.CoreException;
using RainFramework.Repository.DBContext;
using RainFramework.Repository.Entity;

namespace RainFramework.AspNetCore.CoreService.Auth
{
    internal class MenuService : CrudService<BaseDBContext, SysMenu>, IMenuService
    {
        private readonly IMapper mapper;

        public MenuService(BaseDBContext daseDBContext, IMapper mapper) : base(daseDBContext)
        {
            this.mapper = mapper;
        }

        public async Task<IEnumerable<SysMenu>> FindEenuByRoleName(string RoleName)
        {
            var rootMenus = await FindRoleMenus(RoleName);
            return rootMenus;
        }


        private async Task<List<SysMenu>> FindRoleMenus(string RoleName)
        {
            var root = dbSet.Where(menu => menu.Roles.Any(role => role.RoleName == RoleName) && menu.ParentId == null).ToList();
            await LoopLoadMenu(root, RoleName);
            return root.ToList();
        }
            


        private async Task LoopLoadMenu(List<SysMenu> menus, string? RoleName)
        {
            if (!menus.Any()) return;
            foreach (var menu in menus)
            {
                var entry = dbContext.Entry(menu).Collection(root => root.Children);
                if (RoleName == null)
                {
                    await entry.LoadAsync();
                    await LoopLoadMenu(menu.Children, null);
                }
                await entry.Query().Where(menu => menu.Roles.Any(roles => roles.RoleName == RoleName)).LoadAsync();
                await LoopLoadMenu(menu.Children, RoleName);

            }
        }



        public async Task<IEnumerable<SysMenu>> FindEenuByRoleNames(IEnumerable<string> RoleNames)
        {
            if (RoleNames == null || !RoleNames.Any())
            {
                throw new ArgumentNullException(nameof(RoleNames));
            }
            var userEmunes = new List<SysMenu>();
            foreach (var roleName in RoleNames)
            {
                var emuns =await FindEenuByRoleName(roleName);
                userEmunes.AddRange(emuns);
            }
            var distinctItems = userEmunes.GroupBy(x => x.Id).Select(y => y.First());
            return distinctItems;
        }

        public async Task<IEnumerable<MenuVO>> ListMenus()
        {
            var root = dbSet.Where(menu=> menu.ParentId == null).ToList();
            await LoopLoadMenu(root, null);
            return mapper.Map<List<SysMenu>, List<MenuVO>>(root);
        }

        public async Task DeleteMenuById(int id)
        {
            var count = await dbSet.Where(menu => menu.Id == id).ExecuteDeleteAsync() > 0;
            if (!count)
            {
                throw new NotFoundException($"The menus id is {id} not found!");
            }
        }
    }
}