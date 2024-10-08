﻿using System.ComponentModel.DataAnnotations;
using RainFramework.Entities.Abstractions;

namespace RainFramework.Model.Entities;

/// <summary>
/// 
/// </summary>
public class UserAuth : EntityBase
{

    /// <summary>
    /// 用户信息
    /// </summary>
    public UserInfo? UserInfo { get; set; }

    /// <summary>
    /// 用户名
    /// </summary>
    [MaxLength(50)]
    public string Username { get; set; } = null!;

    /// <summary>
    /// 密码
    /// </summary>
    [MaxLength(100)]
    public string Password { get; set; } = null!;

    /// <summary>
    /// 用户登录ip
    /// </summary>
    [MaxLength(50)]
    public string? IpAddress { get; set; }

    /// <summary>
    /// 上次登录时间
    /// </summary>
    public DateTime? LastLoginTime { get; set; }

    /// <summary>
    /// 角色
    /// </summary>
    public List<Role> Roles { get; set; } = new();
}