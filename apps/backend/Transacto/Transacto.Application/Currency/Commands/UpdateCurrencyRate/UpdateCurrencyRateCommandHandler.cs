/*
 * \file UpdateCurrencyRateCommandHandler.cs
 * \brief Handler for updating currency's exchange rate
 *
 * \date 18-09-2025
 */

using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Transacto.Domain.Currency.Repository;
using EntityCurrency = Transacto.Domain.Currency.Entities.Currency;

namespace Transacto.Application.Currency.Commands.UpdateCurrencyRate;

public class UpdateCurrencyRateCommandHandler(
    ILogger<UpdateCurrencyRateCommandHandler> logger,
    IMapper mapper,
    ICurrencyRepository currencyRepository
    ) : IRequestHandler<UpdateCurrencyRateCommand>
{
    public async Task Handle(UpdateCurrencyRateCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Update currency rate command");
        var currency = mapper.Map<EntityCurrency>(request);
        await currencyRepository.UpdateExchangeRate(currency);
    }
}