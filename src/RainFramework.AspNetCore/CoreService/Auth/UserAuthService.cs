using Microsoft.EntityFrameworkCore;
using RainFramework.Common.Base;
using RainFramework.Common.Moudel.VO;
using RainFramework.Repository.DBContext;
using RainFramework.Repository.Entity;

namespace RainFramework.AspNetCore.CoreService.Auth
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
            var userAuth = await dbSet.AsNoTracking()
                                      .Include(user => user.Roles)
                                      .SingleOrDefaultAsync(user => user.Username == userVO.Username && user.Password == userVO.Password);
            if (userAuth == null)
            {
                return string.Empty;
            }
            return jWTService.CreateToken(userAuth);
        }
    }
}