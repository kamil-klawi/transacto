/*
 * \file UserProfile.cs
 * \brief AutoMapper profile for mapping user commands to domain entities
 *
 * \date 16-09-2025
 */

using AutoMapper;
using Transacto.Application.User.Commands.UpdateUser;

namespace Transacto.Application.User.Dtos;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UpdateUserCommand, Domain.Users.Entities.User>();
        CreateMap<Domain.Users.ValueObjects.PersonalData, PersonalDataDto>();
        CreateMap<Domain.Users.ValueObjects.Address, AddressDto>();
        CreateMap<Domain.Users.Entities.User, UserDto>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.Value));
    }
}