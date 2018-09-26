namespace Order.Common.DTO
{
    public sealed class XOrderItem
    {
        public XOrderItem(long id, long productID, int quantity)
        {
            ID = id;
            ProductID = productID;
            Quantity = quantity;
        }

        public long ID { get; private set; }

        public long ProductID { get; private set; }

        public int Quantity { get; private set; }
    }
}
