using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ImportantLogics.Models
{
    public class Brand :DefaultProperty
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? CountryOfOrigin { get; set; }
    }
}
