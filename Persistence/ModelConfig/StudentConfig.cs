using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Models;

namespace Persistence.ModelConfig
{
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students")
                .HasKey(student => student.StudentId);

            builder.Property(student => student.FeePayable)
                .HasColumnType("decimal(18, 2)");
        }
    }
}