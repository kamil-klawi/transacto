/*
 * \file FindTransactionByAccountIdQueryHandler.cs
 * \brief Query handler for retrieving all transactions associated with a specific account id
 *
 * \date 20-09-2025
 */

using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Transacto.Application.Transaction.Dtos;
using Transacto.Domain.Transaction.Repositories;

namespace Transacto.Application.Transaction.Queries.FindTransactionByAccountId;

public class FindTransactionByAccountIdQueryHandler(
    ILogger<FindTransactionByAccountIdQueryHandler> logger,
    IMapper mapper,
    ITransactionRepository transactionRepository
    ) : IRequestHandler<FindTransactionByAccountIdQuery, IEnumerable<TransactionDto>>
{
    public async Task<IEnumerable<TransactionDto>> Handle(FindTransactionByAccountIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Finding transactions by account id: {request.AccountId}");
        var transaction = await transactionRepository.FindTransactionByAccountId(request.AccountId);
        if (transaction == null)
            throw new ArgumentException($"No transaction found for account id: {request.AccountId}");
        
        return mapper.Map<IEnumerable<TransactionDto>>(transaction);
    }
}