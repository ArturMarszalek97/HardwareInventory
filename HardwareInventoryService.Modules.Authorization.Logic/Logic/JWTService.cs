using HardwareInventoryService.Models.Models.Authorization;
using HardwareInventoryService.Modules.Authorization.Logic.Interfaces;
using HardwareInventoryService.Modules.Authorization.Logic.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInventoryService.Modules.Authorization.Logic.Logic
{
    public class JWTService : IJWTService
    {
        public string SecretKey { get; set; }

        public JWTService()
        {
            this.SecretKey = string.Empty;
        }

        public JWTContainerModel CreateContainer(Session authData)
        {
            var jwtContainerModel = new JWTContainerModel
            {
                Claims = new[]
                {
                    new Claim(ClaimTypes.Name, authData.Username),
                }
            };
            return jwtContainerModel;
        }

        public string GenerateToken(IJWTContainerModel model)
        {
            if (model == null || model.Claims == null || model.Claims.Length == 0 || model.Claims.Any(x => string.IsNullOrEmpty(x.Value)))
                throw new ArgumentNullException("Arguments to create token are not valid.");

            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(model.Claims),
                Expires = DateTime.Now.AddMinutes(Convert.ToInt32(model.ExpireMinutes)),
                SigningCredentials = new SigningCredentials(this.GetSymmetricSecurityKey(), model.SecurityAlgorithm)
            };

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(securityToken);

            return token;
        }

        public IEnumerable<Claim> GetTokenClaims(string token)
        {
            if (string.IsNullOrEmpty(token))
                throw new ArgumentException("Given token is null or empty.");

            var tokenValidationParameters = this.GetTokenValidationParameters();

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            try
            {
                var tokenValid = jwtSecurityTokenHandler.ValidateToken(token, tokenValidationParameters, out var validatedToken);

                return tokenValid.Claims;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsTokenValid(string token)
        {
            try
            {
                if (string.IsNullOrEmpty(token))
                    throw new ArgumentException("Given token is null or empty.");

                var tokenValidationParameters = this.GetTokenValidationParameters();
                var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
                var tokenValid = jwtSecurityTokenHandler.ValidateToken(token, tokenValidationParameters, out var validatedToken);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private TokenValidationParameters GetTokenValidationParameters()
        {
            return new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                IssuerSigningKey = this.GetSymmetricSecurityKey()
            };
        }

        private SecurityKey GetSymmetricSecurityKey()
        {
            var symmetricKey = Convert.FromBase64String(this.SecretKey);
            return new SymmetricSecurityKey(symmetricKey);
        }
    }
}
