/*
 * \file Currency.cs
 * \brief Domain entity representing a currency
 *
 * Represents a currency in the domain layer, including its properties
 * such as code, name, exchange rate and last updated. Methods for currency operations
 * like update exchange rate
 *
 * \date 18-09-2025
 */

namespace Transacto.Domain.Currency.Entities;

public class Currency
{
    public string Code { get; private set; } = default!;
    public string Name { get; private set; } = default!;
    public decimal ExchangeRate { get; private set; } = default!;
    public DateTime LastUpdated { get; private set; } = default!;
    
    private Currency() { }

    public Currency(string code, string name, decimal exchangeRate, DateTime lastUpdated)
    {
        Code = code.ToUpperInvariant();
        Name = name;
        ExchangeRate = exchangeRate;
        LastUpdated = lastUpdated;
    }

    public void UpdateExchangeRate(decimal exchangeRate, DateTime lastUpdated)
    {
        if (exchangeRate <= 0)
            throw new ArgumentOutOfRangeException(nameof(exchangeRate), "Exchange rate must be greater than zero");
        
        ExchangeRate = exchangeRate;
        LastUpdated = lastUpdated;
    }
}