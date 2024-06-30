using System.ComponentModel.DataAnnotations;

namespace Lab13_6C24B_DAEA.Models
{
    public class Student
    {
        [Key]
        public int IdStudent { get; set; }
        public int GradeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        // Navigation properties
        public Grade Grade { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
