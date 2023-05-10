using RainFramework.Common.Base;
using RainFramework.Common.Moudel.VO;
using WMS.Repository.Entity;

namespace RainFramework.AspNetCore.Core.Auth
{
    public interface IUserAuthService : ICrudService<UserAuth>
    {
        Task<string> LoginService(UserVO userVO);
    }
}