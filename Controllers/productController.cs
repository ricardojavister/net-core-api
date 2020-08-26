using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/products")]
    public class productController : Controller
    {
        static List<Product> _products = new List<Product>(){
            new Product(){ Idproduct =0, Name= "hard disk", Price= 100  },
            new Product(){ Idproduct =1, Name= "monitor", Price= 250  },
        };

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_products);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            _products.Add(product);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Product product)
        {
            var entity = _products.Where(x => x.Idproduct == product.Idproduct).FirstOrDefault();
            entity.Name =  product.Name;
            entity.Price = product.Price;
            entity.Imageurl =  product.Imageurl;
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Product product)
        {
            var entity = _products.Where(x => x.Idproduct == product.Idproduct).FirstOrDefault();
            _products.Remove(entity);
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}