using System;

namespace HexaCommerce.Domain.Entities
{
    public class ProductVariant : BaseEntity
    {
        public Guid ProductId { get; set; }
        public string Sku { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal? CompareAtPrice { get; set; }
        public int StockQuantity { get; set; }
        public bool TrackInventory { get; set; }
        public bool IsActive { get; set; }
        
        // Variant Options (e.g., Size: Large, Color: Red)
        public string Option1Name { get; set; }
        public string Option1Value { get; set; }
        public string Option2Name { get; set; }
        public string Option2Value { get; set; }
        public string Option3Name { get; set; }
        public string Option3Value { get; set; }
        
        // Navigation
        public virtual Product Product { get; set; }
        
        public ProductVariant()
        {
            IsActive = true;
            TrackInventory = true;
        }
        
        public bool IsInStock => !TrackInventory || StockQuantity > 0;
    }
} 