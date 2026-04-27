using IdentityService.DTOs;

namespace IdentityService.Services
{
    public interface IAuthService
    {
        Task<(bool Success, string Message, TokenResponseDto? Data)> RegisterAsync(RegisterDto dto);
        Task<(bool Success, string Message, TokenResponseDto? Data)> LoginAsync(LoginDto dto);
        Task<(bool Success, string Message, TokenResponseDto? Data)> RefreshAsync(RefreshTokenRequestDto dto);
        Task<(bool Success, string Message)> AssignRoleAsync(AssignRoleDto dto);
        Task<(bool Success, string Message)> RevokeRefreshTokenAsync(string refreshToken);
    }
}
