using ApiClients.Product.Common;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ShoppingMallDemo.Controllers
{
    [Route("Products")]
    public class ProductsController : Controller
    {
        public readonly IProductClient mProductClient;

        public ProductsController(IProductClient productClient)
        {
            mProductClient = productClient;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetProductList()
        {
            var products = await mProductClient.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet]
        [Route("{ID}")]
        public async Task<IActionResult> GetProduct(long ID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var product = await mProductClient.GetProductAsync(ID);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
    }
}