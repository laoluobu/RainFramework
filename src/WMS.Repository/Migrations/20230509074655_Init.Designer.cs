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
    [Migration("20230509074655_Init")]
    partial class Init
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
                        .HasColumnType("longtext");

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
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("LastLoginTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("UserInfoId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("UserInfoId");

                    b.ToTable("UserAuths");
                });

            modelBuilder.Entity("WMS.Repository.Entity.UserInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDisable")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Nickname")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

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

            modelBuilder.Entity("WMS.Repository.Entity.UserAuth", b =>
                {
                    b.HasOne("WMS.Repository.Entity.UserInfo", "UserInfo")
                        .WithMany()
                        .HasForeignKey("UserInfoId");

                    b.Navigation("UserInfo");
                });
#pragma warning restore 612, 618
        }
    }
}