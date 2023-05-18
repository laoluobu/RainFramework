using RainFramework.Common.Base;
using RainFramework.Repository.Entity;

namespace RainFramework.AspNetCore.CoreService.Auth
{
    public interface IRoleService : ICrudService<Role>
    {
        Task<Role?> FindRoleByName(string name);
    }
}