/*
 * \file ICurrencyRepository.cs
 * \brief Currency interface representing currency repository
 *
 * \date 18-09-2025
 */

using EntityCurrency = Transacto.Domain.Currency.Entities.Currency;

namespace Transacto.Domain.Currency.Repository;

public interface ICurrencyRepository
{
    Task<IEnumerable<EntityCurrency>> GetAllCurrencies();
    Task<IEnumerable<EntityCurrency>> GetExchangeRates(string baseCurrencyCode);
    Task UpdateExchangeRate(EntityCurrency exchangeRate);
}