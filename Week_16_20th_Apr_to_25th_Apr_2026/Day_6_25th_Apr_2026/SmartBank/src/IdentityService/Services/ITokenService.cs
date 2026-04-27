using IdentityService.Models;
using System.Security.Claims;

namespace IdentityService.Services
{
    public interface ITokenService
    {
        string GenerateAccessToken(User user, IEnumerable<string> roles, out DateTime expiresAt);
        string GenerateRefreshToken();
        ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
    }
}
