/*
 * \file TransactionNotFoundException.cs
 * \brief Exception thrown when a transaction is not found
 *
 * \date 20-09-2025
 */

namespace Transacto.Application.Transaction.Exceptions;

public class TransactionNotFoundException : Exception
{
    public TransactionNotFoundException() : base("Transaction could not be found") { }
}