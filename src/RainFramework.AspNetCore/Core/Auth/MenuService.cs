using System.Data;
using RainFramework.Common.Base;
using RainFramework.Repository.DBContext;
using RainFramework.Repository.Entity;
using static RainFramework.Repository.DBContext.BaseDBContext;

namespace RainFramework.AspNetCore.Core.Auth
{
    internal class MenuService : CrudService<BaseDBContext, SysMenu>, IMenuService
    {

        private readonly IRoleService roleService;

        public MenuService(BaseDBContext daseDBContext, IRoleService roleService) : base(daseDBContext)
        {
            this.roleService = roleService;
        }

        public async Task<IEnumerable<SysMenu>> FindEenuByRoleName(string RoleName)
        {
            var role = await roleService.FindRoleByName(RoleName);
            if (role == null)
            {
                throw new ArgumentException($"Role {RoleName} is inexistence!");
            }
            return dbContext.SysMenus.Where(menu => menu.Roles.Contains(role)).ToArray();
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
    }
}