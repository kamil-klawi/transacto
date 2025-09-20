/*
 * \file FindAllScheduledTransactionsQuery.cs
 * \brief Query class for retrieving all scheduled transactions
 *
 * \date 20-09-2025
 */

using MediatR;
using Transacto.Application.Transaction.Dtos;

namespace Transacto.Application.Transaction.Queries.FindAllScheduledTransactions;

public class FindAllScheduledTransactionsQuery : IRequest<IEnumerable<ScheduledTransactionDto>>
{
    
}