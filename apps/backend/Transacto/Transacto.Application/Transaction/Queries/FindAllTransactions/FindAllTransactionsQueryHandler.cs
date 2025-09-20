/*
 * \file FindAllTransactionsQueryHandler.cs
 * \brief Query handler for retrieving all scheduled transactions
 *
 * \date 20-09-2025
 */

using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Transacto.Application.Transaction.Dtos;
using Transacto.Domain.Transaction.Repositories;

namespace Transacto.Application.Transaction.Queries.FindAllTransactions;

public class FindAllTransactionsQueryHandler(
    ILogger<FindAllTransactionsQueryHandler> logger,
    IMapper mapper,
    ITransactionRepository transactionRepository
    ) : IRequestHandler<FindAllTransactionsQuery, IEnumerable<TransactionDto>>
{
    public async Task<IEnumerable<TransactionDto>> Handle(FindAllTransactionsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Finding all transactions");
        var transactions = await transactionRepository.FindAllTransactions();
        return mapper.Map<IEnumerable<TransactionDto>>(transactions);
    }
}