using BuyBook.Domain.Common;
using MongoDB.Bson.Serialization.Attributes;
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
        [BsonId]
        [BsonElement("_id")]
        public Guid BsonId { get; set; }

        public static string GetDomainName()
        {
            return "Rating";
        }
    }
}
