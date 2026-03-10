using Microsoft.EntityFrameworkCore;

namespace EfCoreCodeBooks.Models
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {
        }

        public DbSet<BookModel> Books { get; set; }
    }
}