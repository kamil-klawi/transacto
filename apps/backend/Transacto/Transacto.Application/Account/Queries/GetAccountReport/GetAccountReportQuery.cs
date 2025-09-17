/*
 * \file GetAccountReportQuery.cs
 * \brief Query class for retrieving a PDF report of the account
 *
 * \date 17-09-2025
 */

using MediatR;

namespace Transacto.Application.Account.Queries.GetAccountReport;

public class GetAccountReportQuery : IRequest<byte[]>
{
    public Guid Id { get; private set; } = default!;

    public GetAccountReportQuery(Guid id)
    {
        Id = id;
    }
}