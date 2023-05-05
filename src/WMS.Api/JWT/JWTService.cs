using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using WMS.Api.Models.DTO;

namespace WMS.Api.JWT
{
    public class JWTService : IJWTService
    {
        public string createToken(UserDetailsDTO userDetailsDTO)
        {
            var aa = new UserDetailsDTO();
            return createToken(userDetailsDTO.Id.ToString());
        }

        public string createToken(string subject)
        {
            var token = new JsonWebTokenHandler().CreateToken(new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[] { new Claim("iss", "WMS"), new Claim("sub", subject) }),
                SigningCredentials = new SigningCredentials(GeneralKey(), SecurityAlgorithms.RsaSha256)
            });

            return token;
        }

        public SymmetricSecurityKey GeneralKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ssssssss"));
        }
    }
}