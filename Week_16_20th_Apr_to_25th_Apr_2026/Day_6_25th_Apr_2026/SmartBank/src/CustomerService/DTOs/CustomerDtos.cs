using CustomerService.Models;
using System.ComponentModel.DataAnnotations;

namespace CustomerService.DTOs
{
    public class AddressDto
    {
        [Required] public string Line1 { get; set; } = string.Empty;
        public string? Line2 { get; set; }
        [Required] public string City { get; set; } = string.Empty;
        [Required] public string State { get; set; } = string.Empty;
        [Required] public string PinCode { get; set; } = string.Empty;
        public string Country { get; set; } = "India";
    }

    public class CreateCustomerDto
    {
        [Required] public Guid UserId { get; set; }   // from Identity Service

        [Required, MaxLength(100)] public string FullName { get; set; } = string.Empty;
        [Required] public DateTime DateOfBirth { get; set; }
        [Required, Phone] public string Mobile { get; set; } = string.Empty;
        [Required, EmailAddress] public string Email { get; set; } = string.Empty;

        [Required, RegularExpression(@"^[A-Z]{5}[0-9]{4}[A-Z]{1}$", ErrorMessage = "Invalid PAN format.")]
        public string PAN { get; set; } = string.Empty;

        [Required, RegularExpression(@"^\d{12}$", ErrorMessage = "Aadhaar must be 12 digits.")]
        public string Aadhaar { get; set; } = string.Empty;

        [Required] public AddressDto Address { get; set; } = new();
    }

    public class UpdateCustomerDto
    {
        [MaxLength(100)] public string? FullName { get; set; }
        [Phone] public string? Mobile { get; set; }
        [EmailAddress] public string? Email { get; set; }
        public AddressDto? Address { get; set; }
    }

    public class KYCUploadDto
    {
        [Required] public KycDocumentType DocumentType { get; set; }
        [Required] public string DocumentNumber { get; set; } = string.Empty;
        public string? FileUrl { get; set; }
    }

    public class CustomerResponseDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Mobile { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PAN { get; set; } = string.Empty;
        public string Aadhaar { get; set; } = string.Empty;
        public bool IsKycVerified { get; set; }
        public bool IsActive { get; set; }
        public AddressDto? Address { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
