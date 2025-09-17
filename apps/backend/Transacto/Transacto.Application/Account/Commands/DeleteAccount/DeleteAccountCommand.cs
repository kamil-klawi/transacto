/*
 * \file DeleteAccountCommand.cs
 * \brief Command for deleting a user account
 *
 * Field:
 * - Id: The ID of the account
 * 
 * \date 17-09-2025
 */

using MediatR;

namespace Transacto.Application.Account.Commands.DeleteAccount;

public class DeleteAccountCommand : IRequest
{
    public Guid Id { get; private set; } = default!;

    public DeleteAccountCommand(Guid id)
    {
        Id = id;
    }
}