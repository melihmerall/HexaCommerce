using System;

namespace HexaCommerce.Domain.Entities
{
    public class ProductImage : BaseEntity
    {
        public Guid ProductId { get; set; }
        public string ImageUrl { get; set; }
        public string ThumbnailUrl { get; set; }
        public string AltText { get; set; }
        public string Title { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsPrimary { get; set; }
        public long FileSize { get; set; }
        public string FileType { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        
        // Navigation
        public virtual Product Product { get; set; }
        
        public ProductImage()
        {
            DisplayOrder = 0;
            IsPrimary = false;
        }
    }
} 