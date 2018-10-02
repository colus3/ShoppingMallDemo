using ApiClients.Cart.Common.DTO;
using System.Threading.Tasks;

namespace ApiClients.Cart.Common
{
    public interface ICartClient
    {
        Task<bool> AddCartItemAsync(long userID, XAddCartItemRequest request);

        Task<XCart> GetCartByUserIDAsync(long userID);

        Task<bool> UpdateCartItemQuantityAsync(long userID, long cartItemID, XUpdateCartItemQuantityRequest request);

        Task<bool> UpdateCartStatus(long userID, XUpdateCartStatusRequest request);
    }
}
