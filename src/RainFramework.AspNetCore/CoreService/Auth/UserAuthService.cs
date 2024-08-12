using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using RainFramework.Common.Exceptions;
using RainFramework.Dao;
using RainFramework.EFCore.Base;
using RainFramework.Model.Entities;
using RainFramework.Model.VO;

namespace RainFramework.AspNetCore.CoreService.Auth
{
    internal class UserAuthService<TDbContext> : CrudService<RFDBContext, UserAuth>, IUserAuthService where TDbContext : RFDBContext
    {
        private readonly IJWTService jWTService;
        private readonly IMapper mapper;
        private readonly IRoleService roleService;

        public UserAuthService(TDbContext daseDBContext, IJWTService jWTService, IMapper mapper
            , IRoleService roleService) : base(daseDBContext)
        {
            this.jWTService = jWTService;
            this.mapper = mapper;
            this.roleService = roleService;
        }

        public async Task<string> LoginService(UserVO userVO)
        {
            var userAuth = await dbSet.AsNoTracking()
                                      .Include(user => user.Roles)
                                      .FirstAsync(user => user.Username == userVO.Username && user.Password == userVO.Password);
            return jWTService.CreateToken(userAuth);
        }

        public IEnumerable<UserAuth> ListUsers()
        {
            return dbSet.AsNoTracking()
                             .Include(ui => ui.UserInfo)
                             .Include(ui => ui.Roles.OrderBy(role => role.Id))
                             .OrderBy(ui => ui.IpAddress)
                             .ToList();
        }

        public async Task DeleteUserById(int id)
        {
            await dbContext.UserAuths.Where(user => user.Id == id).ExecuteDeleteAsync();
        }

        public async Task PatchUserAuth(int id, JsonPatchDocument<UserAuth> patchDoc)
        {
            var userAuth = await dbSet.Include(userAuth => userAuth.UserInfo).SingleOrDefaultAsync(userAuth => userAuth.Id == id);
            if (userAuth == null)
            {
                return;
            }
            patchDoc.ApplyTo(userAuth);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpadteRoleByUserId(int id, List<int> roleIds)
        {
            var user = await dbSet.Include(userAuth => userAuth.Roles).SingleAsync(user => user.Id == id);

            List<Role> roles = new List<Role>();

            if (roleIds == null)
            {
                user.Roles = new List<Role>();
                await dbContext.SaveChangesAsync();
                return;
            }

            foreach (var RoleId in roleIds)
            {
                roles.Add(await roleService.FindAsync(RoleId));
            }
            user.Roles = roles;
            await dbContext.SaveChangesAsync();
        }

        public async Task<UserAuth> FindUserAuthIncludeInfoById(int id)
        {
            var user = await dbSet.Include(user => user.UserInfo).SingleOrDefaultAsync(user => user.Id == id);

            if (user == null)
            {
                throw new NotFoundException($"User id is {id} inexistence！");
            }
            return user;
        }

        public async Task UpdatePasswordById(int id, string password)
        {
            await dbSet.Where(user => user.Id == id)
                       .ExecuteUpdateAsync(userAuths => userAuths.SetProperty(user => user.Password, password));
        }
    }
}