namespace IdentityService.Models
{
    // Many-to-many join table: a user can hold multiple roles
    public class UserRole
    {
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

        public Guid RoleId { get; set; }
        public Role Role { get; set; } = null!;
    }
}
