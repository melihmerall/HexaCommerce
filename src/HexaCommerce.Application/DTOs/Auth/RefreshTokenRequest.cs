using System.ComponentModel.DataAnnotations;

namespace HexaCommerce.Application.DTOs.Auth
{
    public class RefreshTokenRequest
    {
        [Required]
        public string Token { get; set; }

        [Required]
        public string RefreshToken { get; set; }
    }
} 