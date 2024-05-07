using Microsoft.EntityFrameworkCore;
using RainFramework.Repository.Entity;

namespace RainFramework.Repository.DBContext;

/// <summary>
/// 框架共用层DBContext
/// </summary>
public class RFDBContext : DbContext
{
    public RFDBContext(DbContextOptions<RFDBContext> options) : base(options)
    {
    }

    public DbSet<Role> Roles { get; set; }

    public DbSet<UserAuth> UserAuths { get; set; }

    public DbSet<UserInfo> UserInfos { get; set; }

    public DbSet<SysMenu> SysMenus { get; set; }

    public DbSet<AppConfig> AppConfigs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        //Roles Table
        modelBuilder.Entity<Role>(Roles =>
        {
            Roles.HasIndex(Role => Role.RoleName).IsUnique();


            Roles.HasData(new Role() { Id = 2, RoleName = "Administrator", IsDisable = false },
                              new Role() { Id = 3, RoleName = "Customer", IsDisable = false });
        });

        //UserAuth Table
        modelBuilder.Entity<UserAuth>(UserAuth =>
        {
            UserAuth.HasIndex(UserAuth => UserAuth.Username).IsUnique();
            UserAuth.HasData(new UserAuth()
            {
                Id = 20,
                UserInfo = new UserInfo()
                {
                    Id = 1,
                    Email = "admin@email",
                    Nickname = "系统管理员",
                    IsDisable = false,
                },
                Roles = new List<Role>() 
            });
        });
    }
}