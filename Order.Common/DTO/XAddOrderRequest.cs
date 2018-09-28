using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ApiClients.Order.Common.DTO
{
    public sealed class XAddOrderRequest : IValidatableObject
    {
        [Required]
        public long? UserID { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public EXDeliveryMethod? DeliveryMethod { get; set; }

        [Required]
        public List<XAddOrderItemRequestItems> OrderItems { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (OrderItems == null || !OrderItems.Any())
            {
                yield return new ValidationResult($"{nameof(OrderItems)} cannot be null or empty.",
                    new[] { nameof(OrderItems) });
            }
        }
    }
}
