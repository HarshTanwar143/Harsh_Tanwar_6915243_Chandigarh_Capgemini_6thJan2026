using System.ComponentModel.DataAnnotations;

namespace CustomerService.Models
{
    public class Customer
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        // FK back to the User created in Identity Service (loose coupling, just a Guid)
        public Guid UserId { get; set; }

        [Required, MaxLength(100)] public string FullName { get; set; } = string.Empty;
        [Required] public DateTime DateOfBirth { get; set; }

        [Required, MaxLength(15)]  public string Mobile { get; set; } = string.Empty;
        [Required, EmailAddress, MaxLength(150)] public string Email { get; set; } = string.Empty;

        [Required, MaxLength(10)]  public string PAN { get; set; } = string.Empty;
        [Required, MaxLength(12)]  public string Aadhaar { get; set; } = string.Empty;

        public bool IsKycVerified { get; set; } = false;
        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        // Navigation
        public Address? Address { get; set; }
        public ICollection<KYCDocument> KycDocuments { get; set; } = new List<KYCDocument>();
    }
}
