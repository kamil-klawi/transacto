/*
 * \file CreateScheduledTransactionCommandHandler.cs
 * \brief Handler for creating scheduled transaction
 * 
 * \date 20-09-2025
 */

using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Transacto.Domain.Transaction.Entities;
using Transacto.Domain.Transaction.Repositories;

namespace Transacto.Application.Transaction.Commands.CreateScheduledTransaction;

public class CreateScheduledTransactionCommandHandler(
    ILogger<CreateScheduledTransactionCommandHandler> logger,
    IMapper mapper,
    ITransactionRepository transactionRepository
    ) : IRequestHandler<CreateScheduledTransactionCommand>
{
    public async Task Handle(CreateScheduledTransactionCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating scheduled transaction");
        var transaction = mapper.Map<ScheduledTransaction>(request);
        await transactionRepository.CreateScheduledTransaction(transaction);
    }
}