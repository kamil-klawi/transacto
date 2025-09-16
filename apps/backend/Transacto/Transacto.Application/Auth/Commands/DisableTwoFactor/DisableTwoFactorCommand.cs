/*
 * \file DisableTwoFactorCommand.cs
 * \brief Command class for disabling two-factor authentication
 *
 * \date 16-09-2025
 */

using MediatR;

namespace Transacto.Application.Auth.Commands.DisableTwoFactor;

public class DisableTwoFactorCommand : IRequest
{
    public Guid Id { get; private set; }

    public DisableTwoFactorCommand(Guid id)
    {
        Id = id;
    }
}