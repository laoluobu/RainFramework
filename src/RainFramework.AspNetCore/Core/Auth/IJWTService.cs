﻿using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using RainFramework.Repository.Entity;

namespace RainFramework.AspNetCore.Core.Auth
{
    public interface IJWTService
    {
        string CreateToken(List<Claim> claims);
        string CreateToken(UserAuth userAuth);
        SymmetricSecurityKey GeneralKey();
    }
}
