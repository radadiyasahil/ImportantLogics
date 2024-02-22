using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ImportantLogics.Models
{
    public class Inventory :DefaultProperty
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime ExpiryDate { get; set; }

        public Supplier Supplier { get; set; }
    }
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactInfo { get; set; }
        public string ProductSupplied { get; set; }
    }
}
