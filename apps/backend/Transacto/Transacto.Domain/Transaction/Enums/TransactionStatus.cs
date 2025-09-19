/*
 * \file TransactionStatus.cs
 * \brief Enumeration representing transaction status
 * 
 * \date 19-09-2025
 */

namespace Transacto.Domain.Transaction.Enums;

public enum TransactionStatus
{
    Pending,
    Completed,
    Failed,
    Cancelled
}