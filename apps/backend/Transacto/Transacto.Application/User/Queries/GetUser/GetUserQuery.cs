/*
 * \file GetUserQuery.cs
 * \brief Query class for retrieving a user's details
 *
 * \date 16-09-2025
 */

using MediatR;
using Transacto.Application.User.Dtos;

namespace Transacto.Application.User.Queries.GetUser;

public class GetUserQuery : IRequest<UserDto>
{
    public Guid Id { get; private set; }

    public GetUserQuery(Guid id)
    {
        Id = id;
    }
}