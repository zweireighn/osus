using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Osus.Core
{
    public class ProductVariation
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public string ProductVariant { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public bool MakePrimary { get; set; }
        public virtual Product Product { get; set; }
    }
}
