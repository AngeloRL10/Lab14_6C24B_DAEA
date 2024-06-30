using System.ComponentModel.DataAnnotations;

namespace Lab13_6C24B_DAEA.Models.Request
{
    public class GradeDeleteRequest
    {
        [Key]
        public int IdGrade { get; set; }
    }
}
