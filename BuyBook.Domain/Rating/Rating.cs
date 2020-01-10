using BuyBook.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuyBook.Domain
{
    public class Rating : IEntity
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public int UserId { get; set; }
        public int Value { get; set; }
    }
}
