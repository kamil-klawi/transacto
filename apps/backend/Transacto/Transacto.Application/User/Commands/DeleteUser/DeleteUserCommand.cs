/*
 * \file DeleteUserCommand.cs
 * \brief Command class for deleting user
 * 
 * \date 16-09-2025
 */

using MediatR;

namespace Transacto.Application.User.Commands.DeleteUser;

public class DeleteUserCommand : IRequest
{
    public Guid Id { get; private set; }

    public DeleteUserCommand(Guid id)
    {
        Id = id;
    }
}