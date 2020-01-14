using BuyBook.Domain.Common;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace BuyBook.Domain
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string Age { get; set; }

        [BsonId]
        [BsonElement("_id")]
        public Guid BsonId { get; set; }

        public static string GetDomainName()
        {
            return "User";
        }
    }
}
