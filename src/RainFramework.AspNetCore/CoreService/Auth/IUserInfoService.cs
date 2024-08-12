using RainFramework.AspNetCore.Model.VO;
using RainFramework.EFCore;
using RainFramework.Model.Entities;

namespace RainFramework.AspNetCore.CoreService.Auth
{
    public interface IUserInfoService : ICrudService<UserInfo>
    {
        Task<UserInfoVO> FindUserInfoByUserId(int userId);
    }
}
