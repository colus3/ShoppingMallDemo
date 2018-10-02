using ApiClients.Product.Common;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InternalTool.Controllers
{
    [Route("Products")]
    public class ProductsController : Controller
    {
        private readonly IProductClient mProductClient;

        public ProductsController(IProductClient productClient)
        {
            mProductClient = productClient;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Index()
        {
            var products = await mProductClient.GetProductsAsync();

            return View(products);
        }

        [HttpGet]
        [Route("{ID}")]
        public async Task<IActionResult> Details([FromRoute] long ID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var product = await mProductClient.GetProductAsync(ID);

            return View(product);
        }
    }
}