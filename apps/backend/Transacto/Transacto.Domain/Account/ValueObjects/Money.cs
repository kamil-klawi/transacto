/*
 * \file Money.cs
 * \brief Value Object representing monetary amount with currency code
 * 
 * \date 17-09-2025
 */

using Microsoft.EntityFrameworkCore;

namespace Transacto.Domain.Account.ValueObjects;

[Owned]
public class Money
{
    public decimal Amount { get; private set; } = default!;
    public string CurrencyCode { get; private set; } = default!;
    
    private Money() { }

    public Money(decimal amount, string currencyCode)
    {
        if (string.IsNullOrWhiteSpace(currencyCode))
            throw new ArgumentException("Currency code cannot be empty.");
        
        Amount = amount;
        CurrencyCode = currencyCode;
    }

    public static Money operator +(Money a, Money b)
    {
        EnsureSameCurrency(a, b);
        return new Money(a.Amount + b.Amount, a.CurrencyCode);
    }

    public static Money operator -(Money a, Money b)
    {
        EnsureSameCurrency(a, b);
        return new Money(a.Amount - b.Amount, a.CurrencyCode);
    }
    
    private static void EnsureSameCurrency(Money a, Money b)
    {
        if (a.CurrencyCode != b.CurrencyCode)
            throw new InvalidOperationException("Currency mismatch.");
    }
}