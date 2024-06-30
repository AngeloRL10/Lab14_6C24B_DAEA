using System.ComponentModel.DataAnnotations;

namespace Lab13_6C24B_DAEA.Models.Request
{
    public class PersonalUpdateRequest
    {
        [Key]
        public int IdStudent { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
