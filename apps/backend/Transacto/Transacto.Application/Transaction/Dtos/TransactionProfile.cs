/*
 * \file TransactionProfile.cs
 * \brief AutoMapper profile for mapping transaction dtos and commands to domain entities
 *
 * \date 20-09-2025
 */


using AutoMapper;
using Transacto.Application.Transaction.Commands.CancelScheduledTransaction;
using Transacto.Application.Transaction.Commands.CreateScheduledTransaction;
using Transacto.Application.Transaction.Commands.CreateTransaction;
using EntityTransaction = Transacto.Domain.Transaction.Entities.Transaction;
using EntityScheduledTransaction = Transacto.Domain.Transaction.Entities.ScheduledTransaction;

namespace Transacto.Application.Transaction.Dtos;

public class TransactionProfile : Profile
{
    public TransactionProfile()
    {
        CreateMap<EntityTransaction, TransactionDto>();
        CreateMap<TransactionDto, EntityTransaction>();
        CreateMap<EntityScheduledTransaction, ScheduledTransactionDto>();
        CreateMap<ScheduledTransactionDto, EntityScheduledTransaction>();
        CreateMap<CreateTransactionCommand, EntityTransaction>();
        CreateMap<CreateScheduledTransactionCommand, EntityTransaction>();
        CreateMap<CancelScheduledTransactionCommand, EntityScheduledTransaction>();
    }
}