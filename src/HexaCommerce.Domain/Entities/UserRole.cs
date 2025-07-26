using System;

namespace HexaCommerce.Domain.Entities
{
    public class UserRole : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
        public Guid? StoreId { get; set; } // For store-specific roles
        
        // Navigation
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
        public virtual Store Store { get; set; }
    }
} 