using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Models;

namespace Persistence.ModelConfig
{
    public class StudentsPerInvoiceConfig : IEntityTypeConfiguration<StudentsPerInvoice>
    {
        public void Configure(EntityTypeBuilder<StudentsPerInvoice> builder)
        {
            builder.ToTable("StudentsPerInvoice")
                .HasKey(invoice => invoice.StudentGroupId);
        }
    }
}