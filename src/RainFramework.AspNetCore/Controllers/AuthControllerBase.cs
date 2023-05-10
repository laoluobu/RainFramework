using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RainFramework.Common.Moudel.DTO;

namespace RainFramework.AspNetCore.Controllers
{
    public class AuthControllerBase : ControllerBase
    {
        public AuthUserDTO RequestUser => new ()
        {
            Username = User.Claims.FirstOrDefault(o => o.Type == ClaimTypes.Name)?.Value,
            Id = int.Parse(User.Claims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)!.Value),
        };
    }
}