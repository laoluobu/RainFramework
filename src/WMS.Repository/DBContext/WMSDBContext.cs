using Microsoft.EntityFrameworkCore;
using WMS.Repository.Entity;

namespace WMS.Repository.DBContext;

public class WMSDBContext : DbContext
{
    public WMSDBContext(DbContextOptions<WMSDBContext> options)
        : base(options)
    {
    }

    public DbSet<Role> Roles { get; set; }

    public DbSet<UserAuth> UserAuths { get; set; }

    public DbSet<UserInfo> UserInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //打印sql参数
        optionsBuilder.EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");
    }
}