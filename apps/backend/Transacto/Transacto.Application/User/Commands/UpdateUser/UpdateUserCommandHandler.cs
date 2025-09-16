/*
 * \file UpdateUserCommandHandler.cs
 * \brief Command handler for updating user details
 *
 * \date 16-09-2025
 */

using MediatR;
using Transacto.Domain.Users.Repositories;

namespace Transacto.Application.User.Commands.UpdateUser;

public class UpdateUserCommandHandler(IUserRepository userRepository) : IRequestHandler<UpdateUserCommand>
{
    public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(request.UserId);
        if (user == null)
            throw new InvalidOperationException("User not found");
        
        if (user.PasswordHash != request.PasswordHash)
            user.ChangePassword(request.PasswordHash);
        
        if (user.Email != request.Email)
            user.ChangeEmail(request.Email);
        
        await userRepository.UpdateAsync(user);
    }
}