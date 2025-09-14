/*
 * \file PasswordHash.cs
 * \brief Value Object representing a user's password
 *
 * The PasswordHash class defines a value object
 * that encapsulates the hashed password of a user
 *
 * \date 14-09-2025
 */

using Microsoft.EntityFrameworkCore;

namespace Transacto.Domain.Users.ValueObjects;

[Owned]
public sealed class PasswordHash
{
    public string Value { get; private set; } = default!;

    private PasswordHash() { }

    public PasswordHash(string hash)
    {
        if (string.IsNullOrWhiteSpace(hash))
            throw new ArgumentException("Password is required");

        Value = hash;
    }

    public override string ToString() => Value;

    public static implicit operator string(PasswordHash hash) => hash.Value;
}