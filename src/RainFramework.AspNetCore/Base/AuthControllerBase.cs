using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RainFramework.AspNetCore.Moudel.DTO;

namespace RainFramework.AspNetCore.Base
{
    [ApiController, Authorize]
    public class AuthControllerBase : ControllerBase
    {
        public AuthUserDTO RequestUser => new()
        {
            Username = User.Claims.FirstOrDefault(o => o.Type == ClaimTypes.Name)?.Value,
            Id = int.Parse(User.Claims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)!.Value),
            Roles = User.Claims.Where(o => o.Type == ClaimTypes.Role).Select(o => o.Value).ToList()
        };
    }
}