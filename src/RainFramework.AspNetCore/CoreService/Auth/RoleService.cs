using System.Data;
using Microsoft.EntityFrameworkCore;
using RainFramework.Common.Exceptions;
using RainFramework.Dao;
using RainFramework.EFCore.Mysql.Base;
using RainFramework.Model.Entities;

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
            return await dbSet.SingleOrDefaultAsync(role => role.Name == name);
        }
        public IEnumerable<Role> FindMutilRolesByRoleName(string rolename)
        {
            return dbContext.Roles.Where(p => p.Name.Contains(rolename)).ToArray();
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

            List<Menu> sysMenus = new List<Menu>();

            if (menuIds == null)
            {
                role.SysMenus = new List<Menu>();
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