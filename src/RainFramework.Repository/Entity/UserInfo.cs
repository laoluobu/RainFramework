#nullable disable


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RainFramework.Common.Base;

namespace RainFramework.Repository.Entity;

public class UserInfo : EntityBase
{
    /// <summary>
    /// 用户ID
    /// </summary>
    public int Id { get; set; }


    public int UserAuthId { get; set; }

    /// <summary>
    /// 邮箱
    /// </summary>
    [MaxLength(50)]
    public string Email { get; set; }

    /// <summary>
    /// 用户昵称
    /// </summary>
    [MaxLength(50)]
    public string Nickname { get; set; }

    /// <summary>
    /// 是否禁用
    /// </summary>
    public bool IsDisable { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime CreateTime { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    public DateTime? UpdateTime { get; set; }
}