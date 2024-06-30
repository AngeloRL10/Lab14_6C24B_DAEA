using System.ComponentModel.DataAnnotations;

namespace Lab13_6C24B_DAEA.Models
{
    public class Course
    {
        [Key]
        public int IdCourse { get; set; }
        public string Name { get; set; }
        public int Credit { get; set; }
        public int Estado { get; set; } = 1;

        // Navigation property
        public ICollection<Enrollment> Enrollments { get; set; }

    }
}
