﻿using Microsoft.IdentityModel.Tokens;
using WMS.Api.Models.DTO;

namespace WMS.Api.JWT
{
    public interface IJWTService
    {
        string CreateToken(string subject);
        string CreateToken(UserDetailsDTO userDetailsDTO);
        SymmetricSecurityKey GeneralKey();
    }
}