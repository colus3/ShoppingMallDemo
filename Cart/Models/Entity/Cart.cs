using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Services.Cart.Models.Entity
{
    public class Cart
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [Required]
        public long? UserID { get; set; }

        [Required]
        public ECartStatus Status { get; set; } = ECartStatus.Active;

        public virtual List<CartItem> CartItems { get; set; }
    }
}
