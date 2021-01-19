using System;

namespace ProductCatalog.Models
{
    public class Product
    {
        public int IdProduct { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public int IdCategory { get; set; }
        public Category Category { get; set; }
    }
}
