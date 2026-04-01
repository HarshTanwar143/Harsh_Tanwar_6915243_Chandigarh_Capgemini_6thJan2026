using AutoMapper;
using EventBookingAPI.Data;
using EventBookingAPI.DTOs;
using EventBookingAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EventBookingAPI.Controllers
{
    [ApiController]
    [Route("api/bookings")]
    [Authorize]
    public class BookingsController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public BookingsController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        [HttpGet("my")]
        public async Task<IActionResult> GetMyBookings()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var bookings = await _db.Bookings
                .Include(b => b.Event)
                .Include(b => b.User)
                .Where(b => b.UserId == userId)
                .ToListAsync();

            return Ok(_mapper.Map<List<BookingDto>>(bookings));
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var bookings = await _db.Bookings
                .Include(b => b.Event)
                .Include(b => b.User)
                .ToListAsync();

            return Ok(_mapper.Map<List<BookingDto>>(bookings));
        }

        [HttpPost]
        public async Task<IActionResult> Book([FromBody] CreateBookingDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var evt = await _db.Events.FindAsync(dto.EventId);
            if (evt == null)
                return NotFound(new { message = "Event not found." });

            if (evt.AvailableSeats < dto.SeatsBooked)
                return BadRequest(new { message = $"Only {evt.AvailableSeats} seats are available." });

            var booking = new Booking
            {
                EventId = dto.EventId,
                UserId = userId,
                SeatsBooked = dto.SeatsBooked,
                BookedAt = DateTime.UtcNow
            };

            evt.AvailableSeats -= dto.SeatsBooked;

            _db.Bookings.Add(booking);
            await _db.SaveChangesAsync();

            await _db.Entry(booking).Reference(b => b.Event).LoadAsync();
            await _db.Entry(booking).Reference(b => b.User).LoadAsync();

            return Ok(_mapper.Map<BookingDto>(booking));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Cancel(int id)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var role = User.FindFirstValue(ClaimTypes.Role);

            var booking = await _db.Bookings.Include(b => b.Event).FirstOrDefaultAsync(b => b.Id == id);
            if (booking == null)
                return NotFound();

            if (booking.UserId != userId && role != "Admin")
                return Forbid();

            booking.Event.AvailableSeats += booking.SeatsBooked;
            _db.Bookings.Remove(booking);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}
