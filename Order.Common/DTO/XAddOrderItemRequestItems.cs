using System.ComponentModel.DataAnnotations;

namespace ApiClients.Order.Common.DTO
{
    public sealed class XAddOrderItemRequestItems
    {
        [Required]
        public long? ProductID { get; set; }

        [Required]
        public int? Quantity { get; set; }

        [Required]
        public decimal? Price { get; set; }
    }
}
