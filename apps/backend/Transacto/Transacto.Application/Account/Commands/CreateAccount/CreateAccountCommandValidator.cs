/*
 * \file CreateAccountCommandValidator.cs
 * \brief Validator class for the CreateAccountCommand
 *
 * \date 17-09-2025
 */

using FluentValidation;

namespace Transacto.Application.Account.Commands.CreateAccount;

public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand>
{
    public CreateAccountCommandValidator()
    {
        RuleFor(a => a.Name)
            .NotEmpty()
            .WithMessage("Name is required")
            .Length(3, 100)
            .WithMessage("Name must be between 3 and 100 characters");
        
        RuleFor(a => a.Type)
            .IsInEnum()
            .WithMessage("Invalid account type");
        
        RuleFor(a => a.InitialAmount)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Initial amount cannot be negative");
        
        RuleFor(a => a.CurrencyCode)
            .NotEmpty()
            .WithMessage("Name is required")
            .Length(3)
            .WithMessage("Currency code must be a valid 3-letter code");
    }
}