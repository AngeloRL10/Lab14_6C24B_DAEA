using Lab13_6C24B_DAEA.Data;
using Lab13_6C24B_DAEA.Models;
using Lab13_6C24B_DAEA.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab13_6C24B_DAEA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesCustomController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CoursesCustomController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public void Insert(CourseInsertRequest request) 
        { 
            Course course = new Course();

            course.Name = request.Name;
            course.Credit = request.Credit;
            course.Estado = 1;

            _context.Courses.Add(course);
            _context.SaveChanges();
        }

        [HttpDelete]
        public void Delete(CourseDeleteRequest request)
        {
            Course course = new Course();

            course.IdCourse = request.IdCourse;

            _context.Courses.Remove(course);
            _context.SaveChanges();
        }
    }
}
