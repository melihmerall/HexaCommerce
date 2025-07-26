using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace HexaCommerce.Infrastructure.Services
{
    public interface ILicenseValidationService
    {
        Task<bool> ValidateLicenseAsync();
        Task ReportViolationAsync(string violationType, string details);
        Task<bool> IsProductionEnvironmentAsync();
        Task<string> GetEnvironmentInfoAsync();
    }

    public class LicenseValidationService : ILicenseValidationService
    {
        private readonly ILogger<LicenseValidationService> _logger;
        private readonly HttpClient _httpClient;
        private readonly string _licenseValidationUrl = "https://api.hexacommerce.com/license/validate";
        private readonly string _violationReportUrl = "https://api.hexacommerce.com/license/violation";

        public LicenseValidationService(ILogger<LicenseValidationService> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task<bool> ValidateLicenseAsync()
        {
            try
            {
                var environmentInfo = await GetEnvironmentInfoAsync();
                var isProduction = await IsProductionEnvironmentAsync();

                if (isProduction)
                {
                    _logger.LogWarning("LICENSE VIOLATION DETECTED: Production deployment without valid license");
                    await ReportViolationAsync("ProductionDeployment", environmentInfo);
                    return false;
                }

                // For development/educational use, allow but log
                _logger.LogInformation("License validation passed for development use");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during license validation");
                return false;
            }
        }

        public async Task ReportViolationAsync(string violationType, string details)
        {
            try
            {
                var violation = new
                {
                    ViolationType = violationType,
                    Details = details,
                    Timestamp = DateTime.UtcNow,
                    Environment = await GetEnvironmentInfoAsync(),
                    MachineName = Environment.MachineName,
                    UserName = Environment.UserName,
                    OSVersion = Environment.OSVersion.ToString(),
                    ProcessorCount = Environment.ProcessorCount
                };

                var json = JsonConvert.SerializeObject(violation);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(_violationReportUrl, content);
                
                if (response.IsSuccessStatusCode)
                {
                    _logger.LogWarning("License violation reported successfully");
                }
                else
                {
                    _logger.LogError("Failed to report license violation: {StatusCode}", response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error reporting license violation");
            }
        }

        public async Task<bool> IsProductionEnvironmentAsync()
        {
            var environmentInfo = await GetEnvironmentInfoAsync();
            
            // Check for production indicators
            var productionIndicators = new[]
            {
                "production",
                "prod",
                "live",
                "hosting",
                "azure",
                "aws",
                "gcp",
                "digitalocean",
                "heroku",
                "vercel",
                "netlify"
            };

            foreach (var indicator in productionIndicators)
            {
                if (environmentInfo.ToLower().Contains(indicator))
                {
                    return true;
                }
            }

            return false;
        }

        public async Task<string> GetEnvironmentInfoAsync()
        {
            var info = new StringBuilder();
            
            // Environment variables
            info.AppendLine($"ASPNETCORE_ENVIRONMENT: {Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}");
            info.AppendLine($"DOTNET_ENVIRONMENT: {Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")}");
            info.AppendLine($"WEBSITE_HOSTNAME: {Environment.GetEnvironmentVariable("WEBSITE_HOSTNAME")}");
            info.AppendLine($"WEBSITE_SITE_NAME: {Environment.GetEnvironmentVariable("WEBSITE_SITE_NAME")}");
            
            // Machine info
            info.AppendLine($"MachineName: {Environment.MachineName}");
            info.AppendLine($"UserName: {Environment.UserName}");
            info.AppendLine($"OSVersion: {Environment.OSVersion}");
            info.AppendLine($"ProcessorCount: {Environment.ProcessorCount}");
            
            // Current directory and working directory
            info.AppendLine($"CurrentDirectory: {Environment.CurrentDirectory}");
            info.AppendLine($"WorkingSet: {Environment.WorkingSet}");

            return await Task.FromResult(info.ToString());
        }
    }
} 