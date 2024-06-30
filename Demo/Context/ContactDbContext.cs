using Microsoft.EntityFrameworkCore;

namespace Demo.Context
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Contact> Contacts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasData(
                new Contact { ContactId = 1, ContactName = "Test Test", ContactAddress = "Test", ContactPhoneNumber = "8511111111", ContactEmail = "Test@gmail.com"}
            );
        }
    }
}
