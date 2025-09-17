/*
 * \file MoneyDto.cs
 * \brief Data transfer object representing currency details 
 * 
 * \date 17-09-2025
 */

namespace Transacto.Application.Account.Dtos;

public class MoneyDto
{
    public decimal Amount { get; private set; } = default!;
    public string CurrencyCode { get; private set; } = default!;
}