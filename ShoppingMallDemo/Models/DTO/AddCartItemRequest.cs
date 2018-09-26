using System.ComponentModel.DataAnnotations;

namespace ShoppingMallDemo.Models.DTO
{
    public sealed class AddCartItemRequest
    {
        [Required]
        public long? ProductID { get; set; }
    }
}
