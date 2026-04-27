using AutoMapper;
using EventBookingAPI.Data;
using EventBookingAPI.DTOs;
using EventBookingAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventBookingAPI.Controllers
{
    [ApiController]
    [Route("api/events")]
    public class EventsController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public EventsController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var events = await _db.Events.ToListAsync();
            return Ok(_mapper.Map<List<EventDto>>(events));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var evt = await _db.Events.FindAsync(id);
            if (evt == null)
                return NotFound();

            return Ok(_mapper.Map<EventDto>(evt));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] CreateEventDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (dto.Date <= DateTime.UtcNow)
                return BadRequest(new { message = "Event date must be in the future." });

            var evt = _mapper.Map<Event>(dto);
            _db.Events.Add(evt);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = evt.Id }, _mapper.Map<EventDto>(evt));
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateEventDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var evt = await _db.Events.FindAsync(id);
            if (evt == null)
                return NotFound();

            _mapper.Map(dto, evt);
            await _db.SaveChangesAsync();

            return Ok(_mapper.Map<EventDto>(evt));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var evt = await _db.Events.FindAsync(id);
            if (evt == null)
                return NotFound();

            _db.Events.Remove(evt);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}
