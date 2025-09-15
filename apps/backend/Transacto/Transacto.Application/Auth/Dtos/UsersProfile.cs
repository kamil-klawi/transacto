/*
 * \file UsersProfile.cs
 * \brief AutoMapper profile for mapping authentication commands to domain entities
 *
 * \date 15-09-2025
 */

using AutoMapper;
using Transacto.Application.Auth.Commands.Register;
using Transacto.Domain.Users.Entities;
using Transacto.Domain.Users.ValueObjects;

namespace Transacto.Application.Auth.Dtos;

public class UsersProfile : Profile
{
    public UsersProfile()
    {
        CreateMap<RegisterCommand, User>().ConstructUsing((src, context) =>
        {
            var email = new Email(src.Email);
            var passwordHash = new PasswordHash(src.Password);
            var address = new Address(src.Street, src.City, src.PostalCode, src.Country);
            var personalData = new PersonalData(src.FirstName, src.LastName, src.Ssn, src.Gender, src.DateOfBirth, src.PlaceOfBirth, src.Nationality, src.PhoneNumber, address);
            var twoFactor = TwoFactorAuthentication.Disable();
            
            return new User(Guid.NewGuid(), email, passwordHash, personalData, twoFactor);
        });
    }
}