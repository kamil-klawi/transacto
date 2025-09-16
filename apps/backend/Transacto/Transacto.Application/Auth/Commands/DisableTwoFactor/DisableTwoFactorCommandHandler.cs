/*
 * \file DisableTwoFactorCommandHandler.cs
 * \brief Command handler for disabling two-factor authentication
 *
 * \date 16-09-2025
 */

using MediatR;
using Transacto.Domain.Users.Repositories;

namespace Transacto.Application.Auth.Commands.DisableTwoFactor;

public class DisableTwoFactorCommandHandler(
    IUserRepository userRepository
    ) : IRequestHandler<DisableTwoFactorCommand>
{
    public async Task Handle(DisableTwoFactorCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(request.Id);
        if (user == null)
            throw new ArgumentException($"User with id {request.Id} not found");

        user.DisableTwoFactor();
        await userRepository.UpdateAsync(user);
    }
}