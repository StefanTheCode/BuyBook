using BuyBook.Application.Interfaces;
using BuyBook.Domain;
using BuyBook.PersistenceNoSQL.Interfaces;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuyBook.PersistenceNoSQL
{
    public class MongoDbContext : IMongoDbContext
    {
        private readonly IMongoDatabaseSettings _mongoDatabaseSettings;
        private readonly IMongoDatabase _database;

        public MongoDbContext(IMongoDatabaseSettings mongoDatabaseSettings)
        {
            _mongoDatabaseSettings = mongoDatabaseSettings;
            MongoClient client = new MongoClient(_mongoDatabaseSettings.ConnectionString);

            _database = client.GetDatabase(_mongoDatabaseSettings.DatabaseName);
        }

        public IMongoCollection<User> Users => _database.GetCollection<User>(User.GetDomainName());
        public IMongoCollection<Book> Books => _database.GetCollection<Book>(Book.GetDomainName());
        public IMongoCollection<Rating> Ratings => _database.GetCollection<Rating>(Rating.GetDomainName());
    }
}
