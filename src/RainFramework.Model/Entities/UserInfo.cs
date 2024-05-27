using System.ComponentModel.DataAnnotations;

namespace RainFramework.Model.Entities;

public class UserInfo : EntityBase
{

    public int UserAuthId { get; set; }

    /// <summary>
    /// 邮箱
    /// </summary>
    [MaxLength(50)]
    public string? Email { get; set; } = null!;

    /// <summary>
    /// 用户昵称
    /// </summary>
    [MaxLength(50)]
    public string Nickname { get; set; } = null!;

    /// <summary>
    /// 是否禁用
    /// </summary>
    public bool IsDisable { get; set; }
}