using BattleRap.API.Auth.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BattleRap.API.Auth
{
    public class GenerateToken
    {
        private readonly TokenConfiguration _configuration;

        public GenerateToken(TokenConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateJwt(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration.Secret));
            var tokenHandler = new JwtSecurityTokenHandler();

            var nameClaim = new Claim(ClaimTypes.Name, user.Username);
            var roleClaim = new Claim(ClaimTypes.Role, user.Role);
            var moduleClaim = new Claim("module", "Web III .net");
            var subClaim = new Claim("sub", "BattleRap.API");

            var claims = new List<Claim> { nameClaim, roleClaim, moduleClaim, subClaim };

            var jwtToken = new JwtSecurityToken(
                issuer: _configuration.Issuer,
                audience: _configuration.Audience,
                claims: claims,
                expires: DateTime.Now.AddHours(_configuration.ExpirationTimeInHours),
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature));

            return tokenHandler.WriteToken(jwtToken);
        }
    }
}
