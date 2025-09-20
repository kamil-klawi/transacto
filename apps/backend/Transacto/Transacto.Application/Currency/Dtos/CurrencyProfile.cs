/*
 * \file CurrencyProfile.cs
 * \brief AutoMapper profile for mapping currency dtos and commands to domain entities
 *
 * \date 18-09-2025
 */

using AutoMapper;
using Transacto.Application.Currency.Commands.UpdateCurrencyRate;
using EntityCurrency = Transacto.Domain.Currency.Entities.Currency;

namespace Transacto.Application.Currency.Dtos;

public class CurrencyProfile : Profile
{
    public CurrencyProfile()
    {
        CreateMap<EntityCurrency, CurrencyDto>();
        CreateMap<UpdateCurrencyRateCommand, EntityCurrency>();
    }
}