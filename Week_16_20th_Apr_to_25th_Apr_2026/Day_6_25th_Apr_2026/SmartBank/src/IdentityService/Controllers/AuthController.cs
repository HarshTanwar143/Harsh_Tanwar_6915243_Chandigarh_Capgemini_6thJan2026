using IdentityService.DTOs;
using IdentityService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityService.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _auth;

        public AuthController(IAuthService auth)
        {
            _auth = auth;
        }

        // POST /api/auth/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var (ok, msg, data) = await _auth.RegisterAsync(dto);
            if (!ok) return BadRequest(new { message = msg });
            return Ok(new { message = msg, data });
        }

        // POST /api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var (ok, msg, data) = await _auth.LoginAsync(dto);
            if (!ok) return Unauthorized(new { message = msg });
            return Ok(new { message = msg, data });
        }

        // POST /api/auth/refresh
        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] RefreshTokenRequestDto dto)
        {
            var (ok, msg, data) = await _auth.RefreshAsync(dto);
            if (!ok) return BadRequest(new { message = msg });
            return Ok(new { message = msg, data });
        }

        // POST /api/auth/revoke   (logout)
        [HttpPost("revoke")]
        [Authorize]
        public async Task<IActionResult> Revoke([FromBody] string refreshToken)
        {
            var (ok, msg) = await _auth.RevokeRefreshTokenAsync(refreshToken);
            return ok ? Ok(new { message = msg }) : BadRequest(new { message = msg });
        }

        // POST /api/auth/assign-role  (Admin only)
        [HttpPost("assign-role")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AssignRole([FromBody] AssignRoleDto dto)
        {
            var (ok, msg) = await _auth.AssignRoleAsync(dto);
            return ok ? Ok(new { message = msg }) : BadRequest(new { message = msg });
        }

        // GET /api/auth/me   (returns current user info from token)
        [HttpGet("me")]
        [Authorize]
        public IActionResult Me()
        {
            var claims = User.Claims.Select(c => new { c.Type, c.Value });
            return Ok(claims);
        }
    }
}
