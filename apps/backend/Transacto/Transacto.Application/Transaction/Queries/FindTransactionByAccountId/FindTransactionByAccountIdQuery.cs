/*
 * \file FindTransactionByAccountIdQuery.cs
 * \brief Query class for retrieving all transactions associated with a specific account id
 *
 * \date 20-09-2025
 */

using MediatR;
using Transacto.Application.Transaction.Dtos;

namespace Transacto.Application.Transaction.Queries.FindTransactionByAccountId;

public class FindTransactionByAccountIdQuery : IRequest<IEnumerable<TransactionDto>>
{
    public Guid AccountId { get; private set; } = default!;

    public FindTransactionByAccountIdQuery(Guid accountId)
    {
        AccountId = accountId;
    }
}