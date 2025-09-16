/*
 * \file EnableTwoFactorCommand.cs
 * \brief Command class for enabling two-factor authentication
 *
 * \date 16-09-2025
 */

using MediatR;

namespace Transacto.Application.Auth.Commands.EnableTwoFactor;

public class EnableTwoFactorCommand : IRequest<string>
{
    public Guid Id { get; private set; }

    public EnableTwoFactorCommand(Guid id)
    {
        Id = id;
    }
}