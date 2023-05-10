using RainFramework.Common.Base;
using WMS.Repository.Entity;

namespace RainFramework.AspNetCore.Core.Auth
{
    public interface IUserInfoService : ICrudService<UserInfo>
    {
        Task<UserInfo?> FindUserInfoByUserId(int userId);
    }
}
