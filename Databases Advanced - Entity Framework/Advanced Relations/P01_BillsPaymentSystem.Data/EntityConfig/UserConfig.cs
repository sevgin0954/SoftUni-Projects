using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_BillsPaymentSystem.Models;

namespace P01_BillsPaymentSystem.Data.EntityConfig
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> user)
        {
            user.HasKey(u => u.UserId);

            user.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            user.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(50);

            user.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(80)
                .IsUnicode(false);

            user.Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(25)
                .IsUnicode(false);
        }
    }
}
