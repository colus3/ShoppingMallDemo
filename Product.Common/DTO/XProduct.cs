namespace ApiClients.Product.Common.DTO
{
    public sealed class XProduct
    {
        public XProduct(long id, string name, decimal price)
        {
            ID = id;
            Name = name;
            Price = price;
        }

        public long ID { get; private set; }

        public string Name { get; private set; }

        public decimal Price { get; private set; }
    }
}
