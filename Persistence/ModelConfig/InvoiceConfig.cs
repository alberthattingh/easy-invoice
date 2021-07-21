using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Models;

namespace Persistence.ModelConfig
{
    public class InvoiceConfig : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("Invoices")
                .HasKey(invoice => invoice.InvoiceId);

            builder.Property(invoice => invoice.Total)
                .HasColumnType("decimal(18, 2)");

            builder.Ignore(invoice => invoice.Lessons);

            builder.Property(invoice => invoice.CreatedDate)
                .IsRequired();
        }
    }
}