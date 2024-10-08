﻿using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using RainFramework.Model.Entities;

namespace RainFramework.AspNetCore.CoreService.Auth
{
    internal class JWTService : IJWTService
    {
        public string CreateToken(UserAuth userAuth)
        {
            var claims = new List<Claim>()
            {
                new Claim("iss", "WMS"),
                new Claim(ClaimTypes.NameIdentifier, userAuth.Id.ToString()),
                new Claim(ClaimTypes.Name, userAuth.Username),
            };

            foreach (var role in userAuth.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Name));
            }
            return CreateToken(claims);
        }

        public string CreateToken(List<Claim> claims)
        {
            var token = new JsonWebTokenHandler().CreateToken(new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims, "MyJWT"),
                SigningCredentials = new SigningCredentials(GeneralKey(), SecurityAlgorithms.HmacSha256),
                Expires = DateTime.Now.AddHours(2)
            });
            return token;
        }

        public SymmetricSecurityKey GeneralKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes("111111ssDDDDDD11111111111111asdasdd111111asdasdas"));
        }
    }
}