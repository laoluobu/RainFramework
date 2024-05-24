using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RainFramework.Common.Base;
using RainFramework.Common.CoreException;
using RainFramework.Repository.DBContext;
using RainFramework.Repository.Entity;
using System.Data;
using static RainFramework.Repository.DBContext.RFDBContext;

namespace RainFramework.AspNetCore.CoreService.Auth
{
    internal class RoleService<TDbContext> : CrudService<RFDBContext, Role>, IRoleService where TDbContext : RFDBContext
    {
        private IMenuService menuService;
        public RoleService(TDbContext daseDBContext, IMenuService menuService) : base(daseDBContext)
        {
            this.menuService = menuService;
        }

        public async Task<Role?> FindRoleByName(string name)
        {
            return await dbSet.SingleOrDefaultAsync(role => role.RoleName == name);
        }
        public IEnumerable<Role> FindMutilRolesByRoleName(string rolename)
        {
            return dbContext.Roles.Where(p => p.RoleName.Contains(rolename)).ToArray();
        }


        public async Task DeleteRoleById(int id)
        {
            var count = await dbSet.Where(role => role.Id == id).ExecuteDeleteAsync() > 0;
            if (!count)
            {
                throw new NotFoundException($"The roles id is {id} not found!");
            }
        }

        public IEnumerable<Role> ListRoles()
        {
            return dbSet.AsNoTracking()
                             .Include(role => role.SysMenus.OrderBy(menu => menu.OrderNum))
                             .OrderBy(role => role.Id)
                             .ToList();
        }

        public async Task UpadteMenusByRoleId(int roleId, List<int> menuIds)
        {
            var role = await dbSet.Include(role => role.SysMenus).SingleAsync(role => role.Id == roleId);

            List<SysMenu> sysMenus = new List<SysMenu>();

            if (menuIds == null)
            {
                role.SysMenus = new List<SysMenu>();
                await dbContext.SaveChangesAsync();
                return;
            }
            foreach (var menId in menuIds)
            {
                sysMenus.Add(await menuService.FindAsync(menId));
            }
            role.SysMenus = sysMenus;
            await dbContext.SaveChangesAsync();
        }
    }
}