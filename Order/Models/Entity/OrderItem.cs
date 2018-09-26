using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Services.Order.Models.Entity
{
    public class OrderItem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [Required]
        public long? ProductID { get; set; }

        [Required]
        public long? OrderID { get; set; }

        [Required]
        public int? Quantity { get; set; }

        public virtual Order Order { get; set; }
    }
}
