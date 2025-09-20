/*
 * \file FindAllTransactionsQuery.cs
 * \brief Query class for retrieving all transactions
 *
 * \date 20-09-2025
 */

using MediatR;
using Transacto.Application.Transaction.Dtos;

namespace Transacto.Application.Transaction.Queries.FindAllTransactions;

public class FindAllTransactionsQuery : IRequest<IEnumerable<TransactionDto>>
{
    
}