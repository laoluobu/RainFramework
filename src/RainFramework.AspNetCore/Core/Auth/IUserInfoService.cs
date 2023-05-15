using RainFramework.Common.Base;
using RainFramework.Repository.Entity;

namespace RainFramework.AspNetCore.Core.Auth
{
    public interface IUserInfoService : ICrudService<UserInfo>
    {
        Task<UserInfo?> FindUserInfoByUserId(int userId);
    }
}
