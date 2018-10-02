using System.Collections.Generic;

namespace ShoppingMallDemo.Models.DTO
{
    public sealed class GetCartResponse
    {
        public GetCartResponse(long id, decimal totalPrice, List<GetCartResponseItem> cartItems)
        {
            ID = id;
            TotalPrice = totalPrice;
            CartItems = cartItems;
        }

        public long ID { get; private set; }

        public decimal TotalPrice { get; private set; }

        public List<GetCartResponseItem> CartItems { get; private set; }
    }
}
