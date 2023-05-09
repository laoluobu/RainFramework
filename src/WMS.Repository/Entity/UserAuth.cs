#nullable disable

namespace WMS.Repository.Entity;

public class UserAuth
{
    public int Id { get; set; }

    /// <summary>
    /// 用户信息id
    /// </summary>
    public UserInfo UserInfo { get; set; }

    /// <summary>
    /// 用户名
    /// </summary>
    public string Username { get; set; }

    /// <summary>
    /// 密码
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// 用户登录ip
    /// </summary>
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
    public List<Role> Roles { get; set; }
}