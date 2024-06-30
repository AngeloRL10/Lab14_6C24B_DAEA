using Lab13_6C24B_DAEA.Data;
using Lab13_6C24B_DAEA.Models.Request;
using Lab13_6C24B_DAEA.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab13_6C24B_DAEA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsCustomController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentsCustomController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("InsertStudent")]
        public void InsertStudent(StudentInsertRequest request)
        {
            Student student = new Student();

            student.GradeId = request.GradeId;
            student.FirstName = request.FirstName;
            student.LastName = request.LastName;
            student.Phone = request.Phone;
            student.Email = request.Email;

            _context.Students.Add(student);
            _context.SaveChanges();
        }

        [HttpPut("UpdateContact")]
        public void UpdateContact(ContactUpdateRequest request)
        {
            Student student = _context.Students.Find(request.IdStudent);

            if (student != null)
            {
                student.Phone = request.Phone;
                student.Email = request.Email;

                _context.SaveChanges();
            }
        }

        [HttpPut("UpdatePersonal")]
        public void UpdatePersonal(PersonalUpdateRequest request)
        {
            Student student = _context.Students.Find(request.IdStudent);

            if (student != null)
            {
                student.FirstName = request.FirstName;
                student.LastName = request.LastName;

                _context.SaveChanges();
            }
        }

        [HttpPost("InsertStudentsByGrade")]
        public void InsertStudentsByGrade(StudentsByGradeInsertRequest request)
        {
            foreach (var studentRequest in request.Students)
            {
                Student student = new Student()
                {
                    GradeId = request.IdGrade,
                    FirstName = studentRequest.FirstName,
                    LastName = studentRequest.LastName,
                    Phone = studentRequest.Phone,
                    Email = studentRequest.Email
                };

                _context.Students.Add(student);
            }

            _context.SaveChanges();
        }

        [HttpDelete("DeleteCourses")]
        public void DeleteCourses(CoursesDeleteListRequest request)
        {
            foreach (var idCourse in request.IdCourses)
            {
                Course course = _context.Courses.Find(idCourse);
                if (course != null)
                {
                    _context.Courses.Remove(course);
                }
            }

            _context.SaveChanges();
        }

        [HttpPost("Enroll")]
        public void Enroll(EnrollmentRequest request)
        {
            Student student = _context.Students.Find(request.IdStudent);

            if (student != null)
            {
                foreach (var idCourse in request.IdCourses)
                {
                    Course course = _context.Courses.Find(idCourse);

                    if (course != null)
                    {
                        Enrollment enrollment = new Enrollment()
                        {
                            StudentId = request.IdStudent,
                            CourseId = idCourse,
                            Date = DateTime.Now
                        };

                        _context.Enrollments.Add(enrollment);
                    }
                }

                _context.SaveChanges();
            }
        }


    }
}
