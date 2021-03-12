namespace Persistence.Models
{
    public class Class
    {
        public int ClassId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public bool IsActive { get; set; }
    }
}