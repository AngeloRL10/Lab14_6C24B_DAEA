namespace Lab13_6C24B_DAEA.Models
{
    public class Enrollment
    {
        public int IdEnrollment { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime Date { get; set; }

        // Navigation properties
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
