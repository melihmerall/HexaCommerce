using System;
using System.Collections.Generic;

namespace HexaCommerce.Domain.Entities
{
    public class Discount : BaseEntity
    {
        public Guid StoreId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public string DiscountType { get; set; } // Percentage, FixedAmount, BuyXGetY, FreeShipping
        public decimal Value { get; set; }
        public decimal? MinimumOrderAmount { get; set; }
        public decimal? MaximumDiscountAmount { get; set; }
        public int? UsageLimit { get; set; }
        public int UsedCount { get; set; }
        public int? UsageLimitPerCustomer { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsFirstTimeCustomerOnly { get; set; }
        public bool IsExclusive { get; set; } // Cannot be combined with other discounts
        
        // Product/Category restrictions
        public bool AppliesToAllProducts { get; set; }
        public virtual ICollection<Guid> ApplicableProductIds { get; set; }
        public virtual ICollection<Guid> ApplicableCategoryIds { get; set; }
        public virtual ICollection<Guid> ExcludedProductIds { get; set; }
        public virtual ICollection<Guid> ExcludedCategoryIds { get; set; }
        
        // Customer restrictions
        public bool AppliesToAllCustomers { get; set; }
        public virtual ICollection<Guid> ApplicableCustomerIds { get; set; }
        public virtual ICollection<string> ApplicableCustomerGroups { get; set; }
        
        // Navigation
        public virtual Store Store { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        
        public Discount()
        {
            ApplicableProductIds = new HashSet<Guid>();
            ApplicableCategoryIds = new HashSet<Guid>();
            ExcludedProductIds = new HashSet<Guid>();
            ExcludedCategoryIds = new HashSet<Guid>();
            ApplicableCustomerIds = new HashSet<Guid>();
            ApplicableCustomerGroups = new HashSet<string>();
            Orders = new HashSet<Order>();
            IsActive = true;
            AppliesToAllProducts = true;
            AppliesToAllCustomers = true;
            UsedCount = 0;
        }
        
        public bool IsValid => IsActive && DateTime.UtcNow >= StartDate && DateTime.UtcNow <= EndDate;
        public bool HasUsageLimit => UsageLimit.HasValue && UsedCount >= UsageLimit.Value;
        public bool IsExpired => DateTime.UtcNow > EndDate;
    }
} 