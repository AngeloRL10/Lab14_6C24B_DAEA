using Lab13_6C24B_DAEA.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab13_6C24B_DAEA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetStudents(string searchTerm)
        {
            if (_context.Students == null)
            {
                return NotFound();
            }

            var students = await _context.Students
                .Where(s => s.FirstName.Contains(searchTerm) || s.LastName.Contains(searchTerm) || s.Email.Contains(searchTerm))
                .OrderByDescending(s => s.LastName)
                .ToListAsync();

            return Ok(students);
        }

        [HttpGet("searchByNameAndGrade")]
        public async Task<IActionResult> GetStudentsByNameAndGrade(string name, string grade)
        {
            if (_context.Students == null || _context.Grades == null)
            {
                return NotFound();
            }

            var students = await _context.Students
                .Include(s => s.Grade)
                .Where(s => s.FirstName.Contains(name) && s.Grade.Name.Contains(grade))
                .OrderByDescending(s => s.Grade.Name)
                .ToListAsync();

            return Ok(students);
        }

        [HttpGet("searchByCourse")]
        public async Task<IActionResult> GetEnrolledStudentsByCourse(string courseName)
        {
            if (_context.Enrollments == null || _context.Students == null || _context.Courses == null)
            {
                return NotFound();
            }

            var enrollments = await _context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .Where(e => e.Course.Name.Contains(courseName))
                .OrderBy(e => e.Course.Name)
                .ThenBy(e => e.Student.LastName)
                .ToListAsync();

            var result = enrollments.Select(e => new
            {
                e.Student,
                e.Course,
                e.Date
            });

            return Ok(result);
        }

        [HttpGet("searchByGrade")]
        public async Task<IActionResult> GetEnrolledStudentsByGrade(string gradeName)
        {
            if (_context.Enrollments == null || _context.Students == null || _context.Courses == null || _context.Grades == null)
            {
                return NotFound();
            }

            var enrollments = await _context.Enrollments
                .Include(e => e.Student)
                .ThenInclude(s => s.Grade)
                .Include(e => e.Course)
                .Where(e => e.Student.Grade.Name.Contains(gradeName))
                .OrderBy(e => e.Course.Name)
                .ThenBy(e => e.Student.LastName)
                .ToListAsync();

            var result = enrollments.Select(e => new
            {
                e.Student,
                e.Course,
                e.Date
            });

            return Ok(result);
        }

    }
}
