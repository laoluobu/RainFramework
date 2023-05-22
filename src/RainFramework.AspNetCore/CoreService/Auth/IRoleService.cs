using RainFramework.Common.Base;
using RainFramework.Repository.Entity;

namespace RainFramework.AspNetCore.CoreService.Auth
{
    public interface IRoleService : ICrudService<Role>
    {
        Task<bool> DeleteRoleById(int id);

        Task<Role?> FindRoleByName(string name);

        IEnumerable<Role> FindMutilRolesByRoleName(string rolename);
    }
}