using BuyBook.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuyBook.Domain
{
    public class Tag : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
