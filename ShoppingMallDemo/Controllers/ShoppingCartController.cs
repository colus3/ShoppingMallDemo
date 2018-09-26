using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ShoppingMallDemo.Controllers
{
    [Route("Cart")]
    public class ShoppingCartController : Controller
    {
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddCartItem()
        {
            return Ok();
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetCart()
        {
            return Ok();
        }

        [HttpPatch]
        [Route("{cartItemID}")]
        public async Task<IActionResult> UpdateCartItemQuantity(long cartItemID)
        {
            return Ok();
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> PlaceOrder()
        {
            return Ok();
        }
    }
}