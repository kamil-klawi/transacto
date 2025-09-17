/*
 * \file GetAccountsQueryHandler.cs
 * \brief Query handler for retrieving all user accounts
 *
 * \date 17-09-2025
 */

using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Transacto.Application.Account.Dtos;
using Transacto.Domain.Account.Repositories;

namespace Transacto.Application.Account.Queries.GetAccounts;

public class GetAccountsQueryHandler(
    ILogger<GetAccountsQueryHandler> logger,
    IMapper mapper,
    IAccountRepository accountRepository
    ) : IRequestHandler<GetAccountsQuery, IEnumerable<AccountDto>>
{
    public async Task<IEnumerable<AccountDto>> Handle(GetAccountsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Retrieving all accounts");
        var accounts = await accountRepository.GetAccounts();
        return mapper.Map<IEnumerable<AccountDto>>(accounts);
    }
}