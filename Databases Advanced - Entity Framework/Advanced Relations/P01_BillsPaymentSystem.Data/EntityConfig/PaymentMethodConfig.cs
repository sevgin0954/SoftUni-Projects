using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_BillsPaymentSystem.Models;

namespace P01_BillsPaymentSystem.Data.EntityConfig
{
    class PaymentMethodConfig : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> paymentMethod)
        {
            paymentMethod.HasIndex(pm => new { pm.Id, pm.UserId, pm.BankAccountId, pm.CreditCardId }).IsUnique();

            paymentMethod.HasOne(pm => pm.User)
                .WithMany(u => u.PaymentMethods)
                .HasForeignKey(pm => pm.UserId);

            paymentMethod.HasOne(pm => pm.BankAccount)
                .WithOne(bc => bc.PaymentMethod)
                .HasForeignKey<PaymentMethod>(pm => pm.BankAccountId);

            paymentMethod.HasOne(pm => pm.CreditCard)
                .WithOne(cc => cc.PaymentMethod)
                .HasForeignKey<PaymentMethod>(pm => pm.CreditCardId);
        }
    }
}
