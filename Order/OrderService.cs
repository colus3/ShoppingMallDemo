using ApiClients.Order.Common.DTO;
using Microsoft.EntityFrameworkCore;
using Services.Order.Data;
using Services.Order.Models.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Order
{
    public sealed class OrderService
    {
        private readonly OrderDbContext mOrderDbContext;

        public OrderService(OrderDbContext orderDbContext)
        {
            mOrderDbContext = orderDbContext;
        }

        public async Task<bool> AddOrderAsync(XAddOrderRequest request)
        {
            var order = new Models.Entity.Order
            {
                UserID = request.UserID.Value,
                Address = request.Address,
                DeliveryMethod = request.DeliveryMethod.Value.ToEntity()
            };

            mOrderDbContext.Orders.Add(order);
            await mOrderDbContext.SaveChangesAsync();

            mOrderDbContext.Attach(order);

            order.OrderItems = request.OrderItems.Select(oi => new Models.Entity.OrderItem
            {
                ProductID = oi.ProductID.Value,
                OrderID = order.ID,
                Quantity = oi.Quantity.Value,
                Price = oi.Price.Value
            }).ToList();

            return true;
        }

        public async Task<XOrder> GetOrder(long orderID)
        {
            var order = await mOrderDbContext.Orders
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.ID == orderID);

            if (order == null)
            {
                return null;
            }

            var orderItems = order.OrderItems.Select(oi => new XOrderItem(
                id: oi.ID,
                productID: oi.ProductID.Value,
                quantity: oi.Quantity.Value,
                price: oi.Price.Value)).ToList();

            return new XOrder(
                id: order.ID,
                totalPrice: order.TotalPrice.Value,
                address: order.Address,
                deliveryMethod: order.DeliveryMethod.Value.ToEXDeliveryMethod(),
                orderStatus: order.OrderStatus.ToEXOrderStatus(),
                orderItems: orderItems);
        }

        public async Task<List<XOrder>> GetOrdersByUserID(long userID)
        {
            var orders = await mOrderDbContext.Orders
                .Include(o => o.OrderItems)
                .Where(o => o.UserID == userID)
                .ToListAsync();

            return orders.Select(o =>
            {
                var orderItems = o.OrderItems.Select(oi => new XOrderItem(
                id: oi.ID,
                productID: oi.ProductID.Value,
                quantity: oi.Quantity.Value,
                price: oi.Price.Value)).ToList();

                return new XOrder(
                    id: o.ID,
                    totalPrice: o.TotalPrice.Value,
                    address: o.Address,
                    deliveryMethod: o.DeliveryMethod.Value.ToEXDeliveryMethod(),
                    orderStatus: o.OrderStatus.ToEXOrderStatus(),
                    orderItems: orderItems);
            }).ToList();
        }
    }
}
