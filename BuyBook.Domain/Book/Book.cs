using BuyBook.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuyBook.Domain
{
    public class Book : IEntity
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int BestBookId { get; set; }
        public int WorkId { get; set; }
        public int BooksCount { get; set; }
        public string ISBN { get; set; }
        public string ISBN13 { get; set; }
        public string Authors { get; set; }
        public int PublicationYear { get; set; }
        public string OriginalTitle { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public string ImageUrl { get; set; }
    }
}
