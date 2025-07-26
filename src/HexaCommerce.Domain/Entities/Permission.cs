using System;
using System.Collections.Generic;

namespace HexaCommerce.Domain.Entities
{
    public class Permission : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Resource { get; set; } // e.g., "Product", "Order", "Customer"
        public string Action { get; set; } // e.g., "Create", "Read", "Update", "Delete"
        public bool IsActive { get; set; }
        public bool IsSystem { get; set; }
        
        // Navigation
        public virtual ICollection<RolePermission> RolePermissions { get; set; }
        
        public Permission()
        {
            RolePermissions = new HashSet<RolePermission>();
            IsActive = true;
            IsSystem = false;
        }
        
        public string FullName => $"{Resource}.{Action}";
    }
} 