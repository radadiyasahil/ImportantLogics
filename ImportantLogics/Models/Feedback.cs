using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ImportantLogics.Models
{
    public class Feedback
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string? ProductId { get; set; }
        public double Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime Date { get; set; }
    }
}
