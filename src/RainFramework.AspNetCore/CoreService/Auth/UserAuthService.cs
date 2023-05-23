using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RainFramework.Common.Base;
using RainFramework.Common.Moudel.VO;
using RainFramework.Repository.DBContext;
using RainFramework.Repository.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RainFramework.Common.CoreException;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace RainFramework.AspNetCore.CoreService.Auth
{
    internal class UserAuthService : CrudService<BaseDBContext, UserAuth>, IUserAuthService
    {
        private readonly IJWTService jWTService;
        private readonly IMapper mapper;
        private readonly IRoleService roleService;

        public UserAuthService(BaseDBContext daseDBContext, IJWTService jWTService, IMapper mapper
            ,IRoleService roleService) : base(daseDBContext)
        {
            this.jWTService = jWTService;
            this.mapper = mapper;
            this.roleService = roleService;
        }

        public async Task<string> LoginService(UserVO userVO)
        {
            var userAuth = await dbSet.AsNoTracking()
                                      .Include(user => user.Roles)
                                      .SingleOrDefaultAsync(user => user.Username == userVO.Username && user.Password == userVO.Password);
            if (userAuth == null)
            {
                return string.Empty;
            }
            return jWTService.CreateToken(userAuth);
        }
        public IEnumerable<UserAuth> ListUsers()
        {
            return dbSet.AsNoTracking()
                             .Include(ui => ui.UserInfo)
                             .Include(ui=>ui.Roles.OrderBy(role=>role.Id))
                             .OrderBy(ui => ui.IpAddress)
                             .ToList();
        }

        public async Task<bool> DeleteUserById(int id)
        {
            var count = await dbContext.UserAuths.Where(user => user.Id == id).ExecuteDeleteAsync() > 0;
            if (!count)
            {
                throw new NotFoundException($"The User id is {id} not found!");
            }
            return count;
        }

        public async Task PatchUserAuth(int id, JsonPatchDocument<UserAuth> patchDoc)
        {
            var userAuth=await dbSet.Include(userAuth=>userAuth.UserInfo).Include(userAuth => userAuth.Roles).SingleOrDefaultAsync(userAuth=>userAuth.Id==id);
            if (userAuth == null)
            {
                return;
            }
            patchDoc.ApplyTo(userAuth);
            //await UpadteRole(id,userAuth.Roles);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpadteRole(int userId,List<Role> roles)
        {
            var user = await dbSet.SingleAsync(user=>user.Id== userId);
            //var role=await roleService.FindAsync(2);
            user.Roles = roles;
            await dbContext.SaveChangesAsync();
        }
    }
}