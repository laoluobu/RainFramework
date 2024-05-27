using RainFramework.AspNetCore.Model.VO;
using RainFramework.EFCore.Mysql;
using RainFramework.Model.Entities;

namespace RainFramework.AspNetCore.CoreService.Auth
{
    public interface IMenuService : ICrudService<Menu>
    {
        /// <summary>
        /// 根据主键删除菜单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteMenuById(int id);

        /// <summary>
        /// 获取指定角色可用菜单
        /// </summary>
        /// <param name="RoleName"></param>
        /// <returns></returns>
        Task<List<Menu>> FindMenuByRoleName(string RoleName);

        /// <summary>
        /// 获取多角色角色可用菜单
        /// </summary>
        /// <param name="RoleNames"></param>
        /// <returns></returns>
        Task<IEnumerable<Menu>> FindMenuByRoleNames(IEnumerable<string> RoleNames);

        /// <summary>
        /// 获取所有菜单
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<MenuVO>> ListMenus();
    }
}