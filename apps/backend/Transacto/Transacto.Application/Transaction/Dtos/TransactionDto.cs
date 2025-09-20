/*
 * \file TransactionDto.cs
 * \brief Data transfer object representing transaction details
 *
 * \date 20-09-2025
 */

using Transacto.Application.Account.Dtos;
using Transacto.Application.Currency.Dtos;
using Transacto.Domain.Transaction.Enums;
using TransactionStatus = System.Transactions.TransactionStatus;

namespace Transacto.Application.Transaction.Dtos;

public class TransactionDto
{
    public Guid Id { get; private set; } = default!;
    public Guid FromAccountId { get; private set; } = default!;
    public AccountDto FromAccount { get; private set; } = default!;
    public Guid ToAccountId { get; private set; } = default!;
    public AccountDto ToAccount { get; private set; } = default!;

    public Guid? CurrencyId { get; private set; } = default!;
    public CurrencyDto? Currency { get; private set; } = default!;
    public decimal Amount { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public TransactionType Type { get; private set; } = default!;
    public TransactionStatus Status { get; private set; } = default!;
    public DateTime CreatedAt { get; private set; } = default!;
    public DateTime? CompletedAt { get; private set; } = default!;

    public Guid? ScheduledTransactionId { get; private set; } = default!;
    public ScheduledTransactionDto? ScheduledTransaction { get; private set; } = default!;
}