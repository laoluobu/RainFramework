using Microsoft.EntityFrameworkCore;
using RainFramework.Model.Entities;

namespace RainFramework.Dao;

/// <summary>
/// 框架共用层DBContext
/// </summary>
public abstract class RFDBContext : DbContext
{
    public RFDBContext(DbContextOptions options) : base(options)
    {
    }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<UserAuth> UserAuths { get; set; }

    public virtual DbSet<UserInfo> UserInfos { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<AppConfig> AppConfigs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        //Roles Table
        modelBuilder.Entity<Role>(Roles =>
        {
            Roles.HasIndex(Role => Role.Name).IsUnique();
        });

        //UserAuth Table
        modelBuilder.Entity<UserAuth>(UserAuth =>
        {
            UserAuth.HasIndex(UserAuth => UserAuth.Username).IsUnique();
        });
    }
}