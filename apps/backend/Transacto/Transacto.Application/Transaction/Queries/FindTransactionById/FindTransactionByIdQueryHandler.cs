/*
 * \file FindTransactionByIdQueryHandler.cs
 * \brief Query handler for retrieving transaction associated with a specific id
 *
 * \date 20-09-2025
 */

using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Transacto.Application.Transaction.Dtos;
using Transacto.Domain.Transaction.Repositories;

namespace Transacto.Application.Transaction.Queries.FindTransactionById;

public class FindTransactionByIdQueryHandler(
    ILogger<FindTransactionByIdQueryHandler> logger,
    IMapper mapper,
    ITransactionRepository transactionRepository
    ) : IRequestHandler<FindTransactionByIdQuery, TransactionDto?>
{
    public async Task<TransactionDto?> Handle(FindTransactionByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Finding transactions by id");
        var transaction = await transactionRepository.FindTransactionById(request.Id);
        if (transaction == null)
            throw new ArgumentException("Transaction not found", nameof(transaction));
        
        return mapper.Map<TransactionDto>(transaction);
    }
}