/*
 * \file UserController.cs
 * \brief Command handler for enabling two-factor authentication
 * 
 * \date 16-09-2025
 */

using MediatR;
using OtpNet;
using Transacto.Domain.Users.Repositories;

namespace Transacto.Application.Auth.Commands.EnableTwoFactor;

public class EnableTwoFactorCommandHandler(
    IUserRepository userRepository
    ) : IRequestHandler<EnableTwoFactorCommand, string>
{
    public async Task<string> Handle(EnableTwoFactorCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(request.Id);
        if (user == null)
            throw new InvalidOperationException("User not found");
        
        var secretKey = GenerateTwoFactorSecret();
        user.EnableTwoFactor(secretKey);
        await userRepository.UpdateAsync(user);
        return secretKey;
    }
    
    private static string GenerateTwoFactorSecret(int length = 20)
    {
        var secret = KeyGeneration.GenerateRandomKey(20);
        return Base32Encoding.ToString(secret);
    }
}