using System;

namespace HexaCommerce.Domain.Entities
{
    public class OrderItem : BaseEntity
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public Guid? ProductVariantId { get; set; }
        public string ProductName { get; set; }
        public string ProductSku { get; set; }
        public string VariantName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal? DiscountAmount { get; set; }
        public string Notes { get; set; }
        
        // Navigation
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
        public virtual ProductVariant ProductVariant { get; set; }
        
        public OrderItem()
        {
            Quantity = 1;
            UnitPrice = 0;
            TotalPrice = 0;
        }
        
        public void CalculateTotal()
        {
            TotalPrice = (UnitPrice * Quantity) - (DiscountAmount ?? 0);
        }
    }
} 