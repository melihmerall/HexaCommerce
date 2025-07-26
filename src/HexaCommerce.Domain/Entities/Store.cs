using System;
using System.Collections.Generic;

namespace HexaCommerce.Domain.Entities
{
    public class Store : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Domain { get; set; }
        public string ConnectionString { get; set; }
        public string LogoUrl { get; set; }
        public string FaviconUrl { get; set; }
        public string PrimaryColor { get; set; }
        public string SecondaryColor { get; set; }
        public string Currency { get; set; }
        public string Language { get; set; }
        public string TimeZone { get; set; }
        public bool IsActive { get; set; }
        public bool IsPublished { get; set; }
        public DateTime? PublishedAt { get; set; }
        
        // Store Owner
        public Guid OwnerId { get; set; }
        public string OwnerEmail { get; set; }
        public string OwnerName { get; set; }
        
        // Contact Information
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        
        // Social Media
        public string FacebookUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string LinkedInUrl { get; set; }
        
        // SEO
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }
        
        // Navigation
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        
        public Store()
        {
            Categories = new HashSet<Category>();
            Products = new HashSet<Product>();
            Orders = new HashSet<Order>();
            Customers = new HashSet<Customer>();
            IsActive = true;
            IsPublished = false;
            Currency = "USD";
            Language = "en";
            TimeZone = "UTC";
        }
    }
} 