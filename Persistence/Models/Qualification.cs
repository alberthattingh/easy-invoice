namespace Persistence.Models
{
    public class Qualification
    {
        public int QualificationId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string QualificationDetails { get; set; }
    }
}