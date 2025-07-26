using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using HexaCommerce.Application.DTOs.Auth;

namespace HexaCommerce.Application.Interfaces
{
    public interface IJwtService
    {
        Task<string> GenerateAccessTokenAsync(UserDto user);
        Task<string> GenerateRefreshTokenAsync();
        Task<ClaimsPrincipal> GetPrincipalFromExpiredTokenAsync(string token);
        Task<bool> ValidateTokenAsync(string token);
        Task<DateTime> GetTokenExpirationAsync(string token);
        Task<IEnumerable<Claim>> GetUserClaimsAsync(UserDto user);
        Task<string> GenerateEmailConfirmationTokenAsync(string userId);
        Task<string> GeneratePasswordResetTokenAsync(string userId);
        Task<bool> ValidateEmailConfirmationTokenAsync(string userId, string token);
        Task<bool> ValidatePasswordResetTokenAsync(string userId, string token);
    }
} 