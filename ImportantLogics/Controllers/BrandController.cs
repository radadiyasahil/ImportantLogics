using ImportantLogics.Logics;
using ImportantLogics.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace ImportantLogics.Controllers
{
    [Route("Brand")]
    public class BrandController : Controller
    {
        public DbContext db { get; set; }
        public BL_Brand bL_Brand { get; set; }
        public BrandController(DbContext dbContext, BL_Brand bL_Brand)
        {
            this.db = dbContext;
            this.bL_Brand = bL_Brand;
        }
        [HttpGet]
        private List<Brand> GetAll()
        {
          return db.brands.AsQueryable().ToList();
        }

        [HttpPost]
        public void AddBrand(Brand brand)
        {
            brand.IsDeleted = false;
            db.brands.InsertOne(brand);
        }

        [HttpPut]
        public Brand UpdateBrand([FromRoute]string id,[FromBody]Brand brand)
        {
            return bL_Brand.Update(id, brand);
        }
    }
}
