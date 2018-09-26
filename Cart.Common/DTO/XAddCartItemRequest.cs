using System.ComponentModel.DataAnnotations;

namespace ApiClients.Cart.Common.DTO
{
    public sealed class XAddCartItemRequest
    {
        [Required]
        public long? ProductID { get; set; }
    }
}
