/*
 * \file AuthResult.cs
 * \brief DTO representing the result of an authentication operation
 *
 * \date 15-09-2025
 */

namespace Transacto.Application.Auth.Dtos;

public class AuthResult
{
    public bool Success { get; private set; }
    public Guid? UserId { get; private set; }
    public string? Email { get; private set; }
    public string? Token { get; private set; }
    public string? ErrorMessage { get; private set; }

    public static AuthResult SuccessResult(Guid userId, string email, string token)
    {
        return new AuthResult
        {
            Success = true,
            UserId = userId,
            Email = email,
            Token = token,
        };
    }
    
    public static AuthResult Failure(string errorMessage)
    {
        return new AuthResult
        {
            Success = false,
            ErrorMessage = errorMessage
        };
    }
}