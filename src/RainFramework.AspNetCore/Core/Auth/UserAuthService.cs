using Microsoft.EntityFrameworkCore;
using RainFramework.Common.Base;
using RainFramework.Common.Moudel.VO;
using RainFramework.Repository.DBContext;
using RainFramework.Repository.Entity;
using static RainFramework.Repository.DBContext.BaseDBContext;

namespace RainFramework.AspNetCore.Core.Auth
{
    internal class UserAuthService : CrudService<BaseDBContext, UserAuth>, IUserAuthService
    {
        private readonly IJWTService jWTService;

        public UserAuthService(BaseDBContext daseDBContext, IJWTService jWTService) : base(daseDBContext)
        {
            this.jWTService = jWTService;
        }

        public async Task<string> LoginService(UserVO userVO)
        {
            var userAuth = await dbContext.UserAuths.Include(user => user.Roles).SingleOrDefaultAsync(user => user.Username == userVO.Username && user.Password == userVO.Password);
            if (userAuth == null)
            {
                throw new ArgumentException("密码或者账户错误!");
            }
            return jWTService.CreateToken(userAuth);
        }
    }
}