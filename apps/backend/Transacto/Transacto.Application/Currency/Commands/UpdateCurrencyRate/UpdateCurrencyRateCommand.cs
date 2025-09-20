/*
 * \file UpdateCurrencyRateCommand.cs
 * \brief Command for updating currency's exchange rate
 *
 * Fields:
 * - Code: The currency code
 * - Name: The display name of the currency
 * - ExchangeRate: The exchange rate for the currency
 * - LastUpdated: The date of the last exchange rate update
 * 
 * \date 18-09-2025
 */

using MediatR;

namespace Transacto.Application.Currency.Commands.UpdateCurrencyRate;

public class UpdateCurrencyRateCommand : IRequest
{
    public string Code { get; private set; } = default!;
    public string Name { get; private set; } = default!;
    public decimal ExchangeRate { get; private set; } = default!;
    public DateTime LastUpdated { get; private set; } = default!;
}