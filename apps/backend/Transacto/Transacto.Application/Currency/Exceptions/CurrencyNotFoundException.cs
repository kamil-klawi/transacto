/*
 * \file CurrencyNotFoundException.cs
 * \brief Exception thrown when a currency with a specified code is not found
 *
 * \date 18-09-2025
 */

namespace Transacto.Application.Currency.Exceptions;

public class CurrencyNotFoundException : Exception
{
    public CurrencyNotFoundException(string code) : base($"Currency with code '{code}' was not found.") {}
}