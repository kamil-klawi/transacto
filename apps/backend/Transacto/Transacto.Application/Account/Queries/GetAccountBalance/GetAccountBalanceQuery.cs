/*
 * \file GetAccountBalanceQuery.cs
 * \brief Query class for retrieving the account's current balance
 *
 * \date 17-09-2025
 */

using MediatR;
using Transacto.Application.Account.Dtos;

namespace Transacto.Application.Account.Queries.GetAccountBalance;

public class GetAccountBalanceQuery : IRequest<MoneyDto>
{
    public Guid Id { get; private set; } = default!;

    public GetAccountBalanceQuery(Guid id)
    {
        Id = id;
    }
}