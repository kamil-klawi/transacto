/*
 * \file ITransactionRepository.cs
 * \brief Transaction interface representing transaction repository
 *
 * \date 19-09-2025
 */

using EntityTransaction = Transacto.Domain.Transaction.Entities.Transaction;
using EntityScheduledTransaction = Transacto.Domain.Transaction.Entities.ScheduledTransaction;

namespace Transacto.Domain.Transaction.Repositories;

public interface ITransactionRepository
{
    Task<EntityTransaction> CreateTransaction(EntityTransaction transaction);
    Task<IEnumerable<EntityTransaction>> FindAllTransactions();
    Task<IEnumerable<EntityTransaction?>> FindTransactionByAccountId(Guid accountId);
    Task<EntityTransaction?> FindTransactionById(Guid id);
    Task<EntityScheduledTransaction> CreateScheduledTransaction(EntityScheduledTransaction transaction);
    Task<IEnumerable<EntityScheduledTransaction>> FindAllScheduledTransactions();
    Task CancelScheduledTransaction(Guid id);
}