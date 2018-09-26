namespace Cart.Common.DTO
{
    public sealed class XCartItem
    {
        public XCartItem(long id, long productID, long cartID, int quantity)
        {
            ID = id;
            ProductID = productID;
            CartID = cartID;
            Quantity = quantity;
        }

        public long ID { get; private set; }

        public long ProductID { get; private set; }

        public long CartID { get; private set; }

        public int Quantity { get; private set; }
    }
}
