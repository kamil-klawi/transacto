/*
 * \file RegisterCommandHandler.cs
 * \brief Handler for registering a new user
 *
 * The RegisterCommandHandler handles the registration process by checking
 * if a user with the given email exists, mapping the registration data
 * to a User entity, saving it and generating an authentication token
 *
 * \date 15-09-2025
 */

using AutoMapper;
using MediatR;
using Transacto.Application.Auth.Dtos;
using Transacto.Application.Auth.Interfaces;
using Transacto.Domain.Users.Repositories;

namespace Transacto.Application.Auth.Commands.Register;

public class RegisterCommandHandler(
    IUserRepository userRepository,
    ITokenService tokenService,
    IMapper mapper
    ) : IRequestHandler<RegisterCommand, AuthResult>
{
    public async Task<AuthResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var existingUser = await userRepository.GetByEmailAsync(request.Email);
        if (existingUser != null)
            return AuthResult.Failure($"{nameof(existingUser.Email)} does already exists");
        
        var user = mapper.Map<Domain.Users.Entities.User>(request);
        await userRepository.CreateAsync(user);
        var token = tokenService.GenerateToken(user);
        return AuthResult.SuccessResult(user.Id, user.Email, token);
    }
}