using AutoMapper;
using RainFramework.AspNetCore.Model.VO;
using RainFramework.Dao;
using RainFramework.EFCore.Mysql.Base;
using RainFramework.Model.Entities;

namespace RainFramework.AspNetCore.CoreService.Auth
{
    internal class UserInfoService<TDbContext> : CrudService<RFDBContext, UserInfo>, IUserInfoService where TDbContext : RFDBContext
    {
        private readonly IUserAuthService userAuthService;

        private readonly IMapper mapper;

        public UserInfoService(TDbContext daseDBContext, IUserAuthService userAuthService, IMapper mapper) : base(daseDBContext)
        {
            this.userAuthService = userAuthService;
            this.mapper = mapper;
        }

        public async Task<UserInfoVO> FindUserInfoByUserId(int userId)
        {
            var userAuth = await userAuthService.FindUserAuthIncludeInfoById(userId);
            return mapper.Map<UserInfoVO>(userAuth);
        }
    }
}