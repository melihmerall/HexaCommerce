using System;
using System.Collections.Generic;

namespace HexaCommerce.Domain.Entities
{
    public class ShippingMethod : BaseEntity
    {
        public Guid StoreId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Carrier { get; set; } // UPS, FedEx, DHL, etc.
        public string ServiceType { get; set; } // Ground, Express, Overnight, etc.
        public decimal BaseCost { get; set; }
        public decimal? CostPerItem { get; set; }
        public decimal? CostPerWeight { get; set; }
        public string WeightUnit { get; set; } // kg, lb
        public int? EstimatedDaysMin { get; set; }
        public int? EstimatedDaysMax { get; set; }
        public bool IsActive { get; set; }
        public bool IsDefault { get; set; }
        public int DisplayOrder { get; set; }
        
        // Geographic restrictions
        public bool AppliesToAllCountries { get; set; }
        public virtual ICollection<string> ApplicableCountries { get; set; }
        public virtual ICollection<string> ExcludedCountries { get; set; }
        public virtual ICollection<string> ApplicableStates { get; set; }
        public virtual ICollection<string> ExcludedStates { get; set; }
        
        // Weight/Dimension restrictions
        public decimal? MinimumWeight { get; set; }
        public decimal? MaximumWeight { get; set; }
        public decimal? MinimumOrderAmount { get; set; }
        public decimal? MaximumOrderAmount { get; set; }
        
        // Navigation
        public virtual Store Store { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        
        public ShippingMethod()
        {
            ApplicableCountries = new HashSet<string>();
            ExcludedCountries = new HashSet<string>();
            ApplicableStates = new HashSet<string>();
            ExcludedStates = new HashSet<string>();
            Orders = new HashSet<Order>();
            IsActive = true;
            AppliesToAllCountries = true;
            WeightUnit = "kg";
            DisplayOrder = 0;
        }
        
        public string EstimatedDeliveryText
        {
            get
            {
                if (!EstimatedDaysMin.HasValue && !EstimatedDaysMax.HasValue)
                    return "Contact for estimate";
                
                if (EstimatedDaysMin == EstimatedDaysMax)
                    return $"{EstimatedDaysMin} business days";
                
                return $"{EstimatedDaysMin}-{EstimatedDaysMax} business days";
            }
        }
    }
} 