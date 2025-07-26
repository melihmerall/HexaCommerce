using System;

namespace HexaCommerce.Domain.Entities
{
    public class RolePermission : BaseEntity
    {
        public Guid RoleId { get; set; }
        public Guid PermissionId { get; set; }
        public Guid? StoreId { get; set; } // For store-specific permissions
        
        // Navigation
        public virtual Role Role { get; set; }
        public virtual Permission Permission { get; set; }
        public virtual Store Store { get; set; }
    }
} 