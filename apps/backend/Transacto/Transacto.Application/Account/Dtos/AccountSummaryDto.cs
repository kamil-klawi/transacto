/*
 * \file AccountSummaryDto.cs
 * \brief Data transfer object representing account summary details 
 * 
 * \date 17-09-2025
 */

namespace Transacto.Application.Account.Dtos;

public class AccountSummaryDto
{
    public Guid Id { get; private set; }
    public Guid AccountId { get; private set; }
    public DateOnly FromDate { get; private set; }
    public DateOnly ToDate { get; private set; }
    public AccountDto Account { get; private set; } = default!;
    public MoneyDto Inflow { get; private set;} = default!;
    public MoneyDto Outflow { get; private set; } = default!;
    public MoneyDto NetBalance { get; private set; } = default!;
}