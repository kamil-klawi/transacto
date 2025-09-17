/*
 * \file DeleteAccountCommandHandler.cs
 * \brief Handler for deleting a user account
 *
 * \date 17-09-2025
 */

using MediatR;
using Microsoft.Extensions.Logging;
using Transacto.Domain.Account.Repositories;

namespace Transacto.Application.Account.Commands.DeleteAccount;

public class DeleteAccountCommandHandler(
    ILogger<DeleteAccountCommandHandler> logger,
    IAccountRepository accountRepository
    ) : IRequestHandler<DeleteAccountCommand>
{
    public async Task Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Deleting a user account with Id {request.Id}");
        var account = await accountRepository.GetAccount(request.Id);
        if (account == null)
            throw new ArgumentException("Account not found");
        
        await accountRepository.DeleteAccount(request.Id);
    }
}