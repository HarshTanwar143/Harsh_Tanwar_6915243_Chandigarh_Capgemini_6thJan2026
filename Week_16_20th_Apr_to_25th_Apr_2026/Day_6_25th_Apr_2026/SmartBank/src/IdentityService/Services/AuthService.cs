using IdentityService.Data;
using IdentityService.DTOs;
using IdentityService.Models;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;

namespace IdentityService.Services
{
    public class AuthService : IAuthService
    {
        private readonly IdentityDbContext _db;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _config;

        public AuthService(IdentityDbContext db, ITokenService tokenService, IConfiguration config)
        {
            _db = db;
            _tokenService = tokenService;
            _config = config;
        }

        public async Task<(bool, string, TokenResponseDto?)> RegisterAsync(RegisterDto dto)
        {
            // Reject duplicate email
            if (await _db.Users.AnyAsync(u => u.Email == dto.Email))
                return (false, "Email already registered.", null);

            var user = new User
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Mobile = dto.Mobile,
                // BCrypt salts internally and is industry-standard for password storage
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                IsActive = true
            };

            // Default role is Customer unless caller provided otherwise
            var roleName = string.IsNullOrWhiteSpace(dto.Role) ? "Customer" : dto.Role;
            var role = await _db.Roles.FirstOrDefaultAsync(r => r.RoleName == roleName);
            if (role is null)
                return (false, $"Role '{roleName}' does not exist.", null);

            user.UserRoles.Add(new UserRole { RoleId = role.Id, UserId = user.Id });

            _db.Users.Add(user);
            await _db.SaveChangesAsync();

            var tokens = await IssueTokensAsync(user);
            return (true, "Registered successfully.", tokens);
        }

        public async Task<(bool, string, TokenResponseDto?)> LoginAsync(LoginDto dto)
        {
            var user = await _db.Users
                .Include(u => u.UserRoles).ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.Email == dto.Email);

            if (user is null || !user.IsActive)
                return (false, "Invalid credentials.", null);

            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                return (false, "Invalid credentials.", null);

            var tokens = await IssueTokensAsync(user);
            return (true, "Login successful.", tokens);
        }

        public async Task<(bool, string, TokenResponseDto?)> RefreshAsync(RefreshTokenRequestDto dto)
        {
            // 1. Validate the (possibly expired) access token
            var principal = _tokenService.GetPrincipalFromExpiredToken(dto.AccessToken);
            if (principal is null)
                return (false, "Invalid access token.", null);

            var userIdString = principal.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
            if (!Guid.TryParse(userIdString, out var userId))
                return (false, "Invalid token payload.", null);

            // 2. Match the refresh token in DB
            var existing = await _db.RefreshTokens
                .Include(rt => rt.User).ThenInclude(u => u.UserRoles).ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(rt => rt.Token == dto.RefreshToken && rt.UserId == userId);

            if (existing is null || !existing.IsActive)
                return (false, "Refresh token invalid or expired.", null);

            // 3. Rotate: revoke the old refresh token and issue new ones
            existing.IsRevoked = true;
            var newTokens = await IssueTokensAsync(existing.User);
            await _db.SaveChangesAsync();

            return (true, "Token refreshed.", newTokens);
        }

        public async Task<(bool, string)> AssignRoleAsync(AssignRoleDto dto)
        {
            var user = await _db.Users.Include(u => u.UserRoles).FirstOrDefaultAsync(u => u.Id == dto.UserId);
            if (user is null) return (false, "User not found.");

            var role = await _db.Roles.FirstOrDefaultAsync(r => r.RoleName == dto.RoleName);
            if (role is null) return (false, "Role not found.");

            if (user.UserRoles.Any(ur => ur.RoleId == role.Id))
                return (false, "User already has this role.");

            user.UserRoles.Add(new UserRole { UserId = user.Id, RoleId = role.Id });
            await _db.SaveChangesAsync();

            return (true, $"Role '{dto.RoleName}' assigned.");
        }

        public async Task<(bool, string)> RevokeRefreshTokenAsync(string refreshToken)
        {
            var token = await _db.RefreshTokens.FirstOrDefaultAsync(rt => rt.Token == refreshToken);
            if (token is null) return (false, "Token not found.");
            token.IsRevoked = true;
            await _db.SaveChangesAsync();
            return (true, "Token revoked.");
        }

        // ---- private helper ----
        private async Task<TokenResponseDto> IssueTokensAsync(User user)
        {
            var roles = user.UserRoles.Select(ur => ur.Role.RoleName).ToList();

            var accessToken = _tokenService.GenerateAccessToken(user, roles, out var expiresAt);
            var refreshTokenString = _tokenService.GenerateRefreshToken();

            var refreshDays = int.Parse(_config["Jwt:RefreshTokenDays"] ?? "7");
            var refresh = new RefreshToken
            {
                Token = refreshTokenString,
                ExpiresAt = DateTime.UtcNow.AddDays(refreshDays),
                UserId = user.Id
            };
            _db.RefreshTokens.Add(refresh);
            await _db.SaveChangesAsync();

            return new TokenResponseDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshTokenString,
                ExpiresAt = expiresAt,
                FullName = user.FullName,
                Email = user.Email,
                Roles = roles
            };
        }
    }
}
