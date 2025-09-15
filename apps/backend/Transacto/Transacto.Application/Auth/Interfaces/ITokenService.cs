/*
 * \file ITokenService.cs
 * \brief Interface for token generation service
 *
 * \date 15-09-2025
 */

using Transacto.Domain.Users.Entities;

namespace Transacto.Application.Auth.Interfaces;

public interface ITokenService
{
    string GenerateToken(User user);
}