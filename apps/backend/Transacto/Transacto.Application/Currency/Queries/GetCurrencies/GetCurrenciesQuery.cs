/*
 * \file GetCurrenciesQuery.cs
 * \brief Query class for retrieving all currencies
 *
 * \date 18-09-2025
 */

using MediatR;
using Transacto.Application.Currency.Dtos;

namespace Transacto.Application.Currency.Queries.GetCurrencies;

public class GetCurrenciesQuery : IRequest<IEnumerable<CurrencyDto>>
{
    
}