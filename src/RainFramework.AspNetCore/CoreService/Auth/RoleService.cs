using Microsoft.EntityFrameworkCore;
using RainFramework.Common.Base;
using RainFramework.Common.CoreException;
using RainFramework.Repository.DBContext;
using RainFramework.Repository.Entity;
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


        public async Task<bool> DeleteRoleById(int id)
        {
            await dbContext.Roles.Where(role => role.Id == id).ExecuteDeleteAsync();
            var count = await dbContext.SaveChangesAsync() > 0;
            if (!count)
            {
                throw new NotFoundException($"The roles id is {id} not found!");
            }
            return count;
        }
    }
}