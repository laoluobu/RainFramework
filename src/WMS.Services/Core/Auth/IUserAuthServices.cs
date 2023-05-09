using Microsoft.Extensions.DependencyInjection;
using WMS.Models.VO;

namespace WMS.Services.Core.Auth
{
    public interface IUserAuthServices
    {
        Task<string> LoginService(UserVO userVO);
    }
}