using System;
using System.Collections.Generic;

namespace HexaCommerce.Domain.Entities
{
    public class ProductTag : BaseEntity
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        
        // Navigation
        public virtual Product Product { get; set; }
        
        public ProductTag()
        {
            IsActive = true;
        }
    }
} 