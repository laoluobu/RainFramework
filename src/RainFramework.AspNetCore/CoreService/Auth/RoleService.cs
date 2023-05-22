using Microsoft.EntityFrameworkCore;
using RainFramework.Common.Base;
using RainFramework.Common.CoreException;
using RainFramework.Repository.DBContext;
using RainFramework.Repository.Entity;
using System.Data;
using static RainFramework.Repository.DBContext.BaseDBContext;

namespace RainFramework.AspNetCore.CoreService.Auth
{
    internal class RoleService : CrudService<BaseDBContext, Role>, IRoleService
    {
        public RoleService(BaseDBContext daseDBContext) : base(daseDBContext)
        {
        }

        public async Task<Role?> FindRoleByName(string name)
        {
            return await dbContext.Roles.SingleOrDefaultAsync(role => role.RoleName == name);
        }
        public IEnumerable<Role> FindMutilRolesByRoleName(string rolename)
        {
            return dbContext.Roles.Where(p => p.RoleName.Contains(rolename)).ToArray();
        }


        public async Task<bool> DeleteRoleById(int id)
        {
            var count=await dbContext.Roles.Where(role => role.Id == id).ExecuteDeleteAsync()>0;
            if (!count)
            {
                throw new NotFoundException($"The roles id is {id} not found!");
            }
            return count;
        }
    }
}