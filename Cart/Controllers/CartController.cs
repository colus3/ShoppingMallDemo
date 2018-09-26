using ApiClients.Cart.Common.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
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
        [Route("{cartID}")]
        public async Task<IActionResult> AddCartItemAsync([FromRoute] long cartID, [FromBody] XAddCartItemRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!await mCartService.AddCartItemAsync(cartID, request.ProductID.Value))
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
        [Route("{cartID}/CartItems/{cartItemID}")]
        public async Task<IActionResult> UpdateCartItemQuantity([FromRoute] long cartID, [FromRoute] long cartItemID, [FromBody] XUpdateCartItemQuantityRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var cart = await mCartService.GetCartAsync(cartID);

            if (cart == null)
            {
                return NotFound();
            }

            if (!cart.CartItems.Any(ci => ci.ID == cartItemID))
            {
                return NotFound();
            }

            if (!await mCartService.UpdateCartItemQuantityAsync(cartItemID, request.Quantity.Value))
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPut]
        [Route("{cartID}")]
        public async Task<IActionResult> PlaceOrderAsync([FromRoute] long cartID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
