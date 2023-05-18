using RainFramework.Common.Base;
using RainFramework.Common.Moudel.VO;
using RainFramework.Repository.Entity;

namespace RainFramework.AspNetCore.CoreService.Auth
{
    public interface IUserAuthService : ICrudService<UserAuth>
    {
        Task<string> LoginService(UserVO userVO);
    }
}