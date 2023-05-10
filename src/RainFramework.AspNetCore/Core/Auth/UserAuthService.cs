using Microsoft.EntityFrameworkCore;
using RainFramework.Common.Base;
using RainFramework.Common.Moudel.VO;
using WMS.Repository.DBContext;
using WMS.Repository.Entity;

namespace RainFramework.AspNetCore.Core.Auth
{
    internal class UserAuthService : CrudService<WMSDBContext, UserAuth>, IUserAuthService
    {
        private readonly WMSDBContext dbContext;
        private readonly IJWTService jWTService;

        public UserAuthService(WMSDBContext dbContext, IJWTService jWTService):base(dbContext)
        {
            this.dbContext = dbContext;
            this.jWTService = jWTService;
        }

        public async Task<string> LoginService(UserVO userVO)
        {
            var userAuth = await dbContext.UserAuths.SingleOrDefaultAsync(user => user.Username == userVO.Username && user.Password == userVO.Password);
            if (userAuth == null)
            {
                throw new ArgumentException("密码或者账户错误!");
            }
            return jWTService.CreateToken(userAuth);
        }
    }
}