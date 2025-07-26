using System;
using System.Collections.Generic;

namespace HexaCommerce.Domain.Entities
{
    public class Category : BaseEntity
    {
        public Guid StoreId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public string ImageUrl { get; set; }
        public string IconClass { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
        public bool IsFeatured { get; set; }
        public bool ShowInMenu { get; set; }
        
        // SEO
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }
        
        // Hierarchy
        public Guid? ParentCategoryId { get; set; }
        public int Level { get; set; }
        public string Path { get; set; } // e.g., "Electronics/Phones/Smartphones"
        
        // Navigation
        public virtual Store Store { get; set; }
        public virtual Category ParentCategory { get; set; }
        public virtual ICollection<Category> SubCategories { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        
        public Category()
        {
            SubCategories = new HashSet<Category>();
            Products = new HashSet<Product>();
            IsActive = true;
            IsFeatured = false;
            ShowInMenu = true;
            Level = 0;
            DisplayOrder = 0;
        }
    }
} 