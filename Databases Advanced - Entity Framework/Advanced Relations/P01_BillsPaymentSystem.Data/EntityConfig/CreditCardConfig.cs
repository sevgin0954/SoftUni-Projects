using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_BillsPaymentSystem.Models;

namespace P01_BillsPaymentSystem.Data.EntityConfig
{
    class CreditCardConfig : IEntityTypeConfiguration<CreditCard>
    {
        public void Configure(EntityTypeBuilder<CreditCard> creditCard)
        {
            creditCard.HasKey(cd => cd.CreditCardId);

            creditCard.Ignore(cd => cd.LimitLeft);
        }
    }
}
