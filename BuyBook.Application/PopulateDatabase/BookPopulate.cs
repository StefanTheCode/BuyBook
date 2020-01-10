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

                var selected = booksData.Select(x => x.Split(','));

                IEnumerable<Book> books = selected
                              .Select(x => new Book
                              {
                                  BookId = Int32.Parse(x[1]),
                                  //BestBookId = Int32.Parse(x[2]),
                                  //WorkId = Int32.Parse(x[3]),
                                  BooksCount = Int32.Parse(x[4]),
                                  ISBN = x[5],
                                  ISBN13 = x[6],
                                  Authors = x[7],
                                  PublicationYear = Int32.Parse(x[8]),
                                  OriginalTitle = x[9],
                                  Title = x[10],
                                  Language = x[11],
                                  ImageUrl = x[22]
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
