/*
 * \file GetCurrenciesRatesQueryHandler.cs
 * \brief Query handler for retrieving exchange rates for a base currency
 *
 * \date 18-09-2025
 */

using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Transacto.Application.Currency.Dtos;
using Transacto.Domain.Currency.Repository;

namespace Transacto.Application.Currency.Queries.GetCurrenciesRates;

public class GetCurrenciesRatesQueryHandler(
    ILogger<GetCurrenciesRatesQueryHandler> logger,
    IMapper mapper,
    ICurrencyRepository currencyRepository
    ): IRequestHandler<GetCurrenciesRatesQuery, IEnumerable<CurrencyDto>>
{
    public async Task<IEnumerable<CurrencyDto>> Handle(GetCurrenciesRatesQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Retrieving currencies rates");
        var currencies = await currencyRepository.GetExchangeRates(request.BaseCurrencyCode);
        return mapper.Map<IEnumerable<CurrencyDto>>(currencies);
    }
}