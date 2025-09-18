/*
 * \file GetCurrenciesQueryHandler.cs
 * \brief Query handler for retrieving all currencies
 *
 * \date 18-09-2025
 */

using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Transacto.Application.Currency.Dtos;
using Transacto.Domain.Currency.Repository;

namespace Transacto.Application.Currency.Queries.GetCurrencies;

public class GetCurrenciesQueryHandler(
    ILogger<GetCurrenciesQueryHandler> logger,
    IMapper mapper,
    ICurrencyRepository currencyRepository
    ) : IRequestHandler<GetCurrenciesQuery, IEnumerable<CurrencyDto>>
{
    public async Task<IEnumerable<CurrencyDto>> Handle(GetCurrenciesQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Retrieving all currencies");
        var currencies = await currencyRepository.GetAllCurrencies();
        return mapper.Map<IEnumerable<CurrencyDto>>(currencies);
    }
}