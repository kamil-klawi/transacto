/*
 * \file GetAccountSummaryQuery.cs
 * \brief Query class for retrieving summary of inflows and outflows
 *
 * \date 17-09-2025
 */

using MediatR;
using Transacto.Application.Account.Dtos;

namespace Transacto.Application.Account.Queries.GetAccountSummary;

public class GetAccountSummaryQuery : IRequest<AccountSummaryDto>
{
    public Guid Id { get; private set; } = default!;

    public GetAccountSummaryQuery(Guid id)
    {
        Id = id;
    }
}