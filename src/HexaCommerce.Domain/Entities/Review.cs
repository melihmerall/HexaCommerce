using System;

namespace HexaCommerce.Domain.Entities
{
    public class Review : BaseEntity
    {
        public Guid StoreId { get; set; }
        public Guid ProductId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid? OrderId { get; set; }
        public int Rating { get; set; } // 1-5 stars
        public string Title { get; set; }
        public string Comment { get; set; }
        public bool IsVerifiedPurchase { get; set; }
        public bool IsApproved { get; set; }
        public bool IsHelpful { get; set; }
        public int HelpfulCount { get; set; }
        public int UnhelpfulCount { get; set; }
        public DateTime? ApprovedAt { get; set; }
        public string ApprovedBy { get; set; }
        public string AdminResponse { get; set; }
        public DateTime? AdminResponseAt { get; set; }
        
        // Navigation
        public virtual Store Store { get; set; }
        public virtual Product Product { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Order Order { get; set; }
        
        public Review()
        {
            IsApproved = false;
            IsHelpful = false;
            HelpfulCount = 0;
            UnhelpfulCount = 0;
        }
        
        public bool IsVerified => IsVerifiedPurchase || OrderId.HasValue;
        public int NetHelpfulCount => HelpfulCount - UnhelpfulCount;
    }
} 