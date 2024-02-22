using ImportantLogics.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace ImportantLogics.Logics
{
    public class BL_Brand
    {
        public DbContext db { get; set; }
        public BL_Brand(DbContext dbContext)
        {
            this.db = dbContext;   
        }
        public Brand getById(string id)
        {
            return db.brands.Find(x => x.Id == id).FirstOrDefault();
        }

        public void Insert(Brand brand)
        {
            db.brands.InsertOne(brand);
        }

        public Brand Update(string id,Brand brand)
        {
            var update = Builders<Brand>.Update
                .Set(x => x.Name, brand.Name)
                .Set(x => x.Description, brand.Description)
                .Set(x => x.ModifyOn, DateTime.Now)
                .Set(x => x.CountryOfOrigin, brand.CountryOfOrigin);
            db.brands.UpdateOne(id, update);
            return brand;
        }
        public bool Delete(string id)
        {
            var update = Builders<Brand>.Update.Set(x => x.IsDeleted, true);
             db.brands.UpdateOne(id,update);
            return true;
        }
    }
}
