using ApiClients.Cart.Common.DTO;
using Services.Cart.Models.Entity;
using System;

namespace Services.Cart.Models.Extensions
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

        public static ECartStatus ToEntity(this EXCartStatus status)
        {
            switch (status)
            {
                case EXCartStatus.Active:
                    return ECartStatus.Active;

                case EXCartStatus.Deleted:
                    return ECartStatus.Deleted;

                case EXCartStatus.Ordered:
                    return ECartStatus.Ordered;

                default:
                    throw new ArgumentOutOfRangeException($"Unknown status value: {status}");
            }
        }
    }
}
