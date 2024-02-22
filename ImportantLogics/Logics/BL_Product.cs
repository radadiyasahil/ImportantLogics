using ImportantLogics.Models;
using MongoDB.Driver;

namespace ImportantLogics.Logics
{
    public class BL_Product
    {
        public DbContext db;
        public BL_Product(DbContext db)
        {
            this.db = db;
        }

        public Product getById(string id)
        {
            return db.products.Find(x => x.Id == id).FirstOrDefault();
        }
        public void Insert(Product product)
        {
            db.products.InsertOne(product);
        }

        public Product Update(string id, Product product)
        {
            var update = Builders<Product>.Update
                .Set(x => x.Name, product.Name)
                .Set(x => x.Quantity, product.Quantity)
                .Set(x => x.Price, product.Price)
                .Set(x => x.IsDeleted, product.IsDeleted)
                .Set(x => x.Description, product.Description)
                .Set(x => x.Brand, product.Brand);
            commonUpdate(id, update);
            return product;
        }
        public bool Delete(string id)
        {
            var update = Builders<Product>.Update.Set(x => x.IsDeleted, true);
            db.products.UpdateOne(id, update);
            return true;
        }

        public void commonUpdate(string id, UpdateDefinition<Product> update)
        {
            update = update.Set(x => x.ModifyOn, DateTime.Now);
            db.products.UpdateOne(id, update);
        }
    }
}
