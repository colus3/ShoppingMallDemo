using ApiClients.Cart.Common;
using ApiClients.Cart.Common.DTO;
using Microsoft.AspNetCore.Mvc;
using ShoppingMallDemo.Models.DTO;
using System.Threading.Tasks;

namespace ShoppingMallDemo.Controllers
{
    [Route("Cart")]
    public class CartController : Controller
    {
        private readonly ICartClient mCartClient;

        public CartController(ICartClient cartClient)
        {
            mCartClient = cartClient;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddCartItem([FromBody] AddCartItemRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            // Usually, you would get userid from an access token, for example. This is hardcoded for simplicity.
            var userID = 1;

            var cart = await mCartClient.GetCartByUserIDAsync(userID);

            if (!await mCartClient.AddCartItemAsync(cart.ID, new XAddCartItemRequest { ProductID = request.ProductID.Value }))
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetCart()
        {
            // Usually, you would get userid from an access token, for example. This is hardcoded for simplicity.
            var userID = 1;

            var cart = await mCartClient.GetCartByUserIDAsync(userID);

            return Ok(cart);
        }

        [HttpPatch]
        [Route("CartItems/{cartItemID}")]
        public async Task<IActionResult> UpdateCartItemQuantity([FromRoute] long cartItemID, [FromBody] UpdateCartItemQuantityRequest request)
        {
            // Usually, you would get userid from an access token, for example. This is hardcoded for simplicity.
            var userID = 1;

            var cart = await mCartClient.GetCartByUserIDAsync(userID);

            if (!await mCartClient.UpdateCartItemQuantityAsync(cart.ID, cartItemID, new XUpdateCartItemQuantityRequest { Quantity = request.Quantity.Value }))
            {
                return NotFound();
            }

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