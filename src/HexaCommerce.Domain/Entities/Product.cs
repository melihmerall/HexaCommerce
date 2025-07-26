using System;
using System.Collections.Generic;

namespace HexaCommerce.Domain.Entities
{
    public class Product : BaseEntity
    {
        public Guid StoreId { get; set; }
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string Slug { get; set; }
        public string Sku { get; set; }
        public string Barcode { get; set; }
        public decimal Price { get; set; }
        public decimal? CompareAtPrice { get; set; }
        public decimal CostPrice { get; set; }
        public int StockQuantity { get; set; }
        public int MinStockQuantity { get; set; }
        public bool TrackInventory { get; set; }
        public bool AllowBackorders { get; set; }
        public bool IsActive { get; set; }
        public bool IsPublished { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsNew { get; set; }
        public bool IsOnSale { get; set; }
        public DateTime? PublishedAt { get; set; }
        public DateTime? SaleStartDate { get; set; }
        public DateTime? SaleEndDate { get; set; }
        
        // Dimensions and Weight
        public decimal Weight { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public string WeightUnit { get; set; }
        public string DimensionUnit { get; set; }
        
        // SEO
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }
        
        // Navigation
        public virtual Store Store { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<ProductImage> Images { get; set; }
        public virtual ICollection<ProductVariant> Variants { get; set; }
        public virtual ICollection<ProductAttribute> Attributes { get; set; }
        public virtual ICollection<ProductTag> Tags { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        
        public Product()
        {
            Images = new HashSet<ProductImage>();
            Variants = new HashSet<ProductVariant>();
            Attributes = new HashSet<ProductAttribute>();
            Tags = new HashSet<ProductTag>();
            OrderItems = new HashSet<OrderItem>();
            IsActive = true;
            IsPublished = false;
            IsFeatured = false;
            IsNew = false;
            IsOnSale = false;
            TrackInventory = true;
            AllowBackorders = false;
            MinStockQuantity = 0;
            WeightUnit = "kg";
            DimensionUnit = "cm";
        }
        
        public bool IsInStock => !TrackInventory || StockQuantity > 0;
        public bool IsOnSaleNow => IsOnSale && (!SaleStartDate.HasValue || SaleStartDate.Value <= DateTime.UtcNow) && 
                                   (!SaleEndDate.HasValue || SaleEndDate.Value >= DateTime.UtcNow);
    }
} 