using System;

namespace Persistence.Models
{
    public class Lesson
    {
        public int? LessonId { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        public int? StudentId { get; set; }
        public Student Student { get; set; }
        public decimal? Duration { get; set; }
        public DateTime? LessonDate { get; set; }
    }
}