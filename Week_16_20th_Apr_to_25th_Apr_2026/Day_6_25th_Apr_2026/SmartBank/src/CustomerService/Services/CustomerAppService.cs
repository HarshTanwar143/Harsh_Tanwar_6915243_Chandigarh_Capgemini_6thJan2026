using CustomerService.Data;
using CustomerService.DTOs;
using CustomerService.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerService.Services
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly CustomerDbContext _db;

        public CustomerAppService(CustomerDbContext db) { _db = db; }

        public async Task<(bool, string, CustomerResponseDto?)> CreateAsync(CreateCustomerDto dto)
        {
            // Reject duplicates on the unique business keys
            if (await _db.Customers.AnyAsync(c => c.PAN == dto.PAN))
                return (false, "PAN already exists.", null);
            if (await _db.Customers.AnyAsync(c => c.Aadhaar == dto.Aadhaar))
                return (false, "Aadhaar already exists.", null);
            if (await _db.Customers.AnyAsync(c => c.Email == dto.Email))
                return (false, "Email already exists.", null);
            if (await _db.Customers.AnyAsync(c => c.UserId == dto.UserId))
                return (false, "User already has a customer profile.", null);

            var customer = new Customer
            {
                UserId = dto.UserId,
                FullName = dto.FullName,
                DateOfBirth = dto.DateOfBirth,
                Mobile = dto.Mobile,
                Email = dto.Email,
                PAN = dto.PAN.ToUpper(),
                Aadhaar = dto.Aadhaar,
                Address = new Address
                {
                    Line1 = dto.Address.Line1,
                    Line2 = dto.Address.Line2,
                    City = dto.Address.City,
                    State = dto.Address.State,
                    PinCode = dto.Address.PinCode,
                    Country = dto.Address.Country
                }
            };

            _db.Customers.Add(customer);
            await _db.SaveChangesAsync();

            return (true, "Customer created.", ToDto(customer));
        }

        public async Task<(bool, string, CustomerResponseDto?)> UpdateAsync(Guid id, UpdateCustomerDto dto)
        {
            var customer = await _db.Customers.Include(c => c.Address).FirstOrDefaultAsync(c => c.Id == id);
            if (customer is null) return (false, "Customer not found.", null);

            if (!string.IsNullOrWhiteSpace(dto.FullName)) customer.FullName = dto.FullName;
            if (!string.IsNullOrWhiteSpace(dto.Mobile))   customer.Mobile = dto.Mobile;
            if (!string.IsNullOrWhiteSpace(dto.Email))    customer.Email = dto.Email;

            if (dto.Address is not null)
            {
                customer.Address ??= new Address { CustomerId = customer.Id };
                customer.Address.Line1 = dto.Address.Line1;
                customer.Address.Line2 = dto.Address.Line2;
                customer.Address.City = dto.Address.City;
                customer.Address.State = dto.Address.State;
                customer.Address.PinCode = dto.Address.PinCode;
                customer.Address.Country = dto.Address.Country;
            }

            customer.UpdatedAt = DateTime.UtcNow;
            await _db.SaveChangesAsync();

            return (true, "Customer updated.", ToDto(customer));
        }

        public async Task<CustomerResponseDto?> GetByIdAsync(Guid id)
        {
            var customer = await _db.Customers.Include(c => c.Address).FirstOrDefaultAsync(c => c.Id == id);
            return customer is null ? null : ToDto(customer);
        }

        public async Task<List<CustomerResponseDto>> GetAllAsync()
        {
            var list = await _db.Customers.Include(c => c.Address).AsNoTracking().ToListAsync();
            return list.Select(ToDto).ToList();
        }

        public async Task<(bool, string)> DeactivateAsync(Guid id)
        {
            var customer = await _db.Customers.FindAsync(id);
            if (customer is null) return (false, "Customer not found.");
            customer.IsActive = false;
            customer.UpdatedAt = DateTime.UtcNow;
            await _db.SaveChangesAsync();
            return (true, "Customer deactivated.");
        }

        public async Task<(bool, string)> ActivateAsync(Guid id)
        {
            var customer = await _db.Customers.FindAsync(id);
            if (customer is null) return (false, "Customer not found.");
            customer.IsActive = true;
            customer.UpdatedAt = DateTime.UtcNow;
            await _db.SaveChangesAsync();
            return (true, "Customer activated.");
        }

        public async Task<(bool, string)> UploadKycAsync(Guid customerId, KYCUploadDto dto)
        {
            var customer = await _db.Customers.FindAsync(customerId);
            if (customer is null) return (false, "Customer not found.");

            var doc = new KYCDocument
            {
                CustomerId = customerId,
                DocumentType = dto.DocumentType,
                DocumentNumber = dto.DocumentNumber,
                FileUrl = dto.FileUrl
            };
            _db.KYCDocuments.Add(doc);
            await _db.SaveChangesAsync();
            return (true, "KYC document uploaded.");
        }

        public async Task<(bool, string)> VerifyKycAsync(Guid customerId)
        {
            var customer = await _db.Customers
                .Include(c => c.KycDocuments)
                .FirstOrDefaultAsync(c => c.Id == customerId);
            if (customer is null) return (false, "Customer not found.");

            // Simple rule: must have at least PAN + Aadhaar uploaded
            var hasPan = customer.KycDocuments.Any(d => d.DocumentType == KycDocumentType.PAN);
            var hasAadhaar = customer.KycDocuments.Any(d => d.DocumentType == KycDocumentType.Aadhaar);
            if (!hasPan || !hasAadhaar) return (false, "Both PAN and Aadhaar documents are required for KYC.");

            foreach (var doc in customer.KycDocuments)
            {
                doc.IsVerified = true;
                doc.VerifiedAt = DateTime.UtcNow;
            }
            customer.IsKycVerified = true;
            customer.UpdatedAt = DateTime.UtcNow;
            await _db.SaveChangesAsync();

            return (true, "KYC verified successfully.");
        }

        // ---- mapping helper ----
        private static CustomerResponseDto ToDto(Customer c) => new()
        {
            Id = c.Id,
            UserId = c.UserId,
            FullName = c.FullName,
            DateOfBirth = c.DateOfBirth,
            Mobile = c.Mobile,
            Email = c.Email,
            PAN = c.PAN,
            Aadhaar = c.Aadhaar,
            IsKycVerified = c.IsKycVerified,
            IsActive = c.IsActive,
            CreatedAt = c.CreatedAt,
            Address = c.Address is null ? null : new AddressDto
            {
                Line1 = c.Address.Line1,
                Line2 = c.Address.Line2,
                City = c.Address.City,
                State = c.Address.State,
                PinCode = c.Address.PinCode,
                Country = c.Address.Country
            }
        };
    }
}
