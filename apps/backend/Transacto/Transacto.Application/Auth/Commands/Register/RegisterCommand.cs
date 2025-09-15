/*
 * \file RegisterCommand.cs
 * \brief Command for user registration
 *
 * The RegisterCommand class encapsulates all the data needed for
 * registering a new user in the system
 *
 * \date 15-09-2025
 */

using MediatR;
using Transacto.Application.Auth.Dtos;

namespace Transacto.Application.Auth.Commands.Register;

public class RegisterCommand : IRequest<AuthResult>
{
    public string FirstName { get; private set; } = default!;
    public string LastName { get; private set; } = default!;
    public string Ssn { get; private set; } = default!;
    public string Gender { get; private set; } = default!;
    public DateOnly DateOfBirth { get; private set; } = default!;
    public string PlaceOfBirth { get; private set; } = default!;
    public string Nationality { get; private set; } = default!;
    public string PhoneNumber { get; private set; } = default!;
    public string Street { get; private set; } = default!;
    public string City { get; private set; } = default!;
    public string PostalCode { get; private set; } = default!;
    public string Country { get; private set; } = default!;
    public string Email { get; private set; } = default!;
    public string Password { get; private set; } = default!;
}
