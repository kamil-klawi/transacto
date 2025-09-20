/*
 * \file CancelScheduledTransactionCommand.cs
 * \brief Command for cancellation scheduled transaction
 * 
 * \date 20-09-2025
 */

using MediatR;

namespace Transacto.Application.Transaction.Commands.CancelScheduledTransaction;

public class CancelScheduledTransactionCommand : IRequest
{
    public Guid Id { get; private set; } = default!;

    public CancelScheduledTransactionCommand(Guid id)
    {
        Id = id;
    }
}