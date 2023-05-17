using System.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RainFramework.AspNetCore.Moudel.VO;
using RainFramework.Common.Base;
using RainFramework.Repository.DBContext;
using RainFramework.Repository.Entity;

namespace RainFramework.AspNetCore.Core.Auth
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
                throw new ArgumentException($"Role {RoleName} is inexistence!");
            }
            return dbContext.SysMenus.Include(menu=>menu.Children).Where(menu => menu.Roles.Contains(role) && menu.ParentId==null).ToArray();
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


        public IEnumerable<MenuVO> FindMenus()
        {
           var menus= dbContext.SysMenus.Include(menu => menu.Children).Where(menu => menu.ParentId == null).ToList();
           return mapper.Map<List<SysMenu>,List<MenuVO>>(menus);
        }
    }
}