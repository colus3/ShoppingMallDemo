using System.Collections.Generic;

namespace ApiClients.Order.Common.DTO
{
    public sealed class XOrder
    {
        public XOrder(long id, decimal totalPrice, string address, EXDeliveryMethod deliveryMethod, EXOrderStatus orderStatus, List<XOrderItem> orderItems)
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

        public List<XOrderItem> OrderItems { get; private set; }
    }
}
