using System.ComponentModel.DataAnnotations;

namespace Lab13_6C24B_DAEA.Models.Request
{
    public class CourseDeleteRequest
    {
        [Key]
        public int IdCourse { get; set; }
    }
}
