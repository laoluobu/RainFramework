using Microsoft.EntityFrameworkCore;
using RainFramework.Repository.Entity;

namespace RainFramework.Repository.DBContext;

/// <summary>
/// 框架共用层DBContext
/// </summary>
public class BaseDBContext : DbContext
{
    public BaseDBContext(DbContextOptions<BaseDBContext> options) : base(options)
    {
    }

    public DbSet<Role> Roles { get; set; }

    public DbSet<UserAuth> UserAuths { get; set; }

    public DbSet<UserInfo> UserInfos { get; set; }

    public DbSet<SysMenu> SysMenus { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");
    }
}