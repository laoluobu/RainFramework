using Microsoft.Extensions.DependencyInjection;
using WMS.Models.VO;

namespace WMS.Services.Core.Auth
{
    public interface IUserAuthServices
    {
        string LoginService(UserVO userVO);
    }
}