using BuyBook.Domain;
using Microsoft.EntityFrameworkCore;

namespace BuyBook.PersistenceSQL
{
    public class BuyBookDbContext : DbContext
    {
        public BuyBookDbContext(DbContextOptions<BuyBookDbContext> options) : base(options) { }

        DbSet<Book> Book { get; set; }
        DbSet<Rating> Rating { get; set; }
        DbSet<Tag> Tag { get; set; }
        DbSet<BookTag> BookTag { get; set; }
    }
}