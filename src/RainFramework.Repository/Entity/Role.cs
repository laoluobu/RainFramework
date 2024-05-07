#nullable disable

using System.ComponentModel.DataAnnotations;
using RainFramework.EFCore.Base;

namespace RainFramework.Repository.Entity;

public class Role : EntityBase
{

    /// <summary>
    /// 角色名
    /// </summary>
    [MaxLength(50)]
    public string RoleName { get; set; }

    /// <summary>
    /// 是否禁用  0否 1是
    /// </summary>
    public bool IsDisable { get; set; }

    /// <summary>
    /// 用户
    /// </summary>
    public List<UserAuth> UserAuths { get; set; } = new();


    /// <summary>
    /// 用户
    /// </summary>
    public List<SysMenu> SysMenus { get; set; } = new();
}