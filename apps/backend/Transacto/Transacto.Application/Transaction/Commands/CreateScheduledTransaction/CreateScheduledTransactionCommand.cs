/*
 * \file CreateScheduledTransactionCommand.cs
 * \brief Command for creating scheduled transaction
 * 
 * \date 20-09-2025
 */

using MediatR;
using Transacto.Domain.Transaction.Enums;

namespace Transacto.Application.Transaction.Commands.CreateScheduledTransaction;

public class CreateScheduledTransactionCommand : IRequest
{
    public Guid UserId { get; private set; } = default!;
    public Guid FromAccountId { get; private set; } = default!;
    public Guid ToAccountId { get; private set; } = default!;
    public Guid? CurrencyId { get; private set; } = default!;
    public decimal Amount { get; private set; } = default!;
    public TransactionType Type { get; private set; } = default!;
    public string Description { get; private set; } = default!;
}