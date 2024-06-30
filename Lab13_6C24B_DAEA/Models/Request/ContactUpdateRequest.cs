using System.ComponentModel.DataAnnotations;

namespace Lab13_6C24B_DAEA.Models.Request
{
    public class ContactUpdateRequest
    {
        [Key]
        public int IdStudent { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
