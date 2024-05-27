using AutoMapper;
using RainFramework.AspNetCore.Model.VO;
using RainFramework.Model.Entities;

namespace RainFramework.AspNetCore.Mapper
{
    internal class CoreProfile : Profile
    {
        public CoreProfile()
        {
            CreateMap<Menu, MenuVO>();
            CreateMap<MenuVO, Menu>();
            CreateMap<UserAuth, UserInfoVO>();
        }
    }
}