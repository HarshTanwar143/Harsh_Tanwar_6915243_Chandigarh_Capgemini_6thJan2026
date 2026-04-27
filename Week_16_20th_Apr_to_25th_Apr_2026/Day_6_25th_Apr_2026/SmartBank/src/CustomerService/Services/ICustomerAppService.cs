using CustomerService.DTOs;

namespace CustomerService.Services
{
    public interface ICustomerAppService
    {
        Task<(bool ok, string msg, CustomerResponseDto? data)> CreateAsync(CreateCustomerDto dto);
        Task<(bool ok, string msg, CustomerResponseDto? data)> UpdateAsync(Guid id, UpdateCustomerDto dto);
        Task<CustomerResponseDto?> GetByIdAsync(Guid id);
        Task<List<CustomerResponseDto>> GetAllAsync();
        Task<(bool ok, string msg)> DeactivateAsync(Guid id);
        Task<(bool ok, string msg)> ActivateAsync(Guid id);
        Task<(bool ok, string msg)> UploadKycAsync(Guid customerId, KYCUploadDto dto);
        Task<(bool ok, string msg)> VerifyKycAsync(Guid customerId);
    }
}
