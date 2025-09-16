/*
 * \file UserDto.cs
 * \brief Data transfer object representing a user's details
 *
 * \date 16-09-2025
 */

namespace Transacto.Application.User.Dtos;

public class UserDto
{
    public Guid Id { get; private set; }
    public string Email { get; private set; } = default!;
    public PersonalDataDto PersonalData { get; private set; } = default!;
}