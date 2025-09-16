/*
 * \file GetUserQueryHandler.cs
 * \brief Query handler for retrieving a user's details
 *
 * \date 16-09-2025
 */

using AutoMapper;
using MediatR;
using Transacto.Application.User.Dtos;
using Transacto.Domain.Users.Repositories;

namespace Transacto.Application.User.Queries.GetUser;

public class GetUserQueryHandler(
    IUserRepository userRepository,
    IMapper mapper
    ) : IRequestHandler<GetUserQuery, UserDto>
{
    public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(request.Id);
        if (user == null)
            throw new ArgumentException($"User with id {request.Id} not found");
        
        return mapper.Map<UserDto>(user);
    }
}