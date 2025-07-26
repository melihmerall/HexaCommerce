using System;

namespace HexaCommerce.Domain.Entities
{
    public class CustomerAddress : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public string AddressType { get; set; } // Billing, Shipping
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsDefault { get; set; }
        
        // Navigation
        public virtual Customer Customer { get; set; }
        
        public CustomerAddress()
        {
            IsDefault = false;
        }
        
        public string FullName => $"{FirstName} {LastName}".Trim();
        public string FullAddress => $"{AddressLine1}, {City}, {State} {PostalCode}, {Country}".Trim();
    }
} 