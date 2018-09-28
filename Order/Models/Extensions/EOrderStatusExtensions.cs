using ApiClients.Order.Common.DTO;
using Services.Order.Models.Entity;
using System;

namespace Services.Order.Models.Extensions
{
    public static class EOrderStatusExtensions
    {
        public static EXOrderStatus ToEXOrderStatus(this EOrderStatus status)
        {
            switch (status)
            {
                case EOrderStatus.Cancelled:
                    return EXOrderStatus.Cancelled;

                case EOrderStatus.OrderPlaced:
                    return EXOrderStatus.OrderPlaced;

                case EOrderStatus.Received:
                    return EXOrderStatus.Received;

                case EOrderStatus.ShipmentReady:
                    return EXOrderStatus.ShipmentReady;

                case EOrderStatus.Shipped:
                    return EXOrderStatus.Shipped;

                default:
                    throw new ArgumentOutOfRangeException($"Unknown status: {status}");
            }
        }
    }
}
