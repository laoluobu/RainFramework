using Microsoft.EntityFrameworkCore;
using WMS.Api.JWT;
using WMS.Models.VO;
using WMS.Repository.WMSDB;

namespace WMS.Services.Core.Auth
{
    public class UserAuthServices : IUserAuthServices
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