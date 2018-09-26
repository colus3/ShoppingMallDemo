using System.Collections.Generic;

namespace Cart.Common.DTO
{
    public sealed class XCart
    {
        public XCart(long id, decimal totalPrice, long userID, EXCartStatus status, List<XCartItem> cartItems)
        {
            ID = id;
            TotalPrice = totalPrice;
            UserID = userID;
            Status = status;
            CartItems = cartItems;
        }

        public long ID { get; private set; }

        public decimal TotalPrice { get; private set; }

        public long UserID { get; private set; }

        public EXCartStatus Status { get; private set; }

        public List<XCartItem> CartItems { get; private set; }
    }
}
