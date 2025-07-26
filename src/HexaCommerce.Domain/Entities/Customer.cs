using System;
using System.Collections.Generic;

namespace HexaCommerce.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public Guid StoreId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public bool IsActive { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public DateTime? LastLoginAt { get; set; }
        public string LastLoginIp { get; set; }
        public int LoginCount { get; set; }
        
        // Addresses
        public virtual ICollection<CustomerAddress> Addresses { get; set; }
        
        // Orders and Shopping
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ICollection<WishlistItem> WishlistItems { get; set; }
        
        // Marketing
        public bool NewsletterSubscription { get; set; }
        public bool MarketingEmails { get; set; }
        public string CustomerGroup { get; set; }
        public decimal TotalSpent { get; set; }
        public int OrderCount { get; set; }
        
        // Navigation
        public virtual Store Store { get; set; }
        
        public Customer()
        {
            Addresses = new HashSet<CustomerAddress>();
            Orders = new HashSet<Order>();
            CartItems = new HashSet<CartItem>();
            WishlistItems = new HashSet<WishlistItem>();
            IsActive = true;
            NewsletterSubscription = false;
            MarketingEmails = false;
            TotalSpent = 0;
            OrderCount = 0;
            LoginCount = 0;
        }
        
        public string FullName => $"{FirstName} {LastName}".Trim();
    }
} 