/*
 * \file GetAccountQueryHandler.cs
 * \brief Query handler for retrieving a specific user by id
 *
 * \date 17-09-2025
 */

using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Transacto.Application.Account.Dtos;
using Transacto.Domain.Account.Repositories;

namespace Transacto.Application.Account.Queries.GetAccount;

public class GetAccountQueryHandler(
    ILogger<GetAccountQueryHandler> logger, 
    IMapper mapper, 
    IAccountRepository accountRepository
    ) : IRequestHandler<GetAccountQuery, AccountDto>
{
    public async Task<AccountDto> Handle(GetAccountQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Retrieving account {request.Id}");
        var account = await accountRepository.GetAccount(request.Id);
        if (account == null)
            throw new ArgumentException("Account not found");
        
        var accountDto = mapper.Map<AccountDto>(account);
        return accountDto;
    }
}