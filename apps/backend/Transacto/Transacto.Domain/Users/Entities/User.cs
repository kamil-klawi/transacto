/*
 * \file User.cs
 * \brief Entity class representing user
 *
 * The User class defines an entity class that encapsulates
 * all user-related data and behavior within the domain model
 * 
 * \date 14-09-2025
 */

using Transacto.Domain.Users.ValueObjects;

namespace Transacto.Domain.Users.Entities;

public class User
{
    public Guid Id { get; private set; }
    public Email Email { get; private set; } = default!;
    public PasswordHash PasswordHash { get; private set; } = default!;
    public PersonalData PersonalData { get; private set; } = default!;
    public TwoFactorAuthentication TwoFactorAuthentication { get; private set; } = default!;
    public bool IsLocked { get; private set; } = false;
    public int FailedLoginAttempts { get; private set; } = 0;
    public DateTime? LockoutEnd { get; private set; }
    
    private User() {}

    public User(Guid id, Email email, PasswordHash passwordHash, PersonalData personalData,
        TwoFactorAuthentication twoFactorAuthentication)
    {
        Id = id;
        Email = email;
        PasswordHash = passwordHash;
        PersonalData = personalData;
        TwoFactorAuthentication = twoFactorAuthentication;
    }
    
    public void EnableTwoFactor(string secretKey)
    {
        TwoFactorAuthentication = TwoFactorAuthentication.Enable(secretKey);
    }
    
    public void DisableTwoFactor()
    {
        TwoFactorAuthentication = TwoFactorAuthentication.Disable();
    }

    public void LockAccount(DateTime until)
    {
        IsLocked = true;
        LockoutEnd = until;
    }
    
    public void UnlockAccount()
    {
        IsLocked = false;
        LockoutEnd = null;
        FailedLoginAttempts = 0;
    }

    public void IncrementFailedLogin()
    {
        FailedLoginAttempts++;
    }

    public void ChangePassword(PasswordHash newPassword)
    {
        PasswordHash = newPassword;
    }
}