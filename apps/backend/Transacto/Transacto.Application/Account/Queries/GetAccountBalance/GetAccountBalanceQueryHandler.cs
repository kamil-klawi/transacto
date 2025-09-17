/*
 * \file GetAccountBalanceQueryHandler.cs
 * \brief Query handler for retrieving the account's current balance
 *
 * \date 17-09-2025
 */

using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Transacto.Application.Account.Dtos;
using Transacto.Domain.Account.Repositories;

namespace Transacto.Application.Account.Queries.GetAccountBalance;

public class GetAccountBalanceQueryHandler(
    ILogger<GetAccountBalanceQueryHandler> logger,
    IMapper mapper,
    IAccountRepository accountRepository
    ) : IRequestHandler<GetAccountBalanceQuery, MoneyDto>
{
    public async Task<MoneyDto> Handle(GetAccountBalanceQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Retrieving account balance with id {request.Id}");
        var account = await accountRepository.GetAccount(request.Id);
        if (account == null)
            throw new ArgumentException("Account not found");
        
        var balance = await accountRepository.GetAccountBalance(account.Id);
        var balanceDto = mapper.Map<MoneyDto>(balance);
        return balanceDto;
    }
}