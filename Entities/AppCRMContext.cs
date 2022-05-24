using CRMApplication.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRMApplication.Entities
{
    public class AppCRMContext: DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<AddressType> AddressTypes { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=GIANGTON-PC;Database=CRMAPPLICATION;User Id=VSERVER0/giang.ton;password=;Trusted_Connection=True;");
        }
    }
}
