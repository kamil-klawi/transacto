/*
 * \file AddressDto.cs
 * \brief Data transfer object representing a user's address
 *
 * \date 16-09-2025
 */

namespace Transacto.Application.User.Dtos;

public class AddressDto
{
    public string Street { get; private set; } = default!;
    public string City { get; private set; } = default!;
    public string PostalCode { get; private set; } = default!;
    public string Country { get; private set; } = default!;
}