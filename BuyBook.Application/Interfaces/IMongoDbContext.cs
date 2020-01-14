using BuyBook.Domain;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuyBook.Application.Interfaces
{
    public interface IMongoDbContext
    {
        IMongoCollection<User> Users { get; }
        IMongoCollection<Book> Books { get; }
        IMongoCollection<Rating> Ratings { get; }
    }
}
