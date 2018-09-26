using Microsoft.AspNetCore.Mvc;

namespace ShoppingMallDemo.Controllers
{
    [Route("Products")]
    public class ProductsController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult GetProductList()
        {
            return Ok();
        }

        [HttpGet]
        [Route("{ID}")]
        public IActionResult GetProduct(long ID)
        {
            return Ok();
        }

        [HttpPost]
        [Route("{ID}")]
        public IActionResult AddToCart(long ID)
        {
            return Ok();
        }
    }
}