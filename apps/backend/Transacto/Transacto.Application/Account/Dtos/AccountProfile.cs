/*
 * \file AccountProfile.cs
 * \brief AutoMapper profile for mapping account dtos and commands to domain entities
 *
 * \date 17-09-2025
 */

using AutoMapper;
using Transacto.Application.Account.Commands.CreateAccount;
using Transacto.Application.Account.Commands.UpdateAccount;
using Transacto.Domain.Account.ValueObjects;
using EntityAccount = Transacto.Domain.Account.Entities.Account;

namespace Transacto.Application.Account.Dtos;

public class AccountProfile : Profile
{
    public AccountProfile()
    {
        CreateMap<CreateAccountCommand, EntityAccount>();
        CreateMap<EntityAccount, AccountDto>();
        CreateMap<UpdateAccountCommand, EntityAccount>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.UserId, opt => opt.Ignore())
            .ForMember(dest => dest.Balance, opt => opt.Ignore())
            .ForMember(dest => dest.Summaries, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());
        CreateMap<Money, MoneyDto>();
        CreateMap<AccountSummary, AccountSummaryDto>();
    }
}