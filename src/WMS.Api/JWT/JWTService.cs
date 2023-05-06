using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using WMS.Api.Models.DTO;

namespace WMS.Api.JWT
{
    public class JWTService : IJWTService
    {
        public string CreateToken(UserDetailsDTO userDetailsDTO)
        {
            return CreateToken(userDetailsDTO.Id.ToString());
        }

        public string CreateToken(string subject)
        {
            var token = new JsonWebTokenHandler().CreateToken(new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[] { new Claim("iss", "WMS"), new Claim("sub", subject) }),
                SigningCredentials = new SigningCredentials(GeneralKey(), SecurityAlgorithms.HmacSha256),
                Expires = DateTime.Now.AddHours(2)
            });
            return token;
        }

        public SymmetricSecurityKey GeneralKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes("11111111111111111111111111"));
        }
    }
}