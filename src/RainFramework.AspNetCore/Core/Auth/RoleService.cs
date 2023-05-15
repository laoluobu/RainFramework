using Microsoft.EntityFrameworkCore;
using RainFramework.Common.Base;
using WMS.Repository.DBContext;
using WMS.Repository.Entity;

namespace RainFramework.AspNetCore.Core.Auth
{
    internal class RoleService : CrudService<MySqlContext, Role>, IRoleService
    {
        private readonly MySqlContext dbContext;

        public RoleService(MySqlContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Role?> FindRoleByName(string name)
        {
            return await dbContext.Roles.SingleOrDefaultAsync(role => role.RoleName == name);
        }
    }
}