﻿using AutoMapper;
using RainFramework.AspNetCore.Model.VO;
using RainFramework.Repository.Entity;

namespace RainFramework.AspNetCore.Mapper
{
    internal class CoreProfile : Profile
    {
        public CoreProfile()
        {
            CreateMap<SysMenu, MenuVO>();
            CreateMap<MenuVO, SysMenu>();
            CreateMap<UserAuth, UserInfoVO>();
        }
    }
}