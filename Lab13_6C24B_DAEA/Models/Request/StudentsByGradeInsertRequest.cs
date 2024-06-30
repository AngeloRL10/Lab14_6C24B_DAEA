using System.ComponentModel.DataAnnotations;

namespace Lab13_6C24B_DAEA.Models.Request
{
    public class StudentsByGradeInsertRequest
    {
        [Key]
        public int IdGrade { get; set; }
        public List<StudentInsertRequest> Students { get; set; }
    }
}
