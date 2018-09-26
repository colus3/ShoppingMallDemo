using ApiClients.Cart.Common.DTO;
using System.Threading.Tasks;

namespace ApiClients.Cart.Common
{
    public interface ICartClient
    {
        Task<bool> AddCartItemAsync(long cartID, XAddCartItemRequest request);

        Task<XCart> GetCartByUserIDAsync(long userID);

        Task<bool> UpdateCartItemQuantityAsync(long cartID, long cartItemID, XUpdateCartItemQuantityRequest request);
    }
}
