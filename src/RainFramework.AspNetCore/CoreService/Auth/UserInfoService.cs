using Microsoft.EntityFrameworkCore;
using RainFramework.Common.Base;
using RainFramework.Common.CoreException;
using RainFramework.Repository.DBContext;
using RainFramework.Repository.Entity;

namespace RainFramework.AspNetCore.CoreService.Auth
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

        public async Task<bool> DeleteUserById(int id)
        {
            var count = await dbContext.UserInfos.Where(user => user.Id == id).ExecuteDeleteAsync() > 0;
            if (!count)
            {
                throw new NotFoundException($"The User id is {id} not found!");
            }
            return count;
        }
    }
}