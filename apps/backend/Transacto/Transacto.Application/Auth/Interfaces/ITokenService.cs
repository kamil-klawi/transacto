/*
 * \file ITokenService.cs
 * \brief Interface for token generation service
 *
 * \date 15-09-2025
 */

namespace Transacto.Application.Auth.Interfaces;

public interface ITokenService
{
    string GenerateToken(Domain.Users.Entities.User user);
}