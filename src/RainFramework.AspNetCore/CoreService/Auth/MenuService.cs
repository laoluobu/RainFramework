using System.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RainFramework.AspNetCore.Model.VO;
using RainFramework.Common.Exceptions;
using RainFramework.Dao;
using RainFramework.EFCore.Base;
using RainFramework.Model.Constant;
using RainFramework.Model.Entities;

namespace RainFramework.AspNetCore.CoreService.Auth
{
    internal class MenuService<TDbContext> : CrudService<RFDBContext, Menu>, IMenuService where TDbContext : RFDBContext
    {
        private readonly IMapper mapper;

        public MenuService(TDbContext daseDBContext, IMapper mapper) : base(daseDBContext)
        {
            this.mapper = mapper;
        }

        public async Task<List<Menu>> FindMenuByRoleName(string RoleName)
        {
            var orderBy = dbSet.OrderBy(menu => menu.OrderNum);

            IQueryable<Menu> root;

            if (RoleName == RoleConst.ADMINISTRATOR)
            {
                root = orderBy.Where(menu => menu.ParentId == null);
            }
            else
            {
                root = orderBy.Where(menu => menu.Roles.Any(role => role.Name == RoleName) && menu.ParentId == null);
            }
            await LoopLoadMenu(root.ToList(), RoleName);
            return root.ToList();
        }

        private async Task LoopLoadMenu(List<Menu> menus, string? roleName)
        {
            if (menus.Count == 0)
            {
                return;
            }
            foreach (var menu in menus)
            {
                var entry = dbContext.Entry(menu).Collection(root => root.Children);
                if (roleName == null)
                {
                    await entry.LoadAsync();
                    await LoopLoadMenu(menu.Children, null);
                }
                if (roleName == RoleConst.ADMINISTRATOR)
                {
                    await entry.Query().OrderBy(menu => menu.OrderNum).LoadAsync();
                }
                else
                {
                    await entry.Query().OrderBy(menu => menu.OrderNum).Where(menu => menu.Roles.Any(roles => roles.Name == roleName)).LoadAsync();
                }
                await LoopLoadMenu(menu.Children, roleName);
            }
        }

        public async Task<IEnumerable<Menu>> FindMenuByRoleNames(IEnumerable<string> roleNames)
        {
            if (roleNames == null || !roleNames.Any())
            {
                throw new ArgumentNullException(nameof(roleNames));
            }
            var userEmunes = new List<Menu>();
            if (roleNames.Contains(RoleConst.ADMINISTRATOR))
            {
                userEmunes = await FindMenuByRoleName(RoleConst.ADMINISTRATOR);
            }
            else
            {
                foreach (var roleName in roleNames)
                {
                    var emuns = await FindMenuByRoleName(roleName);
                    userEmunes.AddRange(emuns);
                }
            }
            var distinctItems = userEmunes.OrderBy(menu => menu.OrderNum).GroupBy(x => x.Id).Select(y => y.First());
            return distinctItems;
        }

        public async Task<IEnumerable<MenuVO>> ListMenus()
        {
            var root = dbSet.OrderBy(menu => menu.OrderNum).Where(menu => menu.ParentId == null).ToList();
            await LoopLoadMenu(root, null);
            return mapper.Map<List<Menu>, List<MenuVO>>(root);
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