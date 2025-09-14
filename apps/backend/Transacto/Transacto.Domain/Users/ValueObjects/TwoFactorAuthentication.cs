/*
 * \file TwoFactorAuthentication.cs
 * \brief Value Object representing user's two-factor authentication
 *
 * The TwoFactorAuthentication class defines a value object
 * that encapsulates the state of two-factor authentication
 * (2FA) for a user
 * 
 * \date 14-09-2025
 */

using Microsoft.EntityFrameworkCore;

namespace Transacto.Domain.Users.ValueObjects;

[Owned]
public class TwoFactorAuthentication
{
    public bool Enabled { get; private set; }
    public string? SecretKey { get; private set; }
    public DateTime? LastVerified { get; private set; }
    
    private TwoFactorAuthentication() {}

    public TwoFactorAuthentication(bool enabled, string secretKey, DateTime? lastVerified)
    {
        Enabled = enabled;
        SecretKey = secretKey;
        LastVerified = lastVerified;
    }

    public static TwoFactorAuthentication Enable(string secretKey)
    {
        return new TwoFactorAuthentication(true, secretKey, DateTime.UtcNow);
    }

    public static TwoFactorAuthentication Disable()
    {
        return new TwoFactorAuthentication(false, string.Empty, null);
    }
}