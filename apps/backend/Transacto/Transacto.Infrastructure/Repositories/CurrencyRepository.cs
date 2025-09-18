/*
 * \file CurrencyRepository.cs
 * \brief Implementation of ICurrencyRepository using Entity Framework Core
 *
 * \date 18-09-2025
 */

using Microsoft.EntityFrameworkCore;
using Transacto.Domain.Currency.Entities;
using Transacto.Domain.Currency.Repository;
using Transacto.Infrastructure.Persistence;

namespace Transacto.Infrastructure.Repositories;

public class CurrencyRepository(ApplicationDbContext context) : ICurrencyRepository
{
    public async Task<IEnumerable<Currency>> GetAllCurrencies()
    {
        return await context.Currencies.ToListAsync();
    }

    public async Task<IEnumerable<Currency>> GetExchangeRates(string baseCurrencyCode)
    {
        if (baseCurrencyCode == null)
            throw new ArgumentNullException(nameof(baseCurrencyCode));
        
        var allCurrencies = await GetAllCurrencies();
        var baseCurrency = allCurrencies.FirstOrDefault(x => x.Code == baseCurrencyCode.ToUpperInvariant());
        
        if (baseCurrency == null)
            throw new ArgumentException($"Base currency '{baseCurrencyCode}' not found");

        var rates = allCurrencies
            .Where(x => x.Code != baseCurrency.Code)
            .Select(c => new Currency(
                code: c.Code,
                name: c.Name,
                exchangeRate: c.ExchangeRate,
                lastUpdated: c.LastUpdated));
        
        return rates;
    }

    public async Task UpdateExchangeRate(Currency exchangeRate)
    {
        var currency = await context.Currencies.FirstOrDefaultAsync(x => x.Code == exchangeRate.Code);
        if (currency == null)
            throw new ArgumentException($"Currency '{exchangeRate.Code}' not found");
        
        currency.UpdateExchangeRate(exchangeRate.ExchangeRate, DateTime.Now);
        context.Currencies.Update(currency);
        await context.SaveChangesAsync();
    }
}