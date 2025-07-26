namespace HexaCommerce.Application.Configuration
{
    public class JwtSettings
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int AccessTokenExpirationMinutes { get; set; } = 60;
        public int RefreshTokenExpirationDays { get; set; } = 7;
        public int EmailConfirmationTokenExpirationHours { get; set; } = 24;
        public int PasswordResetTokenExpirationHours { get; set; } = 1;
    }
} 