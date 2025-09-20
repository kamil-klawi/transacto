/*
 * \file FindAllScheduledTransactionsQueryHandler.cs
 * \brief Query handler for retrieving all transactions
 *
 * \date 20-09-2025
 */

using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Transacto.Application.Transaction.Dtos;
using Transacto.Domain.Transaction.Repositories;

namespace Transacto.Application.Transaction.Queries.FindAllScheduledTransactions;

public class FindAllScheduledTransactionsQueryHandler(
    ILogger<FindAllScheduledTransactionsQueryHandler> logger,
    IMapper mapper,
    ITransactionRepository transactionRepository
    ) : IRequestHandler<FindAllScheduledTransactionsQuery, IEnumerable<ScheduledTransactionDto>>
{
    public async Task<IEnumerable<ScheduledTransactionDto>> Handle(FindAllScheduledTransactionsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Finding all scheduled transactions");
        var transactions = await transactionRepository.FindAllScheduledTransactions();
        return mapper.Map<IEnumerable<ScheduledTransactionDto>>(transactions);
    }
}