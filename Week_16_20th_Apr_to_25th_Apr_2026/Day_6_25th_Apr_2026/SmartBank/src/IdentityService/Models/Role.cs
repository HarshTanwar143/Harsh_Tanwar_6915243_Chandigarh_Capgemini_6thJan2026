using System.ComponentModel.DataAnnotations;

namespace IdentityService.Models
{
    public class Role
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, MaxLength(50)]
        public string RoleName { get; set; } = string.Empty;
        // Allowed values seeded in DbContext: Admin, Customer, LoanOfficer, SupportStaff

        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
