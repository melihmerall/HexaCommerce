using System.Threading.Tasks;

namespace HexaCommerce.Application.Interfaces
{
    public interface IPasswordService
    {
        Task<string> HashPasswordAsync(string password);
        Task<bool> VerifyPasswordAsync(string password, string hashedPassword);
        Task<bool> ValidatePasswordStrengthAsync(string password);
        Task<string> GenerateRandomPasswordAsync(int length = 12);
    }
} 