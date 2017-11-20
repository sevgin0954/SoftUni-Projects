using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_BillsPaymentSystem.Models;

namespace P01_BillsPaymentSystem.Data.EntityConfig
{
    class BankAccountConfig : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> bankAccount)
        {
            bankAccount.HasKey(ba => ba.BankAccountId);

            bankAccount.Property(ba => ba.BankName)
                .IsRequired()
                .HasMaxLength(50);

            bankAccount.Property(ba => ba.SwiftCode)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(20);
        }
    }
}
