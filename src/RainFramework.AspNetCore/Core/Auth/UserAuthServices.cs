using Microsoft.EntityFrameworkCore;
using WMS.Models.VO;
using WMS.Repository.DBContext;

namespace RainFramework.AspNetCore.Core.Auth
{
    internal class UserAuthServices : IUserAuthServices
    {
        private readonly WMSDBContext dbContext;
        private readonly IJWTService jWTService;

        public UserAuthServices(WMSDBContext dbContext, IJWTService jWTService)
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