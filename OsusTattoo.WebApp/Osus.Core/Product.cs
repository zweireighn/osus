using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Osus.Core.Enums;

namespace Osus.Core
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public Category Category { get; set; }
        public virtual ICollection<ProductVariation> ProductionVariationList { get; set; }
    }
}
