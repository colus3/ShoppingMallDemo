using ApiClients.Order.Common.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiClients.Order.Common
{
    public interface IOrderClient
    {
        Task<bool> AddOrderAsync(XAddOrderRequest request);

        Task<XOrder> GetOrder(long orderID);

        Task<List<XOrder>> GetOrdersByUserID(long userID);
    }
}
