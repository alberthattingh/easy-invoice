using System;
using Persistence.Models;

namespace EasyInvoice.DTOs
{
    public class LessonDTO
    {
        public int? LessonId { get; set; }
        public int? UserId { get; set; }
        public int? StudentId { get; set; }
        public StudentDTO Student { get; set; }
        public decimal? Duration { get; set; }
        public DateTime? LessonDate { get; set; }

        public LessonDTO(Lesson entity)
        {
            LessonId = entity.LessonId;
            UserId = entity.UserId;
            StudentId = entity.StudentId;
            Duration = entity.Duration;
            LessonDate = entity.LessonDate;

            if (entity.Student != null)
                Student = new StudentDTO(entity.Student);
        }
    }
}