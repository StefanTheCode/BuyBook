using BuyBook.Domain.Common;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuyBook.Domain
{
    public class Book : IEntity
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Authors { get; set; }
        public string PublicationYear { get; set; }
        public string Publisher { get; set; }
        public string ImageUrlS { get; set; }
        public string ImageUrlM { get; set; }
        public string ImageUrlL { get; set; }
        [BsonId]
        [BsonElement("_id")]
        public Guid BsonId { get; set; }

        public static string GetDomainName()
        {
            return "Book";
        }
    }
}
