using Prospectos.Models;
using Microsoft.IdentityModel.Tokens;
using Prospectos.Services.Interfaces;
using System.Text;
using System.Collections.Generic;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Principal;
using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace Prospectos.Services
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _ssKey;
        public TokenService(IConfiguration config)
        {
            _ssKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Token"]));
        }
        public string CreateToken(SignIn sign)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, sign.username)
            };


            var credentials = new SigningCredentials(_ssKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = System.DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
 
        }

        public bool ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = GetValidationParameters();

            SecurityToken validatedToken;
            IPrincipal principal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
            return true;
        }

        public string DecodeToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = tokenHandler.ReadJwtToken(token);
            var username = jwtSecurityToken.Claims.First(claim => claim.Type == "nameid").Value;


            return username;
        }

        private TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters()
            {
                ValidateLifetime = true, // Because there is no expiration in the generated token
                ValidateAudience = false, // Because there is no audiance in the generated token
                ValidateIssuer = false,   // Because there is no issuer in the generated token
                ValidIssuer = "Sample",
                ValidAudience = "Sample",
                IssuerSigningKey = _ssKey // The same key as the one that generate the token
            };
        }
    }
}
