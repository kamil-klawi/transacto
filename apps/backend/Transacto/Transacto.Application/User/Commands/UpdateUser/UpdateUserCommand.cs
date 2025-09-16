/*
 * \file UpdateUserCommand.cs
 * \brief Command class for updating user details
 *
 * \date 16-09-2025
 */

using MediatR;
using Transacto.Domain.Users.ValueObjects;

namespace Transacto.Application.User.Commands.UpdateUser;

public class UpdateUserCommand : IRequest
{
    public Guid UserId { get; private set; }
    public Email Email { get; private set; }
    public PasswordHash PasswordHash { get; private set; }

    public UpdateUserCommand(Guid userId, Email email, PasswordHash passwordHash)
    {
        UserId = userId;
        Email = email;
        PasswordHash = passwordHash;
    }
}