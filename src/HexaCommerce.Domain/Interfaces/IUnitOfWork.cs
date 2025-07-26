using System;
using System.Threading.Tasks;
using HexaCommerce.Domain.Entities;

namespace HexaCommerce.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        // Repositories
        IRepository<Store> Stores { get; }
        IRepository<User> Users { get; }
        IRepository<Role> Roles { get; }
        IRepository<UserRole> UserRoles { get; }
        IRepository<Permission> Permissions { get; }
        IRepository<RolePermission> RolePermissions { get; }
        IRepository<Category> Categories { get; }
        IRepository<Product> Products { get; }
        IRepository<ProductImage> ProductImages { get; }
        IRepository<ProductVariant> ProductVariants { get; }
        IRepository<ProductAttribute> ProductAttributes { get; }
        IRepository<ProductTag> ProductTags { get; }
        IRepository<Customer> Customers { get; }
        IRepository<CustomerAddress> CustomerAddresses { get; }
        IRepository<Order> Orders { get; }
        IRepository<OrderItem> OrderItems { get; }
        IRepository<OrderHistory> OrderHistory { get; }
        IRepository<CartItem> CartItems { get; }
        IRepository<WishlistItem> WishlistItems { get; }
        IRepository<Discount> Discounts { get; }
        IRepository<ShippingMethod> ShippingMethods { get; }
        IRepository<Review> Reviews { get; }
        IRepository<Inventory> Inventories { get; }
        IRepository<InventoryTransaction> InventoryTransactions { get; }
        
        // Transaction methods
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
        Task<int> SaveChangesAsync();
    }
} 