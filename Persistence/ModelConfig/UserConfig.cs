using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Models;

namespace Persistence.ModelConfig
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users")
                .HasKey(user => user.UserId);

            builder.Property(user => user.DefaultFee)
                .HasColumnType("decimal(18, 2)");

            builder.Property(user => user.LogoUrl)
                .HasMaxLength(500);
            
            builder.Property(user => user.LogoName)
                .HasMaxLength(255);

            builder.Ignore(user => user.LogoImage);
        }
    }
}