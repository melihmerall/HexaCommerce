using System;

namespace HexaCommerce.Domain.Entities
{
    public class WishlistItem : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
        public DateTime AddedAt { get; set; }
        public string Notes { get; set; }
        
        // Navigation
        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
        
        public WishlistItem()
        {
            AddedAt = DateTime.UtcNow;
        }
    }
} 