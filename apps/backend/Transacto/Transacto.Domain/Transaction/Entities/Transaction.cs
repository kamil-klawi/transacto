/*
 * \file Transaction.cs
 * \brief Domain entity representing a transaction
 *
 * Represents a transaction in the domain layer, including its properties
 * such as id, fromAccountId, toAccountId, currency, amount, description,
 * type and created at. Methods for transaction operations like mark as
 * complete transaction
 *
 * \date 19-09-2025
 */

using Transacto.Domain.Transaction.Enums;
using EntityAccount = Transacto.Domain.Account.Entities.Account;
using EntityCurrency = Transacto.Domain.Currency.Entities.Currency;

namespace Transacto.Domain.Transaction.Entities;

public class Transaction
{
    public Guid Id { get; private set; } = default!;
    public Guid FromAccountId { get; private set; } = default!;
    public EntityAccount FromAccount { get; private set; } = default!;
    public Guid ToAccountId { get; private set; } = default!;
    public EntityAccount ToAccount { get; private set; } = default!;

    public Guid? CurrencyId { get; private set; } = default!;
    public EntityCurrency? Currency { get; private set; } = default!;
    public decimal Amount { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public TransactionType Type { get; private set; } = default!;
    public TransactionStatus Status { get; private set; } = default!;
    public DateTime CreatedAt { get; private set; } = default!;
    public DateTime? CompletedAt { get; private set; } = default!;

    public Guid? ScheduledTransactionId { get; private set; } = default!;
    public ScheduledTransaction? ScheduledTransaction { get; private set; } = default!;
    
    private Transaction() { }

    public Transaction(
        Guid id,
        Guid fromAccountId,
        Guid toAccountId,
        Guid? currencyId,
        decimal amount,
        string description,
        TransactionType type,
        TransactionStatus status,
        DateTime createdAt,
        DateTime? completedAt
        )
    {
        if (fromAccountId == toAccountId)
            throw new ArgumentException("From and To accounts cannot be the same.");

        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than zero.");
        
        Id = id;
        FromAccountId = fromAccountId;
        ToAccountId = toAccountId;
        CurrencyId = currencyId;
        Amount = amount;
        Description = description;
        Type = type;
        Status = status;
        CreatedAt = createdAt;
        CompletedAt = completedAt;
    }
    
    public void MarkAsCompleted(DateTime completedAt)
    {
        if (Status == TransactionStatus.Completed)
            throw new InvalidOperationException("Transaction is already completed.");

        Status = TransactionStatus.Completed;
        CompletedAt = completedAt;
    }
}