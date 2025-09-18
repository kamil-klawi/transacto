/*
 * \file CurrencyDto.cs
 * \brief Data transfer object representing currency details
 *
 * \date 18-09-2025
 */

namespace Transacto.Application.Currency.Dtos;

public class CurrencyDto
{
    public string Code { get; private set; } = default!;
    public string Name { get; private set; } = default!;
    public decimal ExchangeRate { get; private set; } = default!;
    public DateTime LastUpdated { get; private set; } = default!;
}