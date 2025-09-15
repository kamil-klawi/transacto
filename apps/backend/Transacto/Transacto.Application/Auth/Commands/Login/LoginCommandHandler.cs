/*
 * \file LoginCommandHandler.cs
 * \brief Handler for processing login commands
 *
 * The LoginCommandHandler handles user login requests by verifying
 * the user's email and password
 *
 * \date 15-09-2025
 */

using MediatR;
using Transacto.Application.Auth.Dtos;
using Transacto.Application.Auth.Interfaces;
using Transacto.Domain.Users.Repositories;

namespace Transacto.Application.Auth.Commands.Login;

public class LoginCommandHandler(
    IUserRepository userRepository, 
    ITokenService tokenService
    ) : IRequestHandler<LoginCommand, AuthResult>
{
    public async Task<AuthResult> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var existingUser = await userRepository.GetByEmailAsync(request.Email);
        if (existingUser == null)
            return AuthResult.Failure($"{nameof(existingUser.Email)} does not already exists");

        var isValidPassword = BCrypt.Net.BCrypt.Verify(request.Password, existingUser.PasswordHash);
        if (!isValidPassword)
        {
            existingUser.IncrementFailedLogin();
            if (existingUser.FailedLoginAttempts >= 5)
            {
                existingUser.LockAccount(DateTime.UtcNow.AddMinutes(15));
            }
            
            return AuthResult.Failure($"{nameof(existingUser.Email)} does not have the correct password");
        }
        
        if (existingUser.IsLocked && existingUser.LockoutEnd > DateTime.UtcNow)
            return AuthResult.Failure($"Account of user {nameof(existingUser.Email)} is locked");
        
        if (existingUser.FailedLoginAttempts > 0 || existingUser.IsLocked)
        {
            existingUser.UnlockAccount();
            await userRepository.UpdateAsync(existingUser);
        }
        
        var token = tokenService.GenerateToken(existingUser);
        return AuthResult.SuccessResult(existingUser.Id, existingUser.Email, token);
    }
}