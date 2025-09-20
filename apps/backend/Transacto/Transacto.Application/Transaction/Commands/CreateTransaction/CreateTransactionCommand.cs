/*
 * \file CancelScheduledTransactionCommand.cs
 * \brief Command for creating transaction
 * 
 * \date 20-09-2025
 */

using MediatR;
using Transacto.Domain.Transaction.Enums;

namespace Transacto.Application.Transaction.Commands.CreateTransaction;

public class CreateTransactionCommand : IRequest
{
    public Guid FromAccountId { get; private set; } = default!;
    public Guid ToAccountId { get; private set; } = default!;
    public Guid? CurrencyId { get; private set; } = default!;
    public decimal Amount { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public TransactionType Type { get; private set; } = default!;
}