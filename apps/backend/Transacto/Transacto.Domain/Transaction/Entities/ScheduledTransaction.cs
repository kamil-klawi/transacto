/*
 * \file ScheduledTransaction.cs
 * \brief Domain entity representing a scheduled transaction
 *
 * Represents a scheduled transaction in the domain layer, including its properties
 * such as id, fromAccountId, toAccountId, currency, amount, description, type and scheduled date.
 * Methods for scheduled transaction operations like cancellation transaction
 *
 * \date 19-09-2025
 */

using Transacto.Domain.Transaction.Enums;
using EntityUser = Transacto.Domain.Users.Entities.User;
using EntityAccount = Transacto.Domain.Account.Entities.Account;
using EntityCurrency = Transacto.Domain.Currency.Entities.Currency;

namespace Transacto.Domain.Transaction.Entities;

public class ScheduledTransaction
{
    public Guid Id { get; private set; } = default!;
    public Guid UserId { get; private set; } = default!;
    public EntityUser User { get; private set; } = default!;
    public Guid FromAccountId { get; private set; } = default!;
    public EntityAccount FromAccount { get; private set; } = default!;
    public Guid ToAccountId { get; private set; } = default!;
    public EntityAccount ToAccount { get; private set; } = default!;

    public Guid? CurrencyId { get; private set; } = default!;
    public EntityCurrency? Currency { get; private set; } = default!;
    public decimal Amount { get; private set; } = default!;
    public TransactionType Type { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public DateTime ScheduledDate { get; private set; } = default!;
    public bool IsCancelled { get; private set; } = default!;
    
    private ScheduledTransaction() { }

    public ScheduledTransaction(
        Guid id,
        Guid userId,
        Guid fromAccountId,
        Guid toAccountId,
        Guid? currencyId,
        decimal amount,
        TransactionType type,
        string description,
        DateTime scheduledDate,
        bool isCancelled
        )
    {
        if (fromAccountId == toAccountId)
            throw new ArgumentException("From and To accounts cannot be the same.");

        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than zero.");

        if (scheduledDate < DateTime.UtcNow)
            throw new ArgumentException("Scheduled date must be in the future.");
        
        Id = id;
        UserId = userId;
        FromAccountId = fromAccountId;
        ToAccountId = toAccountId;
        CurrencyId = currencyId;
        Amount = amount;
        Type = type;
        Description = description;
        ScheduledDate = scheduledDate;
        IsCancelled = isCancelled;
    }
    
    public void Cancel()
    {
        if (IsCancelled)
            throw new InvalidOperationException("Scheduled transaction is already cancelled.");

        IsCancelled = true;
    }
}