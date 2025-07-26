using System;
using System.Collections.Generic;
using HexaCommerce.Domain.ValueObjects;

namespace HexaCommerce.Domain.Entities
{
    public class User : BaseEntity
    {
        public Email Email { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime? LastLoginAt { get; set; }
        public string LastLoginIp { get; set; }
        public bool IsActive { get; set; }
        public bool IsLocked { get; set; }
        public DateTime? LockedUntil { get; set; }
        public int FailedLoginAttempts { get; set; }
        
        // Profile
        public string AvatarUrl { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        
        // Roles and Permissions
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<Store> OwnedStores { get; set; }
        
        public User()
        {
            UserRoles = new HashSet<UserRole>();
            OwnedStores = new HashSet<Store>();
            IsActive = true;
            IsLocked = false;
            FailedLoginAttempts = 0;
        }
        
        public string FullName => $"{FirstName} {LastName}".Trim();
        
        public void UpdateEmail(Email email)
        {
            Email = email;
            EmailConfirmed = false;
        }
        
        public void ConfirmEmail()
        {
            EmailConfirmed = true;
        }
        
        public void IncrementFailedLoginAttempts()
        {
            FailedLoginAttempts++;
            if (FailedLoginAttempts >= 5)
            {
                IsLocked = true;
                LockedUntil = DateTime.UtcNow.AddMinutes(30);
            }
        }
        
        public void ResetFailedLoginAttempts()
        {
            FailedLoginAttempts = 0;
            IsLocked = false;
            LockedUntil = null;
        }
    }
} 