using System.ComponentModel.DataAnnotations;
using RainFramework.Common.Base;

namespace WMS.Repository.Entity;

public class UserAuth : EntityBase
{
    public int Id { get; set; }


    public UserInfo? UserInfo { get; set; }

    /// <summary>
    /// 用户名
    /// </summary>
    [MaxLength(50)]
    public string Username { get; set; }

    /// <summary>
    /// 密码
    /// </summary>
    [MaxLength(100)]
    public string Password { get; set; }

    /// <summary>
    /// 用户登录ip
    /// </summary>
    [MaxLength(50)]
    public string IpAddress { get; set; }


    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreateTime { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    public DateTime? UpdateTime { get; set; }

    /// <summary>
    /// 上次登录时间
    /// </summary>
    public DateTime? LastLoginTime { get; set; }

    /// <summary>
    /// 角色
    /// </summary>
    public List<Role> Roles { get; set; } = new();
}