/*
 * \file CreateAccountCommand.cs
 * \brief Command for creating a new user account
 *
 * Fields:
 * - Name: The display name of the account
 * - UserId: The ID of the user creating the account
 * - Type: The type of the account
 * - InitialAmount: The starting balance of the account
 * - CurrencyCode: Currency code
 * 
 * \date 17-09-2025
 */

using MediatR;
using Transacto.Domain.Account.Enums;

namespace Transacto.Application.Account.Commands.CreateAccount;

public class CreateAccountCommand : IRequest
{
    public string Name { get; private set; } = default!;
    public Guid UserId { get; private set; } = default!;
    public AccountType Type { get; private set; }
    public decimal InitialAmount { get; private set; }
    public string CurrencyCode { get; private set; } = default!;
}