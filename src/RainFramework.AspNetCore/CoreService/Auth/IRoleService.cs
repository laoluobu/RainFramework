using RainFramework.EFCore;
using RainFramework.Model.Entities;

namespace RainFramework.AspNetCore.CoreService.Auth
{
    public interface IRoleService : ICrudService<Role>
    {
        Task DeleteRoleById(int id);

        Task<Role?> FindRoleByName(string name);

        IEnumerable<Role> FindMutilRolesByRoleName(string rolename);
        IEnumerable<Role> ListRoles();
        Task UpadteMenusByRoleId(int id, List<int> menus);
    }
}