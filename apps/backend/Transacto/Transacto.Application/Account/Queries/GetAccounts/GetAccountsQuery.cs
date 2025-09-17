/*
 * \file GetAccountsQuery.cs
 * \brief Query class for retrieving all user accounts
 *
 * \date 17-09-2025
 */

using MediatR;
using Transacto.Application.Account.Dtos;

namespace Transacto.Application.Account.Queries.GetAccounts;

public class GetAccountsQuery : IRequest<IEnumerable<AccountDto>>
{
    
}