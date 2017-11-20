using Microsoft.EntityFrameworkCore;
using P01_BillsPaymentSystem.Models;
using P01_BillsPaymentSystem.Data.EntityConfig;

namespace P01_BillsPaymentSystem.Data
{
    public class BillPaymentSystemContext : DbContext
    {
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                string connectionString =
                    "server=DESKTOP-4FKVBUR\\SQLEXPRESS;" +
                    "database=BillsPaymentSystemContext;" +
                    "integrated security=true";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BankAccountConfig());

            modelBuilder.ApplyConfiguration(new CreditCardConfig());

            modelBuilder.ApplyConfiguration(new PaymentMethodConfig());

            modelBuilder.ApplyConfiguration(new UserConfig());
        }
    }
}
