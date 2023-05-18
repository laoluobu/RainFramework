﻿using RainFramework.Common.Base;
using RainFramework.Repository.Entity;

namespace RainFramework.AspNetCore.CoreService.Auth
{
    public interface IUserInfoService : ICrudService<UserInfo>
    {
        Task<UserInfo?> FindUserInfoByUserId(int userId);
    }
}