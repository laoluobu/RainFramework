﻿#nullable disable

using System.ComponentModel.DataAnnotations;
using RainFramework.Common.Base;

namespace WMS.Repository.Entity;

public class Role: EntityBase
{
    /// <summary>
    /// 主键id
    /// </summary>
    public int Id { get; set; }

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
    /// 创建时间
    /// </summary>
    public DateTime CreateTime { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    public DateTime? UpdateTime { get; set; }

    /// <summary>
    /// 用户
    /// </summary>
    public List<UserAuth> UserAuths { get; set; } = new();
}