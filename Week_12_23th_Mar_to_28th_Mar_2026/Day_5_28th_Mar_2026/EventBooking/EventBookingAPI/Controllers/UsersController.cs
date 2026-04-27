using AutoMapper;
using EventBookingAPI.Data;
using EventBookingAPI.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventBookingAPI.Controllers
{
    [ApiController]
    [Route("api/users")]
    [Authorize(Roles = "Admin")]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public UsersController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _db.Users.Where(u => u.Role == "User").ToListAsync();
            return Ok(_mapper.Map<List<UserDto>>(users));
        }

        [HttpGet("registered")]
        public async Task<IActionResult> GetAllRegistered()
        {
            var bookings = await _db.Bookings
                .Include(b => b.User)
                .Include(b => b.Event)
                .ToListAsync();

            var result = bookings.Select(b => new
            {
                UserId = b.User.Id,
                UserName = b.User.FullName,
                UserEmail = b.User.Email,
                EventId = b.Event.Id,
                EventTitle = b.Event.Title,
                EventDate = b.Event.Date,
                SeatsBooked = b.SeatsBooked,
                BookedAt = b.BookedAt
            });

            return Ok(result);
        }
    }
}
