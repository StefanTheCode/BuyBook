using BuyBook.Application.Interfaces;
using BuyBook.Domain;
using Microsoft.EntityFrameworkCore;

namespace BuyBook.PersistenceSQL
{
    public class BuyBookDbContext : DbContext, IBuyBookDbContext
    {
        public BuyBookDbContext(DbContextOptions<BuyBookDbContext> options) : base(options) { }

        public DbSet<Book> Book { get; set; }
        public DbSet<Rating> Rating { get; set; }
        public DbSet<User> User { get; set; }

        public int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}