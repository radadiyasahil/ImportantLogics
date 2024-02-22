namespace ImportantLogics.Models
{
    public class Product :DefaultProperty
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public Brand? Brand { get; set; }
    }
}
