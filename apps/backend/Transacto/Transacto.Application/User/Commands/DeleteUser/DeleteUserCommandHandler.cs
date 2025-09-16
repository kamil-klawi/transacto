/*
 * \file DeleteUserCommandHandler.cs
 * \brief Command handler for deleting user
 * 
 * \date 16-09-2025
 */

using MediatR;
using Transacto.Domain.Users.Repositories;

namespace Transacto.Application.User.Commands.DeleteUser;

public class DeleteUserCommandHandler(
    IUserRepository userRepository
    ) : IRequestHandler<DeleteUserCommand>
{
    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(request.Id);
        if (user == null)
            throw new Exception("User not found");

        await userRepository.DeleteAsync(user.Id);
    }
}