using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Services.Cart.Models.Entity
{
    public class CartItem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [Required]
        public long? ProductID { get; set; }

        [Required]
        public long? CartID { get; set; }

        [Required]
        public int? Quantity { get; set; }

        public virtual Cart Cart { get; set; }
    }
}
