using ApiClients.Cart.Common;
using ApiClients.Cart.Common.DTO;
using ApiClients.Order.Common;
using ApiClients.Order.Common.DTO;
using ApiClients.Product.Common;
using Microsoft.AspNetCore.Mvc;
using ShoppingMallDemo.Models.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingMallDemo.Controllers
{
    [Route("Cart")]
    public class CartController : Controller
    {
        private readonly ICartClient mCartClient;
        private readonly IProductClient mProductClient;
        private readonly IOrderClient mOrderClient;

        public CartController(ICartClient cartClient, IProductClient productClient, IOrderClient orderClient)
        {
            mCartClient = cartClient;
            mProductClient = productClient;
            mOrderClient = orderClient;
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> CheckoutAsync([FromBody] CheckoutRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            // Usually, you would get userid from an access token, for example. This is hardcoded for simplicity.
            var userID = 1;

            var cart = await mCartClient.GetCartByUserIDAsync(userID);

            var getproductTasks = cart.CartItems.Select(ci => mProductClient.GetProductAsync(ci.ProductID)).ToList();

            var orderItems = new List<XAddOrderItemRequestItems>();
            for (int i = 0; i < getproductTasks.Count; i++)
            {
                var product = await getproductTasks[i];

                orderItems.Add(new XAddOrderItemRequestItems
                {
                    ProductID = product.ID,
                    Quantity = cart.CartItems[i].Quantity,
                    Price = product.Price
                });
            }

            await mOrderClient.AddOrderAsync(new XAddOrderRequest
            {
                UserID = userID,
                Address = request.Address,
                DeliveryMethod = request.DeliveryMethod.Value,
                OrderItems = orderItems
            });

            return Ok();
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

            if (!await mCartClient.AddCartItemAsync(userID, new XAddCartItemRequest { ProductID = request.ProductID.Value }))
            {
                return NotFound();
            }

            var cart = await mCartClient.GetCartByUserIDAsync(userID);

            var getproductTasks = cart.CartItems.Select(ci => mProductClient.GetProductAsync(ci.ProductID)).ToList();

            var cartItems = new List<GetCartResponseItem>();
            for (int i = 0; i < getproductTasks.Count; i++)
            {
                var product = await getproductTasks[i];

                cartItems.Add(new GetCartResponseItem(
                    id: cart.CartItems[i].ID,
                    productID: product.ID,
                    productName: product.Name,
                    price: product.Price,
                    quantity: cart.CartItems[i].Quantity
                ));
            }

            return CreatedAtAction(nameof(GetCart), new GetCartResponse(
                id: cart.ID,
                totalPrice: cartItems.Sum(ci => ci.Price * ci.Quantity),
                cartItems: cartItems
            ));
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetCart()
        {
            // Usually, you would get userid from an access token, for example. This is hardcoded for simplicity.
            var userID = 1;

            var cart = await mCartClient.GetCartByUserIDAsync(userID);

            var getproductTasks = cart.CartItems.Select(ci => mProductClient.GetProductAsync(ci.ProductID)).ToList();

            var cartItems = new List<GetCartResponseItem>();
            for (int i = 0; i < getproductTasks.Count; i++)
            {
                var product = await getproductTasks[i];

                cartItems.Add(new GetCartResponseItem(
                    id: cart.CartItems[i].ID,
                    productID: product.ID,
                    productName: product.Name,
                    price: product.Price,
                    quantity: cart.CartItems[i].Quantity
                ));
            }

            return Ok(new GetCartResponse(
                id: cart.ID,
                totalPrice: cartItems.Sum(ci => ci.Price * ci.Quantity),
                cartItems: cartItems
            ));
        }

        [HttpPatch]
        [Route("CartItems/{cartItemID}")]
        public async Task<IActionResult> UpdateCartItemQuantity([FromRoute] long cartItemID, [FromBody] UpdateCartItemQuantityRequest request)
        {
            // Usually, you would get userid from an access token, for example. This is hardcoded for simplicity.
            var userID = 1;

            if (!await mCartClient.UpdateCartItemQuantityAsync(userID, cartItemID, new XUpdateCartItemQuantityRequest { Quantity = request.Quantity.Value }))
            {
                return NotFound();
            }

            var cart = await mCartClient.GetCartByUserIDAsync(userID);

            var getproductTasks = cart.CartItems.Select(ci => mProductClient.GetProductAsync(ci.ProductID)).ToList();

            var cartItems = new List<GetCartResponseItem>();
            for (int i = 0; i < getproductTasks.Count; i++)
            {
                var product = await getproductTasks[i];

                cartItems.Add(new GetCartResponseItem(
                    id: cart.CartItems[i].ID,
                    productID: product.ID,
                    productName: product.Name,
                    price: product.Price,
                    quantity: cart.CartItems[i].Quantity
                ));
            }

            return Ok(new GetCartResponse(
                id: cart.ID,
                totalPrice: cartItems.Sum(ci => ci.Price * ci.Quantity),
                cartItems: cartItems
            ));
        }
    }
}