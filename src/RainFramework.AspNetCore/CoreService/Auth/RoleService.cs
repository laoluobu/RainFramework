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
            return await dbSet.SingleOrDefaultAsync(role => role.RoleName == name);
        }


        public async Task DeleteRoleById(int id)
        {
            var count=await dbSet.Where(role => role.Id == id).ExecuteDeleteAsync()>0;
            if (!count)
            {
                throw new NotFoundException($"The roles id is {id} not found!");
            }
        }
    }
}