using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Models;

namespace Persistence.ModelConfig
{
    public class LessonConfig : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.ToTable("Lessons")
                .HasKey(lesson => lesson.LessonId);

            builder.Property(lesson => lesson.Duration)
                .HasColumnType("decimal(18, 2)");
        }
    }
}