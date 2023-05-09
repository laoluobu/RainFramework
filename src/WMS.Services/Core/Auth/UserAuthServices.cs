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

        public string LoginService(UserVO userVO)
        {
            var ss = dbContext.UserAuths.SingleOrDefault(user => user.Username == userVO.Username && user.Password == userVO.Password);
           
            if (ss == null)
            {
                throw new Exception("密码或者账户错误");
            }
            return jWTService.CreateToken("111");
        }
    }
}