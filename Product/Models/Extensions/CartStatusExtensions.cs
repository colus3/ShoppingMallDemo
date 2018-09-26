using ApiClients.Cart.Common.DTO;
using Services.Cart.Models.Entity;
using System;

namespace Services.Product.Models.Extensions
{
    public static class CartStatusExtensions
    {
        public static EXCartStatus ToEXCartStatus(this ECartStatus status)
        {
            switch (status)
            {
                case ECartStatus.Active:
                    return EXCartStatus.Active;

                case ECartStatus.Deleted:
                    return EXCartStatus.Deleted;

                case ECartStatus.Ordered:
                    return EXCartStatus.Ordered;

                default:
                    throw new ArgumentOutOfRangeException($"Unknown status value: {status}");
            }
        }
    }
}
