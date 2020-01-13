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
                        fileName = "BX-Books.csv";
                        break;
                    case ReaderType.Users:
                        fileName = "BX-Users.csv";
                        break;
                    case ReaderType.Rating:
                        fileName = "BX-Book-Ratings.csv";
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
        Users = 2,
        Rating = 3
    }
}
