/*
 * \file FindTransactionByIdQuery.cs
 * \brief Query class for retrieving transaction associated with a specific id
 *
 * \date 20-09-2025
 */

using MediatR;
using Transacto.Application.Transaction.Dtos;

namespace Transacto.Application.Transaction.Queries.FindTransactionById;

public class FindTransactionByIdQuery : IRequest<TransactionDto?>
{
    public Guid Id { get; private set; } = default!;

    public FindTransactionByIdQuery(Guid id)
    {
        Id = id;
    }
}