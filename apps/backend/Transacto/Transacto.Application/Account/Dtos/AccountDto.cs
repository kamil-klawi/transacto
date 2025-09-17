/*
 * \file AccountDto.cs
 * \brief Data transfer object representing account details
 *
 * \date 17-09-2025
 */


using Transacto.Domain.Account.Enums;

namespace Transacto.Application.Account.Dtos;

public class AccountDto
{
    public Guid Id { get; private set; } = default!;
    public string Name { get; private set; } = default!;
    public Guid UserId { get; private set; } = default!;
    public AccountType Type { get; private set; } = default!;
    public MoneyDto Balance { get; private set; } = default!;
    public bool IsClosed { get; private set; } = default!;
    public DateTime? ClosedAt { get; private set; } = default!;
    public DateTime CreatedAt { get; private set; } = default!;
    public List<AccountSummaryDto> Summaries { get; private set; } = new();
}