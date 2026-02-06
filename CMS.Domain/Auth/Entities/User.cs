using CMS.Domain.Auth.Enums;
using System;

namespace CMS.Domain.Auth.Entities
{
    public class User
    {
        #region Identity

        // Unique identifier of the user entity
        public Guid Id { get; private set; }

        #endregion

        #region Credentials

        // Username used for authentication
        public string Username { get; private set; }

        // Email address used for identification and communication
        public string Email { get; private set; }

        // Hashed password stored for authentication
        public string PasswordHash { get; private set; }

        #endregion

        #region Account Status

        // Current status of the user account
        public UserStatus Status { get; private set; }

        // Indicates whether the user's email has been confirmed
        public bool IsEmailConfirmed { get; private set; }

        #endregion

        #region Audit

        // Date and time when the user account was created
        public DateTime CreatedAt { get; private set; }

        // Date and time of the user's last successful login
        public DateTime? LastLoginAt { get; private set; }

        #endregion

        #region EF Core

        // Parameterless constructor required by Entity Framework Core
        protected User( ) { }

        #endregion

        #region Constructors

        // Creates a new active user with required authentication data
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

        // Marks the user's email as confirmed
        public void ConfirmEmail( )
        {
            IsEmailConfirmed = true;
        }

        // Records the time of a successful login
        public void RecordLogin( )
        {
            LastLoginAt = DateTime.UtcNow;
        }

        // Deactivates the user account
        public void Deactivate( )
        {
            Status = UserStatus.Inactive;
        }

        #endregion
    }
}
