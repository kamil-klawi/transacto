/*
 * \file GetCurrenciesRatesQuery.cs
 * \brief Query class for retrieving exchange rates for a base currency
 *
 * \date 18-09-2025
 */


using MediatR;
using Transacto.Application.Currency.Dtos;

namespace Transacto.Application.Currency.Queries.GetCurrenciesRates;

public class GetCurrenciesRatesQuery : IRequest<IEnumerable<CurrencyDto>>
{
    public string BaseCurrencyCode { get; private set; } = default!;

    public GetCurrenciesRatesQuery(string baseCurrencyCode)
    {
        BaseCurrencyCode = baseCurrencyCode;
    }
}