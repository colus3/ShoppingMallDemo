using System.Collections.Generic;
using System.Threading.Tasks;
using ApiClients.Order.Common;
using ApiClients.Order.Common.DTO;
using Services.Order;

namespace ApiClients.Order.Direct
{
    public sealed class OrderDirectClient : IOrderClient
    {
        private readonly OrderService mOrderService;

        public OrderDirectClient(OrderService orderService)
        {
            mOrderService = orderService;
        }

        public async Task<bool> AddOrderAsync(XAddOrderRequest request)
        {
            return await mOrderService.AddOrderAsync(request);
        }

        public async Task<XOrder> GetOrder(long orderID)
        {
            return await mOrderService.GetOrder(orderID);
        }

        public async Task<List<XOrder>> GetOrdersByUserID(long userID)
        {
            return await mOrderService.GetOrdersByUserID(userID);
        }
    }
}
