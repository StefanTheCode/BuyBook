using BuyBook.Application.Interfaces;
using BuyBook.Domain;
using BuyBook.Infrastructure.UploadExcel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuyBook.Application.PopulateDatabase
{
    public class BookPopulate
    {
        IBuyBookDbContext _dbContext;
        ExcelReader _reader;

        public BookPopulate()
        {
        }

        public BookPopulate(IBuyBookDbContext context, ExcelReader excelReader)
        {
            _dbContext = context;
            _reader = excelReader;
        }

        public void PopulateTable()
        {
            try
            {
                string[] booksData = _reader.LoadData(ReaderType.Book);

                var selected = booksData.Select(x => x.Split(';'));

                IEnumerable<Book> books = selected
                              .Select(x => new Book
                              {
                                  ISBN = x[0],
                                  Title = x[1],
                                  Authors = x[2],
                                  PublicationYear = x[3],
                                  Publisher = x[4],
                                  ImageUrlS = x[5],
                                  ImageUrlM = x[6],
                                  ImageUrlL = x[7]
                              });

                _dbContext.Book.AddRange(books);
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                //Create logger
            }
        }
    }
}
