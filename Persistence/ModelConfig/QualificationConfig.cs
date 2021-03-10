using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Models;

namespace Persistence.ModelConfig
{
    public class QualificationConfig : IEntityTypeConfiguration<Qualification>
    {
        public void Configure(EntityTypeBuilder<Qualification> builder)
        {
            builder.ToTable("Qualifications")
                .HasKey(q => q.QualificationId);

            builder.Property(q => q.QualificationDetails)
                .HasColumnName("Qualification");
        }
    }
}