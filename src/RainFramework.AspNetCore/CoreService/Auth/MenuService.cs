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

        public IEnumerable<SysMenu> FindEenuByRoleName(string RoleName)
        {
            var rootMenus = FindRoleRootMenusLoad(RoleName);
            return rootMenus;
        }

        private List<SysMenu> FindRoleRootMenus(string RoleName)
        {
            return dbSet.AsNoTracking()
            .Include(menu => menu.Children.OrderBy(menu => menu.OrderNum))
            .Include(menu => menu.Roles)
            .Where(menu => menu.Roles.Any(role => role.RoleName == RoleName) && menu.ParentId == null)
            .OrderBy(menu => menu.OrderNum).ToList();
        }


        private List<SysMenu> FindRoleRootMenusLoad(string RoleName)
        {
            var root = dbSet.Where(menu => menu.Roles.Any(role => role.RoleName == RoleName) && menu.ParentId == null);
            dbContext.Entry(root.First())
                .Collection(root=>root.Children)
                .Query()
                .Where(menu => menu.Roles.Any(roles => roles.RoleName == RoleName)).Load();
            return root.ToList();
        }
            


        private List<SysMenu> FindRoleMenus(List<SysMenu> menuList, string RoleName)
        {
            var menus = menuList.Where(menu => menu.Children.Any(menu => menu.Roles.Any(role => role.RoleName == RoleName))).ToList();

            if (menus.Any(menu => menu.Children.Any()))
            {
                menus = FindRoleMenus(menus, RoleName);
            }

            return menus;
        }

        public IEnumerable<SysMenu> FindEenuByRoleNames(IEnumerable<string> RoleNames)
        {
            if (RoleNames == null || !RoleNames.Any())
            {
                throw new ArgumentNullException(nameof(RoleNames));
            }
            var userEmunes = new List<SysMenu>();
            foreach (var roleName in RoleNames)
            {
                var emuns = FindEenuByRoleName(roleName);
                userEmunes.AddRange(emuns);
            }
            var distinctItems = userEmunes.GroupBy(x => x.Id).Select(y => y.First());
            return distinctItems;
        }

        public IEnumerable<MenuVO> ListMenus()
        {
            var menus = dbSet.AsNoTracking()
                             .Include(menu => menu.Children.OrderBy(menu => menu.OrderNum))
                             .Where(menu => menu.ParentId == null)
                             .OrderBy(menu => menu.OrderNum)
                             .ToList();
            return mapper.Map<List<SysMenu>, List<MenuVO>>(menus);
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