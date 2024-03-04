using ImportantLogics.Logics;
using ImportantLogics.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace ImportantLogics.Controllers
{
    [Route("Brand")]
    public class BrandController : Controller
    {
        private  DbContext db { get; set; }
        private  BL_Brand bL_Brand { get; set; }
        public BrandController(DbContext dbContext, BL_Brand bL_Brand)
        {
            this.db = dbContext;
            this.bL_Brand = bL_Brand;
        }

        [HttpGet]
        public List<Brand> GetAll()
        {
          return db.brands.AsQueryable().ToList();
        }

        [HttpPost]
        public void AddBrand([FromBody]Brand brand)
        {
            brand.IsDeleted = false;
            bL_Brand.Insert(brand);
        }

        [HttpPut]
        [Route("{id}")]
        public Brand UpdateBrand([FromRoute]string id,[FromBody]Brand brand)
        {
            return bL_Brand.Update(id, brand);
        }

        [HttpDelete]
        [Route("{id}")]
        public bool DeleteBrand(string id)
        {
            return bL_Brand.Delete(id);
        }
    }
}
