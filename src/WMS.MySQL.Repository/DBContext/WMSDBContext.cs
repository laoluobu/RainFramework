﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WMS.Repository.Entity;

namespace WMS.Repository.WMSDB;

public partial class WMSDBContext : DbContext
{
    public WMSDBContext(DbContextOptions<WMSDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<UserAuth> UserAuths { get; set; }

    public virtual DbSet<UserInfo> UserInfos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("role");

            entity.Property(e => e.Id)
                .HasComment("主键id")
                .HasColumnName("id");
            entity.Property(e => e.CreateTime)
                .HasComment("创建时间")
                .HasColumnType("datetime")
                .HasColumnName("create_time");
            entity.Property(e => e.IsDisable)
                .HasComment("是否禁用  0否 1是")
                .HasColumnName("is_disable");
            entity.Property(e => e.RoleName)
                .IsRequired()
                .HasMaxLength(20)
                .HasComment("角色名")
                .HasColumnName("role_name");
            entity.Property(e => e.UpdateTime)
                .HasComment("更新时间")
                .HasColumnType("datetime")
                .HasColumnName("update_time");
        });

        modelBuilder.Entity<UserAuth>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user_auth");

            entity.HasIndex(e => e.Username, "username").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateTime)
                .HasComment("创建时间")
                .HasColumnType("datetime")
                .HasColumnName("create_time");
            entity.Property(e => e.IpAddress)
                .HasMaxLength(50)
                .HasComment("用户登录ip")
                .HasColumnName("ip_address");
            entity.Property(e => e.LastLoginTime)
                .HasComment("上次登录时间")
                .HasColumnType("datetime")
                .HasColumnName("last_login_time");
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(100)
                .HasComment("密码")
                .HasColumnName("password");
            entity.Property(e => e.UpdateTime)
                .HasComment("更新时间")
                .HasColumnType("datetime")
                .HasColumnName("update_time");
            entity.Property(e => e.UserInfoId)
                .HasComment("用户信息id")
                .HasColumnName("user_info_id");
            entity.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("用户名")
                .HasColumnName("username");
        });

        modelBuilder.Entity<UserInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user_info");

            entity.Property(e => e.Id)
                .HasComment("用户ID")
                .HasColumnName("id");
            entity.Property(e => e.CreateTime)
                .HasComment("创建时间")
                .HasColumnType("datetime")
                .HasColumnName("create_time");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasComment("邮箱")
                .HasColumnName("email");
            entity.Property(e => e.IsDisable)
                .HasComment("是否禁用")
                .HasColumnName("is_disable");
            entity.Property(e => e.Nickname)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("用户昵称")
                .HasColumnName("nickname");
            entity.Property(e => e.UpdateTime)
                .HasComment("更新时间")
                .HasColumnType("datetime")
                .HasColumnName("update_time");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}