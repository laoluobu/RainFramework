using RainFramework.AspNetCore.Moudel.VO;
using RainFramework.Common.Base;
using RainFramework.Repository.Entity;

namespace RainFramework.AspNetCore.CoreService.Auth
{
    public interface IMenuService : ICrudService<SysMenu>
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
        Task<IEnumerable<SysMenu>> FindEenuByRoleName(string RoleName);

        /// <summary>
        /// 获取多角色角色可用菜单
        /// </summary>
        /// <param name="RoleNames"></param>
        /// <returns></returns>
        Task<IEnumerable<SysMenu>?> FindEenuByRoleNames(IEnumerable<string> RoleNames);

        /// <summary>
        /// 获取所有菜单
        /// </summary>
        /// <returns></returns>
        IEnumerable<MenuVO> ListMenus();
    }
}