using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Models;

namespace Persistence.ModelConfig
{
    public class AccountDetailsConfig : IEntityTypeConfiguration<AccountDetails>
    {
        public void Configure(EntityTypeBuilder<AccountDetails> builder)
        {
            builder.ToTable("AccountDetails")
                .HasKey(account => account.AccountId);

            builder.Property(account => account.IsActive)
                .IsRequired()
                .HasDefaultValue(false);
        }
    }
}