using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Services.Product.Conrollers
{
    [Route("Api/Internal/Products")]
    public sealed class ProductsController : Controller
    {
        private readonly ProductService mProductService;

        public ProductsController(ProductService productService)
        {
            mProductService = productService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetProductListAsync()
        {
            var products = await mProductService.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet]
        [Route("{ID}")]
        public async Task<IActionResult> GetProduct([FromRoute] long ID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var product = await mProductService.GetProductOrNullAsync(ID);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
    }
}
