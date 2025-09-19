/*
 * \file TransactionType.cs
 * \brief Enumeration representing types of transaction
 * 
 * \date 19-09-2025
 */

namespace Transacto.Domain.Transaction.Enums;

public enum TransactionType
{
    InternalTransfer,
    ExternalTransfer,
    CurrencyConversion,
    ScheduledTransfer
}