using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Services.Product.Models.Entity
{
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(8,2)")]
        public decimal? Price { get; set; }
    }
}
