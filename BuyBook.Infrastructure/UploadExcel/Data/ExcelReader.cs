using BuyBook.Infrastructure.Utility;
using System;
using System.Linq;

namespace BuyBook.Infrastructure.UploadExcel.Data
{
    public class ExcelReader
    {
        private string fileName;

        public string[] LoadData(ReaderType type)
        {
            try
            {
                switch (type)
                {
                    case ReaderType.Book:
                        fileName = "books.csv";
                        break;
                    case ReaderType.BookTag:
                        fileName = "book_tags";
                        break;
                    case ReaderType.Rating:
                        fileName = "ratings";
                        break;
                    case ReaderType.Tag:
                        fileName = "tags";
                        break;
                    default:
                        fileName = string.Empty;
                        break;
                }

                string csvString = UtilityClass.LoadExcelData(fileName);
                string[] rows = csvString.Split(new[] { Environment.NewLine }, StringSplitOptions.None)
                                         .Skip(1)
                                         .Where(x => !string.IsNullOrEmpty(x))
                                         .ToArray();

                return rows;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }

    public enum ReaderType
    {
        Book = 1,
        BookTag = 2,
        Rating = 3,
        Tag = 4
    }
}
