﻿using Microsoft.EntityFrameworkCore;
using RainFramework.Common.Base;
using WMS.Repository.DBContext;
using WMS.Repository.Entity;

namespace RainFramework.AspNetCore.Core.Auth
{
    internal class UserInfoService : CrudService<MySqlContext,UserInfo>, IUserInfoService
    {
        private readonly MySqlContext dbContext;
        public UserInfoService(MySqlContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<UserInfo?> FindUserInfoByUserId(int userId)
        {
          return await dbContext.UserInfos.SingleOrDefaultAsync(o => o.UserAuthId == userId);
        }
    }
}
