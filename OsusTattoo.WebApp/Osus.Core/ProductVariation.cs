namespace Osus.Core
{
    public class ProductVariation
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Variant { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public bool MakePrimary { get; set; }
    }
}
