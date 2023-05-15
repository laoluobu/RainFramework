using Microsoft.EntityFrameworkCore;
using RainFramework.Common.Base;
using RainFramework.Repository.DBContext;
using RainFramework.Repository.Entity;

namespace RainFramework.AspNetCore.Core.Auth
{
    internal class UserInfoService : CrudService<BaseDBContext, UserInfo>, IUserInfoService
    {
        public UserInfoService(BaseDBContext daseDBContext) : base(daseDBContext)
        {
        }

        public async Task<UserInfo?> FindUserInfoByUserId(int userId)
        {
            return await dbContext.UserInfos.SingleOrDefaultAsync(o => o.UserAuthId == userId);
        }
    }
}