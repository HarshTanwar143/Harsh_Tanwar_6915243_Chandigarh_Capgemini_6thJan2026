using CustomerService.DTOs;
using CustomerService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CustomerService.Controllers
{
    [ApiController]
    [Route("api/customers")]
    [Authorize] // every endpoint here needs a valid JWT issued by Identity Service
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerAppService _svc;

        public CustomersController(ICustomerAppService svc) { _svc = svc; }

        // POST /api/customers   -- only Admin can create customer profiles (FR-2)
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] CreateCustomerDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var (ok, msg, data) = await _svc.CreateAsync(dto);
            if (!ok) return BadRequest(new { message = msg });
            return CreatedAtAction(nameof(GetById), new { id = data!.Id }, new { message = msg, data });
        }

        // GET /api/customers/{id}
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var data = await _svc.GetByIdAsync(id);
            return data is null ? NotFound(new { message = "Customer not found." }) : Ok(data);
        }

        // GET /api/customers
        [HttpGet]
        [Authorize(Roles = "Admin,SupportStaff")]
        public async Task<IActionResult> GetAll() => Ok(await _svc.GetAllAsync());

        // PUT /api/customers/{id}
        [HttpPut("{id:guid}")]
        [Authorize(Roles = "Admin,Customer")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCustomerDto dto)
        {
            var (ok, msg, data) = await _svc.UpdateAsync(id, dto);
            if (!ok) return BadRequest(new { message = msg });
            return Ok(new { message = msg, data });
        }

        // DELETE /api/customers/{id}    -- soft delete = deactivate
        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Deactivate(Guid id)
        {
            var (ok, msg) = await _svc.DeactivateAsync(id);
            return ok ? Ok(new { message = msg }) : NotFound(new { message = msg });
        }

        // POST /api/customers/{id}/activate
        [HttpPost("{id:guid}/activate")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Activate(Guid id)
        {
            var (ok, msg) = await _svc.ActivateAsync(id);
            return ok ? Ok(new { message = msg }) : NotFound(new { message = msg });
        }

        // POST /api/customers/{id}/kyc/upload
        [HttpPost("{id:guid}/kyc/upload")]
        [Authorize(Roles = "Admin,Customer")]
        public async Task<IActionResult> UploadKyc(Guid id, [FromBody] KYCUploadDto dto)
        {
            var (ok, msg) = await _svc.UploadKycAsync(id, dto);
            return ok ? Ok(new { message = msg }) : BadRequest(new { message = msg });
        }

        // POST /api/customers/{id}/kyc/verify
        [HttpPost("{id:guid}/kyc/verify")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> VerifyKyc(Guid id)
        {
            var (ok, msg) = await _svc.VerifyKycAsync(id);
            return ok ? Ok(new { message = msg }) : BadRequest(new { message = msg });
        }
    }
}
