using Lab13_6C24B_DAEA.Data;
using Lab13_6C24B_DAEA.Models.Request;
using Lab13_6C24B_DAEA.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab13_6C24B_DAEA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradesCustomController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GradesCustomController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("InsertGrade")]
        public void InsertGrade(GradeInsertRequest request)
        {
            Grade grade = new Grade();

            grade.Name = request.Name;
            grade.Description = request.Description;
            grade.Estado = 1;

            _context.Grades.Add(grade);
            _context.SaveChanges();
        }

        [HttpDelete("DeleteGrade")]
        public void DeleteGrade(GradeDeleteRequest request)
        {
            Grade grade = new Grade() { IdGrade = request.IdGrade };

            _context.Grades.Remove(grade);
            _context.SaveChanges();
        }

    }
}
