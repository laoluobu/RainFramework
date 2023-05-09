using Microsoft.Extensions.DependencyInjection;
using WMS.Models.VO;

namespace RainFramework.AspNetCore.Core.Auth
{
    public interface IUserAuthServices
    {
        Task<string> LoginService(UserVO userVO);
    }
}