using ApiClients.Order.Common.DTO;
using System.ComponentModel.DataAnnotations;

namespace ShoppingMallDemo.Models.DTO
{
    public sealed class CheckoutRequest
    {
        [Required]
        public string Address { get; set; }

        [Required]
        public EXDeliveryMethod? DeliveryMethod { get; set; }
    }
}
