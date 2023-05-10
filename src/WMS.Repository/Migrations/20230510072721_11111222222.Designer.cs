﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WMS.Repository.DBContext;

#nullable disable

namespace WMS.Repository.Migrations
{
    [DbContext(typeof(WMSDBContext))]
    [Migration("20230510072721_11111222222")]
    partial class _11111222222
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

            modelBuilder.Entity("WMS.Repository.Entity.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDisable")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("RoleName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("WMS.Repository.Entity.UserAuth", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateTime")
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
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("UserAuths");
                });

            modelBuilder.Entity("WMS.Repository.Entity.UserInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateTime")
                        .ValueGeneratedOnAddOrUpdate()
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
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UserAuthId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserAuthId")
                        .IsUnique();

                    b.ToTable("UserInfos");
                });

            modelBuilder.Entity("RoleUserAuth", b =>
                {
                    b.HasOne("WMS.Repository.Entity.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WMS.Repository.Entity.UserAuth", null)
                        .WithMany()
                        .HasForeignKey("UserAuthsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WMS.Repository.Entity.UserInfo", b =>
                {
                    b.HasOne("WMS.Repository.Entity.UserAuth", null)
                        .WithOne("UserInfo")
                        .HasForeignKey("WMS.Repository.Entity.UserInfo", "UserAuthId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WMS.Repository.Entity.UserAuth", b =>
                {
                    b.Navigation("UserInfo");
                });
#pragma warning restore 612, 618
        }
    }
}
