/*
 * \file GetAccountQuery.cs
 * \brief Query class for retrieving a specific user account by id
 *
 * \date 17-09-2025
 */

using MediatR;
using Transacto.Application.Account.Dtos;

namespace Transacto.Application.Account.Queries.GetAccount;

public class GetAccountQuery : IRequest<AccountDto>
{
    public Guid Id { get; private set; }

    public GetAccountQuery(Guid id)
    {
        Id = id;
    }
}