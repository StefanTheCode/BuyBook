using BuyBook.Application.Interfaces;
using BuyBook.Domain;
using BuyBook.Infrastructure.UploadExcel.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BuyBook.Application.PopulateDatabase
{
    public class UserPopulate
    {
        IBuyBookDbContext _dbContext;
        IMongoDbContext _mongoDbContext;
        ExcelReader _reader;

        public UserPopulate()
        {
        }

        public UserPopulate(IBuyBookDbContext context, IMongoDbContext mongo, ExcelReader excelReader)
        {
            _dbContext = context;
            _mongoDbContext = mongo;
            _reader = excelReader;
        }

        public void PopulateTable()
        {
            try
            {
                string[] usersData = _reader.LoadData(ReaderType.Users);

                var selected = usersData.Select(x => x.Split(';'));

                IEnumerable<User> users = selected
                              .Select(x => new User
                              {
                                  BsonId = new Guid(),
                                  Location = x[1],
                                  Age = x[2]
                              });

                _dbContext.User.AddRange(users);
                _dbContext.SaveChanges();

                _mongoDbContext.Users.InsertMany(users);
            }
            catch (Exception e)
            {
                //Create logger
            }
        }
    }
}
