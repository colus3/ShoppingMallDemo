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

        public async Task<bool> AddCartItemAsync(long userID, XAddCartItemRequest request)
        {
            return await mCartService.AddCartItemAsync(userID, request.ProductID.Value);
        }

        public async Task<XCart> GetCartByUserIDAsync(long userID)
        {
            return await mCartService.GetCartByUserIDAsync(userID);
        }

        public async Task<bool> UpdateCartItemQuantityAsync(long userID, long cartItemID, XUpdateCartItemQuantityRequest request)
        {
            return await mCartService.UpdateCartItemQuantityAsync(userID, cartItemID, request.Quantity.Value);
        }

        public async Task<bool> UpdateCartStatus(long userID, XUpdateCartStatusRequest request)
        {
            return await mCartService.UpdateCartStatus(userID, request.Status.Value);
        }
    }
}
