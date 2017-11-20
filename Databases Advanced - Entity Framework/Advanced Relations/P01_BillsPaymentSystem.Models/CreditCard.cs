using System;

namespace P01_BillsPaymentSystem.Models
{
    public class CreditCard
    {
        public int CreditCardId { get; set; }
        public DateTime ExpirationDate { get; set; }
        public decimal Limit { get; set; }
        public decimal MoneyOwned { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public decimal LimitLeft
        {
            get
            {
                return Limit - MoneyOwned;
            }
        }
    }
}
