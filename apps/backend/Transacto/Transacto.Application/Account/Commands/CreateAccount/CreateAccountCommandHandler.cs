/*
 * \file CreateAccountCommandHandler.cs
 * \brief Handler for creating a new user account
 *
 * \date 17-09-2025
 */

using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Transacto.Domain.Account.Repositories;
using Entity = Transacto.Domain.Account.Entities.Account;

namespace Transacto.Application.Account.Commands.CreateAccount;

public class CreateAccountCommandHandler(
    ILogger<CreateAccountCommandHandler> logger,
    IMapper mapper,
    IAccountRepository accountRepository
    ) : IRequestHandler<CreateAccountCommand>
{
    public async Task Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating a new user account");
        var account = mapper.Map<Entity>(request);
        await accountRepository.CreateAccount(account);
    }
}