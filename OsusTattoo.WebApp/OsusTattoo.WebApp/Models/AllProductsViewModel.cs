using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Osus.Core.Enums;
using Osus.Core;

namespace OsusTattoo.Models
{
    public class AllProductsViewModel
    {
        public List<ProductsModel> Products { get; set; }
    }

    public class ProductsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public DateTime DateCreation { get; set; }
        public string ImagePath { get; set; }
        public ICollection<ProductVariation> ProductionVariationList { get; set; }
    }
}