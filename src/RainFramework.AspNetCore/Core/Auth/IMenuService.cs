using RainFramework.Common.Base;
using RainFramework.Repository.Entity;


namespace RainFramework.AspNetCore.Core.Auth
{
    public interface IMenuService : ICrudService<SysMenu>
    {
        Task<IEnumerable<SysMenu>> FindEenuByRoleName(string RoleName);
        Task<IEnumerable<SysMenu>?> FindEenuByRoleNames(IEnumerable<string> RoleNames);
    }
}