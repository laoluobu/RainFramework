using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using WMS.Models.DTO;
using WMS.Repository.Entity;

namespace WMS.Api.JWT
{
    public interface IJWTService
    {
        string CreateToken(List<Claim> claims);
        string CreateToken(UserAuth userAuth);
        SymmetricSecurityKey GeneralKey();
    }
}
