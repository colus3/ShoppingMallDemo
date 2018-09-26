using System.Linq;
using System.Threading.Tasks;
using ApiClients.Cart.Common;
using ApiClients.Cart.Common.DTO;
using Services.Cart;

namespace ApiClients.Cart.Direct
{
    public sealed class CartDirectClient : ICartClient
    {
        private readonly CartService mCartService;

        public CartDirectClient(CartService cartService)
        {
            mCartService = cartService;
        }

        public async Task<bool> AddCartItemAsync(long cartID, XAddCartItemRequest request)
        {
            return await mCartService.AddCartItemAsync(cartID, request.ProductID.Value);
        }

        public async Task<XCart> GetCartByUserIDAsync(long userID)
        {
            return await mCartService.GetCartByUserIDAsync(userID);
        }

        public async Task<bool> UpdateCartItemQuantityAsync(long cartID, long cartItemID, XUpdateCartItemQuantityRequest request)
        {
            var cart = await mCartService.GetCartAsync(cartID);

            if (cart == null)
            {
                return false;
            }

            if (!cart.CartItems.Any(ci => ci.ID == cartItemID))
            {
                return false;
            }

            return await mCartService.UpdateCartItemQuantityAsync(cartItemID, request.Quantity.Value);
        }
    }
}
