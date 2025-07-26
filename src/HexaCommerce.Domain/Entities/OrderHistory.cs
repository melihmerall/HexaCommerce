using System;

namespace HexaCommerce.Domain.Entities
{
    public class OrderHistory : BaseEntity
    {
        public Guid OrderId { get; set; }
        public string Status { get; set; }
        public string Comment { get; set; }
        public string ChangedBy { get; set; }
        public string PreviousStatus { get; set; }
        
        // Navigation
        public virtual Order Order { get; set; }
    }
} 