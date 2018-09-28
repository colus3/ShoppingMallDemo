using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Services.Order.Models.Entity
{
    public class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [Required]
        public long? UserID { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public decimal? TotalPrice { get; set; }

        [Required]
        public EDeliveryMethod? DeliveryMethod { get; set; }

        [Required]
        public EOrderStatus OrderStatus { get; set; } = EOrderStatus.OrderPlaced;

        public virtual List<OrderItem> OrderItems { get; set; }
    }
}
