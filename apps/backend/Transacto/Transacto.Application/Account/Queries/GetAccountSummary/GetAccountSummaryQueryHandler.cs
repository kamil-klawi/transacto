/*
 * \file GetAccountSummaryQueryHandler.cs
 * \brief Query handler for retrieving summary of inflows and outflows
 *
 * \date 17-09-2025
 */

using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Transacto.Application.Account.Dtos;
using Transacto.Domain.Account.Repositories;

namespace Transacto.Application.Account.Queries.GetAccountSummary;

public class GetAccountSummaryQueryHandler(
    ILogger<GetAccountSummaryQueryHandler> logger,
    IMapper mapper,
    IAccountRepository accountRepository
    ) : IRequestHandler<GetAccountSummaryQuery, AccountSummaryDto>
{
    public async Task<AccountSummaryDto> Handle(GetAccountSummaryQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Retrieving account summary with id {request.Id}");
        var account = await accountRepository.GetAccount(request.Id);
        if (account == null)
            throw new ArgumentException($"Account not found: {request.Id}");
        
        var summary = await accountRepository.GetAccountSummary(account.Id);
        var summaryDto = mapper.Map<AccountSummaryDto>(summary);
        return summaryDto;
    }
}