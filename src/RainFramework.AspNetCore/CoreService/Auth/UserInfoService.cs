using AutoMapper;
using RainFramework.AspNetCore.Model.VO;
using RainFramework.Common.Base;
using RainFramework.Repository.DBContext;
using RainFramework.Repository.Entity;

namespace RainFramework.AspNetCore.CoreService.Auth
{
    internal class UserInfoService : CrudService<BaseDBContext, UserInfo>, IUserInfoService
    {
        private readonly IUserAuthService userAuthService;

        private readonly IMapper mapper;

        public UserInfoService(BaseDBContext daseDBContext, IUserAuthService userAuthService, IMapper mapper) : base(daseDBContext)
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