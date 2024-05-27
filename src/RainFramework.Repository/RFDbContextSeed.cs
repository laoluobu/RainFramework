using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RainFramework.Model.Constant;
using RainFramework.Model.Entities;

namespace RainFramework.Dao
{
    public class RFDbContextSeed
    {
        public static async Task SeedAsync<TDbContext>(TDbContext dbContext, ILogger logger, int retry = 0) where TDbContext : RFDBContext
        {
            var retryForAvailability = retry;
            try
            {
                if (dbContext.Database.IsMySql())
                {
                    dbContext.Database.Migrate();
                }
                if (!await dbContext.Roles.AnyAsync())
                {
                    await dbContext.Roles.AddRangeAsync(GetPreconfiguredRols());
                }
                if (!await dbContext.Menus.AnyAsync())
                {
                    await dbContext.Menus.AddRangeAsync(GetPreconfiguredUserMenu());
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability >= 10) throw;
                retryForAvailability++;
                logger.LogError(ex.Message);
                await SeedAsync(dbContext, logger, retryForAvailability);
                throw;
            }
        }

        static List<Role> GetPreconfiguredRols()
        {
            return new List<Role>()
            {
                new Role()
                {
                   Name= RoleConst.CUSTOMER
                },

                new Role()
                {
                   Name= RoleConst.ADMINISTRATOR,
                   UserAuths = new List<UserAuth>()
                   {
                      new UserAuth()
                      {
                          Username ="admin",
                          Password="e10adc3949ba59abbe56e057f20f883e",
                          UserInfo = new UserInfo() { Nickname = "系统管理员" }
                      }
                   }
                }


            };
        }

        static IEnumerable<Menu> GetPreconfiguredUserMenu()
        {
            return new List<Menu>()
            {
                new Menu()
                {
                    Path= "/authManager",
                    Name =  "authManager",
                    Component= "Layout",
                    Meta = new Meta(){Icon ="el-icon-lock" },
                    OrderNum =1,
                    Children  = new List<Menu>()
                    {
                        new Menu()
                        {
                            Path =  "/authManager/roleManager",
                            Name ="roleManager",
                            Component = "role/index.vue",
                            Meta = new Meta()
                            {
                                Icon ="el-icon-s-custom"
                            },
                            OrderNum =2,
                        },

                        new Menu()
                        {
                            Path =  "/authManager/menusManager",
                            Name ="menusManager",
                            Component = "menu/index.vue",
                            Meta = new Meta()
                            {
                                Icon ="el-icon-notebook-2"
                            },
                            OrderNum =2,
                        },

                        new Menu()
                        {
                            Path =  "/authManager/userManager",
                            Name ="userManager",
                            Component = "user/index.vue",
                            Meta = new Meta()
                            {
                                Icon ="iconfont icon-jiaoseguanli"
                            },
                            OrderNum =2,
                        },
                        new Menu()
                           {
                               Path =  "/userManager/profile",
                               Name ="profile",
                               Component = "profile/index.vue",
                               Meta = new Meta()
                               {
                                   Icon ="el-icon-s-custom"
                               },
                               OrderNum =2,
                            }
                    }
                }

            };
        }
    }
}
