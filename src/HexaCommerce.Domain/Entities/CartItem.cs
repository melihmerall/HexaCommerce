using System;

namespace HexaCommerce.Domain.Entities
{
    public class CartItem : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
        public Guid? ProductVariantId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime AddedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        
        // Navigation
        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
        public virtual ProductVariant ProductVariant { get; set; }
        
        public CartItem()
        {
            Quantity = 1;
            UnitPrice = 0;
            TotalPrice = 0;
            AddedAt = DateTime.UtcNow;
        }
        
        public void CalculateTotal()
        {
            TotalPrice = UnitPrice * Quantity;
        }
    }
} 