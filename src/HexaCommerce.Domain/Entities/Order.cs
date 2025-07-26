using System;
using System.Collections.Generic;
using System.Linq;

namespace HexaCommerce.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Guid StoreId { get; set; }
        public Guid CustomerId { get; set; }
        public string OrderNumber { get; set; }
        public string Status { get; set; } // Pending, Confirmed, Processing, Shipped, Delivered, Cancelled, Refunded
        public DateTime? ConfirmedAt { get; set; }
        public DateTime? ShippedAt { get; set; }
        public DateTime? DeliveredAt { get; set; }
        public DateTime? CancelledAt { get; set; }
        public string CancellationReason { get; set; }
        
        // Pricing
        public decimal Subtotal { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal ShippingAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public string Currency { get; set; }
        
        // Payment
        public string PaymentStatus { get; set; } // Pending, Paid, Failed, Refunded
        public string PaymentMethod { get; set; }
        public string PaymentProvider { get; set; }
        public string TransactionId { get; set; }
        public DateTime? PaidAt { get; set; }
        
        // Shipping
        public string ShippingMethod { get; set; }
        public string TrackingNumber { get; set; }
        public string TrackingUrl { get; set; }
        public DateTime? EstimatedDeliveryDate { get; set; }
        
        // Customer Information
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string BillingAddress { get; set; }
        public string ShippingAddress { get; set; }
        public string Notes { get; set; }
        
        // Navigation
        public virtual Store Store { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<OrderHistory> OrderHistory { get; set; }
        
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
            OrderHistory = new HashSet<OrderHistory>();
            Status = "Pending";
            PaymentStatus = "Pending";
            Currency = "USD";
            Subtotal = 0;
            TaxAmount = 0;
            ShippingAmount = 0;
            DiscountAmount = 0;
            TotalAmount = 0;
        }
        
        public void CalculateTotals()
        {
            Subtotal = OrderItems.Sum(item => item.TotalPrice);
            TotalAmount = Subtotal + TaxAmount + ShippingAmount - DiscountAmount;
        }
        
        public bool CanBeCancelled => Status == "Pending" || Status == "Confirmed";
        public bool IsPaid => PaymentStatus == "Paid";
        public bool IsShipped => !string.IsNullOrEmpty(TrackingNumber);
    }
} 