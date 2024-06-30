using System.ComponentModel.DataAnnotations;

namespace Lab13_6C24B_DAEA.Models.Request
{
    public class EnrollmentRequest
    {
        [Key]
        public int IdStudent { get; set; }
        public List<int> IdCourses { get; set; }
    }
}
