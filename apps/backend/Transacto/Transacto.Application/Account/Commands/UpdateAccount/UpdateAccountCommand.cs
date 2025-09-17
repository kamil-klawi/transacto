/*
 * \file UpdateAccountCommand.cs
 * \brief Command for updating a user account
 *
 * Fields:
 * - Id: The ID of the account
 * - Name: The display name of the account
 * - Type: The type of the account
 * 
 * \date 17-09-2025
 */

using MediatR;
using Transacto.Domain.Account.Enums;

namespace Transacto.Application.Account.Commands.UpdateAccount;

public class UpdateAccountCommand : IRequest
{
    public Guid Id { get; private set; } = default!;
    public string Name { get; private set; } = default!;
    public AccountType Type { get; private set; }

    public UpdateAccountCommand(Guid id)
    {
        Id = id;
    }
}