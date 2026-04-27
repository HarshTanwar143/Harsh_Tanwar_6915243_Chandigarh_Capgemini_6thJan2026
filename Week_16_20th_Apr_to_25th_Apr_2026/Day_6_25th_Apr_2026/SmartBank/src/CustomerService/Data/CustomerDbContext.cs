using CustomerService.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerService.Data
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options) { }

        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Address> Addresses => Set<Address>();
        public DbSet<KYCDocument> KYCDocuments => Set<KYCDocument>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Unique constraints required by banking domain
            modelBuilder.Entity<Customer>().HasIndex(c => c.PAN).IsUnique();
            modelBuilder.Entity<Customer>().HasIndex(c => c.Aadhaar).IsUnique();
            modelBuilder.Entity<Customer>().HasIndex(c => c.Email).IsUnique();
            modelBuilder.Entity<Customer>().HasIndex(c => c.UserId).IsUnique();

            // 1-to-1 Customer <-> Address
            modelBuilder.Entity<Customer>()
                .HasOne(c => c.Address)
                .WithOne(a => a.Customer)
                .HasForeignKey<Address>(a => a.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            // 1-to-many Customer -> KYCDocuments
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.KycDocuments)
                .WithOne(d => d.Customer)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
