using System;

namespace HexaCommerce.Domain.Entities
{
    public class InventoryTransaction : BaseEntity
    {
        public Guid InventoryId { get; set; }
        public Guid? OrderId { get; set; }
        public Guid? CustomerId { get; set; }
        public int Quantity { get; set; }
        public string TransactionType { get; set; } // In, Out, Purchase, Sale, Return, Adjustment, Reserve, Unreserve
        public int PreviousStock { get; set; }
        public int NewStock { get; set; }
        public decimal? UnitCost { get; set; }
        public string ReferenceNumber { get; set; }
        public string Notes { get; set; }
        
        // Navigation
        public virtual Inventory Inventory { get; set; }
        public virtual Order Order { get; set; }
        public virtual Customer Customer { get; set; }
        
        public InventoryTransaction()
        {
        }
    }
} 