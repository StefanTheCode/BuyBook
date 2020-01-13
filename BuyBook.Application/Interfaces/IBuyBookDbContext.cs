using BuyBook.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuyBook.Application.Interfaces
{
    public interface IBuyBookDbContext
    {
        DbSet<Book> Book { get; set; }
        DbSet<Rating> Rating { get; set; }
        DbSet<User> User { get; set; }

        int SaveChanges();
    }
}
