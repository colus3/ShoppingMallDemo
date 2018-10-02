namespace ShoppingMallDemo.Models.DTO
{
    public sealed class GetOrderResponseItem
    {
        public GetOrderResponseItem(long id, long productID, string productName, decimal price, int quantity)
        {
            ID = id;
            ProductID = productID;
            ProductName = productName;
            Price = price;
            Quantity = quantity;
        }

        public long ID { get; private set; }

        public long ProductID { get; private set; }

        public string ProductName { get; private set; }

        public decimal Price { get; private set; }

        public int Quantity { get; private set; }
    }
}
