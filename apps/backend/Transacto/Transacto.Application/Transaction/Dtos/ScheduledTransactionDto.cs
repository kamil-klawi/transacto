/*
 * \file ScheduledTransactionDto.cs
 * \brief Data transfer object representing scheduled transaction details
 *
 * \date 20-09-2025
 */

using Transacto.Application.Account.Dtos;
using Transacto.Application.Currency.Dtos;
using Transacto.Application.User.Dtos;
using Transacto.Domain.Transaction.Enums;

namespace Transacto.Application.Transaction.Dtos;

public class ScheduledTransactionDto
{
    public Guid Id { get; private set; } = default!;
    public Guid UserId { get; private set; } = default!;
    public UserDto User { get; private set; } = default!;
    public Guid FromAccountId { get; private set; } = default!;
    public AccountDto FromAccount { get; private set; } = default!;
    public Guid ToAccountId { get; private set; } = default!;
    public AccountDto ToAccount { get; private set; } = default!;

    public Guid? CurrencyId { get; private set; } = default!;
    public CurrencyDto? Currency { get; private set; } = default!;
    public decimal Amount { get; private set; } = default!;
    public TransactionType Type { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public DateTime ScheduledDate { get; private set; } = default!;
    public bool IsCancelled { get; private set; } = default!;
}