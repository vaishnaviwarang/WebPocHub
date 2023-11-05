using WebPOCHub.Models;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace WebPOCHub.API.Jwt
{
    public class TokenManager : ITokenManager
    {
        private readonly SymmetricSecurityKey _key;
        public TokenManager(IConfiguration config)
        {
            _key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(config["WebPOCHubJWT:Secret"]));
        }
        public string GenerateToken(User model,string roleName)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Name,model.Email),
                new Claim(ClaimTypes.Role,roleName)
            };
            var credentials = new SigningCredentials(
                _key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddMinutes(60),
                SigningCredentials = credentials
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token); //serializes token to string format.
        }
    }
}
