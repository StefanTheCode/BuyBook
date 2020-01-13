using BuyBook.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuyBook.Domain
{
    public class Rating : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ISBN { get; set; }
        public int BookRating { get; set; }
    }
}
