using System;
using HexaCommerce.Domain.Entities;

namespace HexaCommerce.Domain.Events
{
    public class OrderCreatedEvent : BaseDomainEvent
    {
        public Guid OrderId { get; }
        public Guid CustomerId { get; }
        public decimal TotalAmount { get; }
        public string OrderNumber { get; }

        public OrderCreatedEvent(Order order)
        {
            OrderId = order.Id;
            CustomerId = order.CustomerId;
            TotalAmount = order.TotalAmount;
            OrderNumber = order.OrderNumber;
        }
    }

    public class OrderStatusChangedEvent : BaseDomainEvent
    {
        public Guid OrderId { get; }
        public string PreviousStatus { get; }
        public string NewStatus { get; }
        public string ChangedBy { get; }

        public OrderStatusChangedEvent(Guid orderId, string previousStatus, string newStatus, string changedBy)
        {
            OrderId = orderId;
            PreviousStatus = previousStatus;
            NewStatus = newStatus;
            ChangedBy = changedBy;
        }
    }

    public class OrderPaidEvent : BaseDomainEvent
    {
        public Guid OrderId { get; }
        public string PaymentMethod { get; }
        public string TransactionId { get; }
        public decimal Amount { get; }

        public OrderPaidEvent(Guid orderId, string paymentMethod, string transactionId, decimal amount)
        {
            OrderId = orderId;
            PaymentMethod = paymentMethod;
            TransactionId = transactionId;
            Amount = amount;
        }
    }
} 