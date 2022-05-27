using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class ProductsController : ApiController
    {
        [HttpPost]
        public IHttpActionResult SaveProduct(int id, string name, float price, int categoryFk, string imgName, int orgFk, int menuFk)
        {
            using (CafeDataBaseEntities db = new CafeDataBaseEntities())
            {
                Product product = new Product();

                product.Id = id;
                product.Name = name;
                product.Price = price;
                product.CategoryFk = categoryFk;
                product.ImgName = imgName;
                product.OrgFk = orgFk;
                product.MenuFk = menuFk;

                db.Products.Add(product);
                
                return Ok();
            }
        }

        [HttpGet]
        public IEnumerable<Product> GetAllProducts()
        {
            using (CafeDataBaseEntities db = new CafeDataBaseEntities())
            {
                return db.Products;
            }
        }

        [HttpGet]
        public IHttpActionResult GetProductById(int id)
        {
            using (CafeDataBaseEntities db = new CafeDataBaseEntities())
            {
                var product = db.Products.Where(a => a.Id == id);

                if (product != null)
                    return Ok(product);
            }

            return NotFound();
        }
    }
}
