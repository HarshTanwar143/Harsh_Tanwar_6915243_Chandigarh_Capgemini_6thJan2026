using AutoMapper;
using LearningPlatformAPI.Data;
using LearningPlatformAPI.DTOs;
using LearningPlatformAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace LearningPlatformAPI.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class CourseController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public CourseController(AppDbContext context, IMapper mapper, IMemoryCache cache)
        {
            _context = context;
            _mapper = mapper;
            _cache = cache;
        }

        [HttpGet("courses")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllCourses()
        {
            if (!_cache.TryGetValue("courses", out List<Course> courses))
            {
                courses = await _context.Courses.ToListAsync();
                _cache.Set("courses", courses, TimeSpan.FromMinutes(5));
            }

            return Ok(_mapper.Map<List<CourseDto>>(courses));
        }

        [HttpGet("courses/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var course = await _context.Courses
                .Include(c => c.Lessons)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (course == null)
                return NotFound(new { error = "Course not found" });

            return Ok(_mapper.Map<CourseDto>(course));
        }

        [HttpGet("courses/category/{name}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByCategory(string name)
        {
            var courses = await _context.Courses
                .Where(c => c.Category == name)
                .ToListAsync();

            return Ok(_mapper.Map<List<CourseDto>>(courses));
        }

        [HttpPost("courses")]
        [Authorize(Roles = "Instructor,Admin")]
        public async Task<IActionResult> CreateCourse(CourseDto dto)
        {
            if (string.IsNullOrEmpty(dto.Title))
                return BadRequest(new { error = "Title is required" });

            var course = _mapper.Map<Course>(dto);

            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            return Ok(_mapper.Map<CourseDto>(course));
        }

        [HttpPost("courses/{id}/lessons")]
        [Authorize(Roles = "Instructor,Admin")]
        public async Task<IActionResult> AddLesson(int id, LessonDto dto)
        {
            var course = await _context.Courses.FindAsync(id);

            if (course == null)
                return NotFound(new { error = "Course not found" });

            var lesson = _mapper.Map<Lesson>(dto);
            lesson.CourseId = id;

            _context.Lessons.Add(lesson);
            await _context.SaveChangesAsync();

            return Ok(_mapper.Map<LessonDto>(lesson));
        }

        [HttpPost("enroll")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> Enroll([FromQuery] int userId, [FromQuery] int courseId)
        {
            var userExists = await _context.Users.AnyAsync(u => u.Id == userId);
            var courseExists = await _context.Courses.AnyAsync(c => c.Id == courseId);

            if (!userExists || !courseExists)
                return BadRequest(new { error = "Invalid user or course" });

            var exists = await _context.Enrollments
                .AnyAsync(e => e.UserId == userId && e.CourseId == courseId);

            if (exists)
                return BadRequest(new { error = "Already enrolled" });

            var enrollment = new Enrollment
            {
                UserId = userId,
                CourseId = courseId
            };

            _context.Enrollments.Add(enrollment);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Enrolled successfully" });
        }
    }
}