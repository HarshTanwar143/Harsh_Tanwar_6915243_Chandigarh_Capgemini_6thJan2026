using System.ComponentModel.DataAnnotations;

namespace IdentityService.Models
{
    public class RefreshToken
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Token { get; set; } = string.Empty; // long random base64 string

        public DateTime ExpiresAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public bool IsRevoked { get; set; } = false;

        // FK
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

        public bool IsActive => !IsRevoked && DateTime.UtcNow < ExpiresAt;
    }
}
