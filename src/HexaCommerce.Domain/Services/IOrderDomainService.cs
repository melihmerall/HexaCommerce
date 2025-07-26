using System;
using System.Threading.Tasks;
using HexaCommerce.Domain.Entities;

namespace HexaCommerce.Domain.Services
{
    public interface IOrderDomainService : IDomainService
    {
        Task<string> GenerateOrderNumberAsync(Guid storeId);
        Task<bool> CanCancelOrderAsync(Order order);
        Task<bool> CanRefundOrderAsync(Order order);
        Task<decimal> CalculateOrderTotalAsync(Order order);
        Task<bool> ValidateOrderItemsAsync(Order order);
        Task<bool> CheckInventoryAvailabilityAsync(Order order);
        Task UpdateInventoryAsync(Order order);
        Task<Order> CreateOrderFromCartAsync(Guid customerId, Guid storeId);
    }
} 