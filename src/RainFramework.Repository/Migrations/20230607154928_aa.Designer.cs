﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RainFramework.Repository.DBContext;

#nullable disable

namespace RainFramework.Repository.Migrations
{
    [DbContext(typeof(RFDBContext))]
    [Migration("20230607154928_aa")]
    partial class aa
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8mb4");

            modelBuilder.Entity("RainFramework.Repository.Entity.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDisable")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("RoleName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("UpdateTime")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("RoleName")
                        .IsUnique();

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("RainFramework.Repository.Entity.SysMenu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Component")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("Hidden")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Meta")
                        .IsRequired()
                        .HasColumnType("json");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("OrderNum")
                        .HasColumnType("int");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("SysMenus");
                });

            modelBuilder.Entity("RainFramework.Repository.Entity.UserAuth", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)");

                    b.Property<string>("IpAddress")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("LastLoginTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("UpdateTime")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("UserAuths");
                });

            modelBuilder.Entity("RainFramework.Repository.Entity.UserInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("IsDisable")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Nickname")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("UpdateTime")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UserAuthId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserAuthId")
                        .IsUnique();

                    b.ToTable("UserInfos");
                });

            modelBuilder.Entity("RoleSysMenu", b =>
                {
                    b.Property<int>("RolesId")
                        .HasColumnType("int");

                    b.Property<int>("SysMenusId")
                        .HasColumnType("int");

                    b.HasKey("RolesId", "SysMenusId");

                    b.HasIndex("SysMenusId");

                    b.ToTable("RoleSysMenu");
                });

            modelBuilder.Entity("RoleUserAuth", b =>
                {
                    b.Property<int>("RolesId")
                        .HasColumnType("int");

                    b.Property<int>("UserAuthsId")
                        .HasColumnType("int");

                    b.HasKey("RolesId", "UserAuthsId");

                    b.HasIndex("UserAuthsId");

                    b.ToTable("RoleUserAuth");
                });

            modelBuilder.Entity("RainFramework.Repository.Entity.SysMenu", b =>
                {
                    b.HasOne("RainFramework.Repository.Entity.SysMenu", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("RainFramework.Repository.Entity.UserInfo", b =>
                {
                    b.HasOne("RainFramework.Repository.Entity.UserAuth", null)
                        .WithOne("UserInfo")
                        .HasForeignKey("RainFramework.Repository.Entity.UserInfo", "UserAuthId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RoleSysMenu", b =>
                {
                    b.HasOne("RainFramework.Repository.Entity.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RainFramework.Repository.Entity.SysMenu", null)
                        .WithMany()
                        .HasForeignKey("SysMenusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RoleUserAuth", b =>
                {
                    b.HasOne("RainFramework.Repository.Entity.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RainFramework.Repository.Entity.UserAuth", null)
                        .WithMany()
                        .HasForeignKey("UserAuthsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RainFramework.Repository.Entity.SysMenu", b =>
                {
                    b.Navigation("Children");
                });

            modelBuilder.Entity("RainFramework.Repository.Entity.UserAuth", b =>
                {
                    b.Navigation("UserInfo");
                });
#pragma warning restore 612, 618
        }
    }
}
