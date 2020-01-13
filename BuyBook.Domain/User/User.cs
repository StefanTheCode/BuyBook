using BuyBook.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuyBook.Domain
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string Age { get; set; }
    }
}
