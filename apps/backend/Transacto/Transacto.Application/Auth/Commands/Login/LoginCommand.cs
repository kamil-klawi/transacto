/*
 * \file LoginCommand.cs
 * \brief Command for logging in a user
 *
 * The LoginCommand class represents a request to authenticate
 * a user based on provided email and password
 *
 * \date 15-09-2025
 */

using MediatR;
using Transacto.Application.Auth.Dtos;

namespace Transacto.Application.Auth.Commands.Login;

public class LoginCommand : IRequest<AuthResult>
{
    public string Email { get; private set; } = default!;
    public string Password { get; private set; } = default!;
}