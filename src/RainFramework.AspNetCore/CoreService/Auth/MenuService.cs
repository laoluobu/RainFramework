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
        private readonly IRoleService roleService;
        private readonly IMapper mapper;

        public MenuService(BaseDBContext daseDBContext, IRoleService roleService, IMapper mapper) : base(daseDBContext)
        {
            this.roleService = roleService;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<SysMenu>> FindEenuByRoleName(string RoleName)
        {
            var role = await roleService.FindRoleByName(RoleName);
            if (role == null)
            {
                throw new NotFoundException($"Role {RoleName} is inexistence!");
            }
            return dbSet.AsNoTracking()
                        .Include(menu => menu.Children.OrderBy(menu => menu.OrderNum))
                        .Where(menu => menu.Roles.Contains(role) && menu.ParentId == null)
                        .OrderBy(menu => menu.OrderNum).ToArray();
        }

        public async Task<IEnumerable<SysMenu>?> FindEenuByRoleNames(IEnumerable<string> RoleNames)
        {
            if (RoleNames == null || !RoleNames.Any())
            {
                throw new ArgumentNullException(nameof(RoleNames));
            }
            var userEmunes = new List<SysMenu>();
            foreach (var roleName in RoleNames)
            {
                var emuns = await FindEenuByRoleName(roleName);
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