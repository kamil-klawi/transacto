/*
 * \file TransactionRepository.cs
 * \brief Implementation of ITransactionRepository using Entity Framework Core
 *
 * \date 19-09-2025
 */

using Microsoft.EntityFrameworkCore;
using Transacto.Domain.Transaction.Entities;
using Transacto.Domain.Transaction.Repositories;
using Transacto.Infrastructure.Persistence;

namespace Transacto.Infrastructure.Repositories;

public class TransactionRepository(ApplicationDbContext context) : ITransactionRepository
{
    public async Task<Transaction> CreateTransaction(Transaction transaction)
    {
        await context.Transactions.AddAsync(transaction);
        await context.SaveChangesAsync();
        return transaction;
    }

    public async Task<IEnumerable<Transaction>> FindAllTransactions()
    {
        return await context.Transactions
            .Include(t => t.FromAccount)
            .Include(t => t.ToAccount)
            .Include(t => t.Currency)
            .ToListAsync();
    }

    public async Task<IEnumerable<Transaction?>> FindTransactionByAccountId(Guid accountId)
    {
        return await context.Transactions
            .Where(t => t.FromAccountId == accountId || t.ToAccountId == accountId)
            .Include(t => t.Currency)
            .ToListAsync();
    }

    public async Task<Transaction?> FindTransactionById(Guid id)
    {
        return await context.Transactions
            .Include(t => t.Currency)
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<ScheduledTransaction> CreateScheduledTransaction(ScheduledTransaction transaction)
    {
        await context.ScheduledTransactions.AddAsync(transaction);
        await context.SaveChangesAsync();
        return transaction;
    }

    public async Task<IEnumerable<ScheduledTransaction>> FindAllScheduledTransactions()
    {
        return await context.ScheduledTransactions
            .Include(t => t.FromAccount)
            .Include(t => t.ToAccount)
            .Include(t => t.Currency)
            .ToListAsync();
    }

    public async Task CancelScheduledTransaction(Guid id)
    {
        var transaction = await context.ScheduledTransactions.FirstOrDefaultAsync(t => t.Id == id);
        if (transaction == null)
            throw new ArgumentNullException(nameof(transaction));

        if (transaction.IsCancelled)
            throw new ArgumentException("Transaction is already cancelled", nameof(id));
        
        transaction.Cancel();
        context.ScheduledTransactions.Update(transaction);
        await context.SaveChangesAsync();
    }
}