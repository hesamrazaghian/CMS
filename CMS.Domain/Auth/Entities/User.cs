using CMS.Domain.Auth.Enums;
using System;

namespace CMS.Domain.Auth.Entities
{
    public class User
    {
        #region Identity

        public Guid Id { get; init; }

        #endregion

        #region Credentials

        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }

        #endregion

        #region Account Status

        public UserStatus Status { get; private set; } = UserStatus.Active;

        public bool IsEmailConfirmed { get; private set; }

        #endregion

        #region Audit

        public DateTime CreatedAt { get; init; } = DateTime.UtcNow;

        public DateTime? LastLoginAt { get; set; }

        #endregion

        #region Constructors

        public User( )
        {
            Status = UserStatus.Active;
        }

        public User( string username, string email, string passwordHash )
        {
            Id = Guid.NewGuid( );
            Username = username;
            Email = email;
            PasswordHash = passwordHash;
            Status = UserStatus.Active;
            CreatedAt = DateTime.UtcNow;
        }

        #endregion

        #region Domain Behaviors

        public void ConfirmEmail( )
        {
            IsEmailConfirmed = true;
        }

        public void RecordLogin( )
        {
            LastLoginAt = DateTime.UtcNow;
        }

        public void Deactivate( )
        {
            Status = UserStatus.Inactive;
        }

        #endregion
    }
}
