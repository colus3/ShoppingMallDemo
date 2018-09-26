using System.ComponentModel.DataAnnotations;

namespace ApiClients.Cart.Common.DTO
{
    public sealed class XUpdateCartItemQuantityRequest
    {
        [Required]
        public int? Quantity { get; set; }
    }
}
