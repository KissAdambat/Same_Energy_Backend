using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Backend.Models;

namespace Backend.Controllers
{
    [Route("products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public SameEnergyDBContext Context = new SameEnergyDBContext();
        [HttpGet("GetAllProducts")]
        public object GetAllProducts()
        {
            var products = Context.Products.ToList();
            return new { message = "Sikeres lekérdezés", data = products };
        }

        [HttpGet("GetAProduct/{id}")]
        public object GetAProduct(int id)
        {
            var existingProduct = Context.Products.FirstOrDefault(o => o.id == id);
            if (existingProduct != null)
            {
                return existingProduct;
            }
            return NotFound(new { message = "Nem található a megadott product" });
        }

    }
}
