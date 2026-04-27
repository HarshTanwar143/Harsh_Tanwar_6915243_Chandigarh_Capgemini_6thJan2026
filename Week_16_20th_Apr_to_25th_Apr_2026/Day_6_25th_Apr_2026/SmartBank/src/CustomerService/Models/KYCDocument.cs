using System.ComponentModel.DataAnnotations;

namespace CustomerService.Models
{
    public enum KycDocumentType
    {
        PAN = 1,
        Aadhaar = 2,
        Passport = 3,
        DrivingLicense = 4,
        VoterId = 5
    }

    public class KYCDocument
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required] public KycDocumentType DocumentType { get; set; }

        [Required, MaxLength(50)]
        public string DocumentNumber { get; set; } = string.Empty;

        // For an academic project we just store the URL; in production this would be Azure Blob
        [MaxLength(500)] public string? FileUrl { get; set; }

        public bool IsVerified { get; set; } = false;
        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
        public DateTime? VerifiedAt { get; set; }

        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
    }
}
