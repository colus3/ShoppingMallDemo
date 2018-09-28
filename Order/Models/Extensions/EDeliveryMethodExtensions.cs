using ApiClients.Order.Common.DTO;
using Services.Order.Models.Entity;
using System;

namespace Services.Order.Models.Extensions
{
    public static class EDeliveryMethodExtensions
    {
        public static EXDeliveryMethod ToEXDeliveryMethod(this EDeliveryMethod method)
        {
            switch (method)
            {
                case EDeliveryMethod.Delivery:
                    return EXDeliveryMethod.Delivery;

                case EDeliveryMethod.PickUp:
                    return EXDeliveryMethod.PickUp;

                default:
                    throw new ArgumentOutOfRangeException($"Unknown delivery method: {method}");
            }
        }

        public static EDeliveryMethod ToEntity(this EXDeliveryMethod method)
        {
            switch (method)
            {
                case EXDeliveryMethod.Delivery:
                    return EDeliveryMethod.Delivery;

                case EXDeliveryMethod.PickUp:
                    return EDeliveryMethod.PickUp;

                default:
                    throw new ArgumentOutOfRangeException($"Unknown delivery method: {method}");
            }
        }
    }
}
