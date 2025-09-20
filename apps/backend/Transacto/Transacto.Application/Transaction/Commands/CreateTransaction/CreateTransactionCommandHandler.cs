/*
 * \file CreateTransactionCommandHandler.cs
 * \brief Handler for creating transaction
 * 
 * \date 20-09-2025
 */

using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Transacto.Domain.Transaction.Repositories;
using EntityTransaction = Transacto.Domain.Transaction.Entities.Transaction;

namespace Transacto.Application.Transaction.Commands.CreateTransaction;

public class CreateTransactionCommandHandler(
    ILogger<CreateTransactionCommandHandler> logger,
    IMapper mapper,
    ITransactionRepository transactionRepository
    ) : IRequestHandler<CreateTransactionCommand>
{
    public async Task Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating transaction");
        var transaction = mapper.Map<EntityTransaction>(request);
        await transactionRepository.CreateTransaction(transaction);
    }
}