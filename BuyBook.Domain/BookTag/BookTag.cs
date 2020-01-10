using BuyBook.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuyBook.Domain
{
    public class BookTag : IEntity
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public Tag Tag { get; set; }
        public int Count { get; set; }
    }
}
