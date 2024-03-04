using ImportantLogics.Logics;
using ImportantLogics.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Security.Cryptography.X509Certificates;

namespace ImportantLogics.Controllers
{
    [Route("Products")]
    public class ProductController : Controller
    {
        public DbContext db { get; set; }
        public BL_Product BL_Product { get; set; }
        public ProductController(DbContext db,BL_Product product)
        {
            this.db = db;
            this.BL_Product = product;
        }

        [HttpGet]
        public List<Product> GetAll()
        {
            return db.products.AsQueryable().ToList();
        }

        [HttpGet]
        [Route("{id}")]
        public Product Get(string id)
        {
            return BL_Product.getById(id);
        }

        [HttpPost]
        public void AddProduct([FromBody]Product product)
        {
            BL_Product.Insert(product);
        }

        [HttpPut]
        [Route("{id}")]
        public Product update([FromRoute]string id,[FromBody] Product product)
        {
            if (product == null)
                throw new InvalidDataException("Product is not exist!");
            return BL_Product.Update(id, product);
        }

        [HttpDelete]
        [Route("{id}")]
        public bool Delete([FromRoute]string id)
        {
           return BL_Product.Delete(id);
        }
    }
}
