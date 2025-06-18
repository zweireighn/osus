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

    public class ProductDetailsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public string ImagePath { get; set; }
        public List<string> ListOfImages { get; set; }
        public ICollection<ProductVariation> ProductionVariationList { get; set; }
    }

    public class CartProductsModel
    {
        public int OrderId { get; set; }
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public int ProductId { get; set; }
        public string Variant { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public int UserId { get; set; }
        public string SessionId { get; set; }
        public Product Product { get; set; }
    }

    public class CartModel 
    {
        public List<CartProductsModel> CartProducts { get; set; }
    }
}