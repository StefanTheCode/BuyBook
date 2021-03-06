﻿using BuyBook.Application.Interfaces;
using BuyBook.Domain;
using BuyBook.Infrastructure.UploadExcel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuyBook.Application.PopulateDatabase
{
    public class RatingPopulate
    {
        IBuyBookDbContext _dbContext;
        IMongoDbContext _mongoDbContext;
        ExcelReader _reader;

        public RatingPopulate()
        {
        }

        public RatingPopulate(IBuyBookDbContext context, ExcelReader excelReader, IMongoDbContext mongo)
        {
            _dbContext = context;
            _mongoDbContext = mongo;
            _reader = excelReader;
        }

        public void PopulateTable()
        {
            try
            {
                string[] ratingData = _reader.LoadData(ReaderType.Rating);

                var selected = ratingData.Select(x => x.Split(';'));
                List<Rating> newRatings = new List<Rating>();

                IEnumerable<Rating> ratings = selected
                              .Select(x => new Rating
                              {
                                  UserId = Int32.Parse(x[0]),
                                  ISBN = x[1],
                                  BookRating = Int32.Parse(x[2]),
                              });

                _dbContext.Rating.AddRange(ratings);
                _dbContext.SaveChanges();

                _mongoDbContext.Ratings.InsertMany(ratings);
            }
            catch (Exception e)
            {
                //Create logger
            }
        }
    }
}
