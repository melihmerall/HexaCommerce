using System;
using System.Collections.Generic;

namespace HexaCommerce.Domain.Entities
{
    public class Inventory : BaseEntity
    {
        public Guid StoreId { get; set; }
        public Guid ProductId { get; set; }
        public Guid? ProductVariantId { get; set; }
        public string Sku { get; set; }
        public int CurrentStock { get; set; }
        public int ReservedStock { get; set; }
        public int AvailableStock { get; set; }
        public int MinimumStockLevel { get; set; }
        public int MaximumStockLevel { get; set; }
        public bool TrackInventory { get; set; }
        public bool AllowBackorders { get; set; }
        public bool AllowPreorders { get; set; }
        public DateTime? LastStockUpdate { get; set; }
        public string LastStockUpdateBy { get; set; }
        public string Notes { get; set; }
        
        // Location tracking
        public string WarehouseLocation { get; set; }
        public string BinLocation { get; set; }
        public string ShelfLocation { get; set; }
        
        // Cost tracking
        public decimal? AverageCost { get; set; }
        public decimal? LastPurchaseCost { get; set; }
        public DateTime? LastPurchaseDate { get; set; }
        
        // Navigation
        public virtual Store Store { get; set; }
        public virtual Product Product { get; set; }
        public virtual ProductVariant ProductVariant { get; set; }
        public virtual ICollection<InventoryTransaction> Transactions { get; set; }
        
        public Inventory()
        {
            Transactions = new HashSet<InventoryTransaction>();
            TrackInventory = true;
            AllowBackorders = false;
            AllowPreorders = false;
            MinimumStockLevel = 0;
            MaximumStockLevel = 1000;
        }
        
        public void UpdateStock(int quantity, string transactionType, string notes = null)
        {
            var transaction = new InventoryTransaction
            {
                InventoryId = Id,
                Quantity = quantity,
                TransactionType = transactionType,
                PreviousStock = CurrentStock,
                Notes = notes
            };
            
            switch (transactionType.ToLower())
            {
                case "in":
                case "purchase":
                case "return":
                    CurrentStock += quantity;
                    break;
                case "out":
                case "sale":
                case "adjustment":
                    CurrentStock -= quantity;
                    break;
                case "reserve":
                    ReservedStock += quantity;
                    break;
                case "unreserve":
                    ReservedStock -= quantity;
                    break;
            }
            
            AvailableStock = CurrentStock - ReservedStock;
            LastStockUpdate = DateTime.UtcNow;
            
            Transactions.Add(transaction);
        }
        
        public bool IsLowStock => CurrentStock <= MinimumStockLevel;
        public bool IsOutOfStock => CurrentStock <= 0;
        public bool CanFulfillOrder(int quantity) => AvailableStock >= quantity || AllowBackorders;
    }
} 