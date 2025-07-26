using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using HexaCommerce.Application.Configuration;
using HexaCommerce.Application.DTOs.Auth;
using HexaCommerce.Application.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace HexaCommerce.Infrastructure.Services
{
    public class JwtService : IJwtService
    {
        private readonly JwtSettings _jwtSettings;
        private readonly SigningCredentials _signingCredentials;
        private readonly TokenValidationParameters _tokenValidationParameters;

        public JwtService(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
            
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            _signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            
            _tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = key,
                ValidateIssuer = true,
                ValidIssuer = _jwtSettings.Issuer,
                ValidateAudience = true,
                ValidAudience = _jwtSettings.Audience,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
        }

        public async Task<string> GenerateAccessTokenAsync(UserDto user)
        {
            var claims = await GetUserClaimsAsync(user);
            
            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.AccessTokenExpirationMinutes),
                signingCredentials: _signingCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<string> GenerateRefreshTokenAsync()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return await Task.FromResult(Convert.ToBase64String(randomNumber));
        }

        public async Task<ClaimsPrincipal> GetPrincipalFromExpiredTokenAsync(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            
            try
            {
                var principal = tokenHandler.ValidateToken(token, _tokenValidationParameters, out var validatedToken);
                
                if (validatedToken is JwtSecurityToken jwtSecurityToken)
                {
                    if (jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                    {
                        return await Task.FromResult(principal);
                    }
                }
            }
            catch
            {
                // Token validation failed
            }

            return await Task.FromResult<ClaimsPrincipal>(null);
        }

        public async Task<bool> ValidateTokenAsync(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                tokenHandler.ValidateToken(token, _tokenValidationParameters, out var validatedToken);
                return await Task.FromResult(true);
            }
            catch
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<DateTime> GetTokenExpirationAsync(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);
            return await Task.FromResult(jwtToken.ValidTo);
        }

        public async Task<IEnumerable<Claim>> GetUserClaimsAsync(UserDto user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim("FirstName", user.FirstName),
                new Claim("LastName", user.LastName),
                new Claim("FullName", user.FullName),
                new Claim(ClaimTypes.MobilePhone, user.PhoneNumber ?? ""),
                new Claim("EmailConfirmed", user.EmailConfirmed.ToString()),
                new Claim("TwoFactorEnabled", user.TwoFactorEnabled.ToString())
            };

            // Add roles
            if (user.Roles != null)
            {
                foreach (var role in user.Roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }
            }

            // Add permissions
            if (user.Permissions != null)
            {
                foreach (var permission in user.Permissions)
                {
                    claims.Add(new Claim("Permission", permission));
                }
            }

            return await Task.FromResult(claims);
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(string userId)
        {
            // For simplicity, using a simple token generation
            // In production, you might want to use a more secure approach
            var token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            return await Task.FromResult(token);
        }

        public async Task<string> GeneratePasswordResetTokenAsync(string userId)
        {
            // For simplicity, using a simple token generation
            // In production, you might want to use a more secure approach
            var token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            return await Task.FromResult(token);
        }

        public async Task<bool> ValidateEmailConfirmationTokenAsync(string userId, string token)
        {
            // In production, you would validate against stored tokens
            return await Task.FromResult(!string.IsNullOrEmpty(token));
        }

        public async Task<bool> ValidatePasswordResetTokenAsync(string userId, string token)
        {
            // In production, you would validate against stored tokens
            return await Task.FromResult(!string.IsNullOrEmpty(token));
        }
    }
} 