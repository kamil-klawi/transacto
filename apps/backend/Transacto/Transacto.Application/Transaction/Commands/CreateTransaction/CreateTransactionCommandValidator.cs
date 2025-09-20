/*
 * \file CreateTransactionCommandValidator.cs
 * \brief Validator class for the CreateTransactionCommand
 *
 * \date 20-09-2025
 */

using FluentValidation;

namespace Transacto.Application.Transaction.Commands.CreateTransaction;

public class CreateTransactionCommandValidator : AbstractValidator<CreateTransactionCommand>
{
    public CreateTransactionCommandValidator()
    {
        RuleFor(x => x.FromAccountId).NotEmpty().WithMessage("From Account Id is required");
        RuleFor(x => x.ToAccountId).NotEmpty().WithMessage("To Account Id is required");
        RuleFor(x => x.CurrencyId).NotEmpty().WithMessage("Currency Id is required");
        RuleFor(x => x.Amount).NotEmpty().WithMessage("Amount is required");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
        RuleFor(x => x.Type).NotEmpty().WithMessage("Type is required");
    }
}