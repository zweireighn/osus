using System;
using System.Collections.Generic;
using Osus.Core.Enums;

namespace Osus.Core
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public DateTime DateCreation { get; set; }
        public string ImagePath { get; set; } 
        public string PrimaryImage { get; set; }
        public ICollection<ProductVariation> ProductionVariationList { get; set; }
    }
}
