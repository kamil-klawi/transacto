/*
 * \file UpdateAccountCommandHandler.cs
 * \brief Handler for updating a user account
 *
 * \date 17-09-2025
 */

using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Transacto.Domain.Account.Repositories;
using Entity = Transacto.Domain.Account.Entities.Account;

namespace Transacto.Application.Account.Commands.UpdateAccount;

public class UpdateAccountCommandHandler(
    ILogger<UpdateAccountCommandHandler> logger,
    IMapper mapper,
    IAccountRepository accountRepository
    ) : IRequestHandler<UpdateAccountCommand>
{
    public async Task Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Updating a user account with id {request.Id}");
        var account = await accountRepository.GetAccount(request.Id);
        if (account == null)
            throw new ArgumentException($"Account not found: {request.Id}");
        
        mapper.Map(request, account);
        await accountRepository.UpdateAccount(account);
    }
}