using ApiClients.Cart.Common.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Services.Cart.Controllers
{
    [Route("Api/Internal/Carts")]
    public sealed class CartController : Controller
    {
        private readonly CartService mCartService;

        public CartController(CartService cartService)
        {
            mCartService = cartService;
        }

        [HttpPost]
        [Route("{userID}")]
        public async Task<IActionResult> AddCartItemAsync([FromRoute] long userID, [FromBody] XAddCartItemRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!await mCartService.AddCartItemAsync(userID, request.ProductID.Value))
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpGet]
        [Route("ByUserID/{userID}")]
        public async Task<IActionResult> GetCartAsync([FromRoute] long userID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var cart = await mCartService.GetCartByUserIDAsync(userID);
            return Ok(cart);
        }

        [HttpPatch]
        [Route("ByUserID/{userID}/CartItems/{cartItemID}")]
        public async Task<IActionResult> UpdateCartItemQuantity([FromRoute] long userID, [FromRoute] long cartItemID, [FromBody] XUpdateCartItemQuantityRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!await mCartService.UpdateCartItemQuantityAsync(userID, cartItemID, request.Quantity.Value))
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
