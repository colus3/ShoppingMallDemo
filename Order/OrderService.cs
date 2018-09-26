using Services.Order.Data;

namespace Services.Order
{
    public sealed class OrderService
    {
        private readonly OrderDbContext mOrderDbContext;

        public OrderService(OrderDbContext orderDbContext)
        {
            mOrderDbContext = orderDbContext;
        }


    }
}
