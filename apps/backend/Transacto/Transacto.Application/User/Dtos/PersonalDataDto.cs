/*
 * \file PersonalDataDto.cs
 * \brief Data transfer object representing a user's personal data
 *
 * \date 16-09-2025
 */

namespace Transacto.Application.User.Dtos;

public class PersonalDataDto
{
    public string FirstName { get; private set; } = default!;
    public string LastName { get; private set; } = default!;
    public string Ssn { get; private set; } = default!;
    public string Gender { get; private set; } = default!;
    public DateOnly DateOfBirth { get; private set; } = default!;
    public string PlaceOfBirth { get; private set; } = default!;
    public string Nationality { get; private set; } = default!;
    public string PhoneNumber { get; private set; } = default!;
    public AddressDto AddressDto { get; private set; } = default!;
}