using ApiClients.Order.Common.DTO;
using System.Collections.Generic;

namespace ShoppingMallDemo.Models.DTO
{
    public sealed class GetOrderResponse
    {
        public GetOrderResponse(long id, decimal totalPrice, string address, EXDeliveryMethod deliveryMethod, EXOrderStatus orderStatus, List<GetOrderResponseItem> orderItems)
        {
            ID = id;
            TotalPrice = totalPrice;
            Address = address;
            DeliveryMethod = deliveryMethod;
            OrderStatus = orderStatus;
            OrderItems = orderItems;
        }

        public long ID { get; private set; }

        public decimal TotalPrice { get; private set; }

        public string Address { get; private set; }

        public EXDeliveryMethod DeliveryMethod { get; private set; }

        public EXOrderStatus OrderStatus { get; private set; }

        public List<GetOrderResponseItem> OrderItems { get; set; }
    }
}
