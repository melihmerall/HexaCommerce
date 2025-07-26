using System;

namespace HexaCommerce.Domain.Entities
{
    public class ProductAttribute : BaseEntity
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsVisible { get; set; }
        public bool IsSearchable { get; set; }
        public bool IsFilterable { get; set; }
        
        // Navigation
        public virtual Product Product { get; set; }
        
        public ProductAttribute()
        {
            DisplayOrder = 0;
            IsVisible = true;
            IsSearchable = false;
            IsFilterable = false;
        }
    }
} 