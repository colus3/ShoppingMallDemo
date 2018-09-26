using System.ComponentModel.DataAnnotations;

namespace ShoppingMallDemo.Models.DTO
{
    public sealed class UpdateCartItemQuantityRequest
    {
        [Required]
        [Range(1, 50)]
        public int? Quantity { get; set; }
    }
}
