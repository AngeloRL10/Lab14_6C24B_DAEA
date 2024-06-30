using System.ComponentModel.DataAnnotations;

namespace Lab13_6C24B_DAEA.Models
{
    public class Grade
    {
        [Key]
        public int IdGrade { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Estado { get; set; } = 1;

        // Navigation property
        public ICollection<Student> Students { get; set; }
    }
}
