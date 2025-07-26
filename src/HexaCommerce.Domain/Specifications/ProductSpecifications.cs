using System;
using System.Linq.Expressions;
using HexaCommerce.Domain.Entities;

namespace HexaCommerce.Domain.Specifications
{
    public class ActiveProductsSpecification : BaseSpecification<Product>
    {
        public ActiveProductsSpecification(Guid storeId)
        {
            AddCriteria(p => p.StoreId == storeId && p.IsActive && p.IsPublished);
            AddOrderBy(p => p.Name);
        }
    }

    public class ProductsByCategorySpecification : BaseSpecification<Product>
    {
        public ProductsByCategorySpecification(Guid storeId, Guid categoryId)
        {
            AddCriteria(p => p.StoreId == storeId && p.CategoryId == categoryId && p.IsActive && p.IsPublished);
            AddOrderBy(p => p.Name);
        }
    }

    public class ProductsOnSaleSpecification : BaseSpecification<Product>
    {
        public ProductsOnSaleSpecification(Guid storeId)
        {
            AddCriteria(p => p.StoreId == storeId && p.IsOnSale && p.IsActive && p.IsPublished);
            AddOrderByDescending(p => p.CompareAtPrice - p.Price);
        }
    }

    public class ProductsInStockSpecification : BaseSpecification<Product>
    {
        public ProductsInStockSpecification(Guid storeId)
        {
            AddCriteria(p => p.StoreId == storeId && p.IsActive && p.IsPublished && 
                           (p.StockQuantity > 0 || !p.TrackInventory));
            AddOrderBy(p => p.Name);
        }
    }

    public class ProductsByPriceRangeSpecification : BaseSpecification<Product>
    {
        public ProductsByPriceRangeSpecification(Guid storeId, decimal minPrice, decimal maxPrice)
        {
            AddCriteria(p => p.StoreId == storeId && p.IsActive && p.IsPublished && 
                           p.Price >= minPrice && p.Price <= maxPrice);
            AddOrderBy(p => p.Price);
        }
    }

    public class FeaturedProductsSpecification : BaseSpecification<Product>
    {
        public FeaturedProductsSpecification(Guid storeId, int take = 10)
        {
            AddCriteria(p => p.StoreId == storeId && p.IsActive && p.IsPublished && p.IsFeatured);
            AddOrderBy(p => p.Name);
            ApplyPaging(0, take);
        }
    }
} 