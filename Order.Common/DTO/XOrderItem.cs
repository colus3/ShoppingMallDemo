namespace ApiClients.Order.Common.DTO
{
    public sealed class XOrderItem
    {
        public XOrderItem(long id, long productID, int quantity, decimal price)
        {
            ID = id;
            ProductID = productID;
            Quantity = quantity;
            Price = price;
        }

        public long ID { get; private set; }

        public long ProductID { get; private set; }

        public int Quantity { get; private set; }

        public decimal Price { get; private set; }
    }
}
