/*
 * \file CancelScheduledTransactionCommand.cs
 * \brief Handler for cancellation scheduled transaction
 * 
 * \date 20-09-2025
 */

using MediatR;
using Microsoft.Extensions.Logging;
using Transacto.Domain.Transaction.Repositories;

namespace Transacto.Application.Transaction.Commands.CancelScheduledTransaction;

public class CancelScheduledTransactionCommandHandler(
    ILogger<CancelScheduledTransactionCommandHandler> logger,
    ITransactionRepository transactionRepository
    ) : IRequestHandler<CancelScheduledTransactionCommand>
{
    public async Task Handle(CancelScheduledTransactionCommand request, CancellationToken cancellationToken)
    {
        logger.LogTrace($"Canceling transaction {request.Id}");
        await transactionRepository.CancelScheduledTransaction(request.Id);
    }
}