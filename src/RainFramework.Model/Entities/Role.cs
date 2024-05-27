

using System.ComponentModel.DataAnnotations;

namespace RainFramework.Model.Entities;

public class Role : EntityBase
{

    /// <summary>
    /// 角色名
    /// </summary>
    [MaxLength(50)]
    public string Name { get; set; } = null!;

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
    public List<Menu> SysMenus { get; set; } = new();
}