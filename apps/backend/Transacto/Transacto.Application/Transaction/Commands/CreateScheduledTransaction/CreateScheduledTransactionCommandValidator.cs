/*
 * \file CreateScheduledTransactionCommandValidator.cs
 * \brief Validator class for the CreateScheduledTransactionCommand
 *
 * \date 20-09-2025
 */

using FluentValidation;

namespace Transacto.Application.Transaction.Commands.CreateScheduledTransaction;

public class CreateScheduledTransactionCommandValidator : AbstractValidator<CreateScheduledTransactionCommand>
{
    public CreateScheduledTransactionCommandValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().WithMessage("From Account Id is required");
        RuleFor(x => x.FromAccountId).NotEmpty().WithMessage("From Account Id is required");
        RuleFor(x => x.ToAccountId).NotEmpty().WithMessage("To Account Id is required");
        RuleFor(x => x.CurrencyId).NotEmpty().WithMessage("Currency Id is required");
        RuleFor(x => x.Amount).NotEmpty().WithMessage("Amount is required");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
        RuleFor(x => x.Type).NotEmpty().WithMessage("Type is required");
    }
}