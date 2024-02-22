using Microsoft.Extensions.Options;
using MongoDB;
using MongoDB.Driver;

namespace ImportantLogics.Models
{
    public class DbContext
    {
        public IMongoDatabase db;
        public DbContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("MongoDb"));
            db = client.GetDatabase(configuration["ConnectionStrings:DatabaseName"]);

            products = db.GetCollection<Product>("Products");
            brands = db.GetCollection<Brand>("Brands");
        }
        public readonly IMongoCollection<Product> products;
        public readonly IMongoCollection<Brand> brands;
    }
}
