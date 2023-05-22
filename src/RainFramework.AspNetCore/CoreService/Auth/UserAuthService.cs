using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RainFramework.Common.Base;
using RainFramework.Common.Moudel.VO;
using RainFramework.Repository.DBContext;
using RainFramework.Repository.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RainFramework.Common.CoreException;

namespace RainFramework.AspNetCore.CoreService.Auth
{
    internal class UserAuthService : CrudService<BaseDBContext, UserAuth>, IUserAuthService
    {
        private readonly IJWTService jWTService;
        private readonly IMapper mapper;

        public UserAuthService(BaseDBContext daseDBContext, IJWTService jWTService, IMapper mapper) : base(daseDBContext)
        {
            this.jWTService = jWTService;
            this.mapper = mapper;
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
    }
}