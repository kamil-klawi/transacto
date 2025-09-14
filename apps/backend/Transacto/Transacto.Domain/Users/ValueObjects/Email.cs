/*
 * \file Email.cs
 * \brief Value Object representing user's email address
 *
 * The Email class defines a value object that encapsulates
 * a user's email address.
 *
 * \date 14-09-2025
 */

using Microsoft.EntityFrameworkCore;

namespace Transacto.Domain.Users.ValueObjects;

[Owned]
public class Email
{
    public string Value { get; private set; } = default!;
    
    private Email() {}

    public Email(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Email is required");
        
        if (!value.Contains("@"))
            throw new ArgumentException("Invalid email format");
        
        Value = value;
    }
    
    public override string ToString() => Value;
    
    public static implicit operator string(Email email) => email.Value;
}