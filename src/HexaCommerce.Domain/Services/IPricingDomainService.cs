using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HexaCommerce.Domain.Entities;

namespace HexaCommerce.Domain.Services
{
    public interface IPricingDomainService : IDomainService
    {
        Task<decimal> CalculateProductPriceAsync(Product product, Guid? customerId = null);
        Task<decimal> CalculateDiscountedPriceAsync(Product product, decimal originalPrice);
        Task<decimal> CalculateTaxAmountAsync(decimal subtotal, string country, string state);
        Task<decimal> CalculateShippingCostAsync(IEnumerable<OrderItem> items, string shippingMethod, string country);
        Task<decimal> ApplyDiscountsAsync(decimal subtotal, Guid customerId, Guid storeId);
        Task<bool> IsProductOnSaleAsync(Product product);
        Task<decimal> GetBulkDiscountAsync(int quantity, decimal unitPrice);
    }
} 