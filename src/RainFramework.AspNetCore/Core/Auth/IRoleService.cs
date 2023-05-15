using RainFramework.Common.Base;
using WMS.Repository.Entity;

namespace RainFramework.AspNetCore.Core.Auth
{
    public interface IRoleService : ICrudService<Role>
    {
        Task<Role?> FindRoleByName(string name);
    }
}